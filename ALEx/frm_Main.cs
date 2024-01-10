using ALEx.Classes;
using ALEx.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static ALEx.Models.LogFilter;
using static ALEx.Models.PublicVariables;

namespace ALEx
{
    public partial class frm_Main : Form
    {
        #region Local variables
        private int _totalFilesCount = 0;
        private int _currentFileCount = 0;
        private int _duplicateFiles = 0;
        private int _filesInFolders = 0;

        private bool _hasTextEditors = false;
        private bool _showAssemblyVersion = false;

        private string _appDataFolder = "";
        private string _foldersFilter = "*.log";
        private string _NL = Environment.NewLine;

        private List<string> _args = new List<string>();
        private List<string> _files = new List<string>();
        private List<LogFilter> _filters = new List<LogFilter>();

        private FunctionResponse _result = new FunctionResponse();
        private Report _report = new Report();
        private Stopwatch _stopwatch = new Stopwatch();
        private FilteringMode _filteringMode = FilteringMode.Strict;
        #endregion

        public frm_Main(List<string> args = null)
        {
            InitializeComponent();
            _args = args;
        }

        #region Auxiliary functions
        private void Sleep(int msInterval)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.ElapsedMilliseconds < msInterval)
            {
                Application.DoEvents();
            }
            stopwatch.Stop();
        }
        #endregion

        private void frm_Main_Load(object sender, EventArgs e)
        {
            if (_args.Count > 0) { ProcessPaths(_args); }
            cmb_FilterType.SelectedIndex = 0;
            List<TextEditor> textEditors = Helpers.GetTextEditors(onlyExisting: true);
            if (textEditors.Count > 0)
            {
                chk_OpenReport.Checked = true;
                textEditors.ForEach(te => cmb_OpenReportWith.Items.Add(new ComboboxItem(te.Name, te.Path)));
                cmb_OpenReportWith.SelectedIndex = 0;
                _hasTextEditors = true;
            }
            else
            {
                chk_CopyReportToCB.Visible = chk_CopyReportToCB.Checked = true;
                chk_OpenReport.Visible = cmb_OpenReportWith.Visible = bnt_OpenLastReport.Visible = false;
                btn_CopyLastReport.Visible = true;
                _hasTextEditors = false;
            }
            _appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\AvA.Soft\ALEx\";
            Directory.CreateDirectory(_appDataFolder);
            cmb_FilteringMode.SelectedIndex = 0;
            SetAppTitle(_showAssemblyVersion);
        }

        private void frm_Main_Shown(object sender, EventArgs e)
        {
            while (this.Opacity <= 0.92)
            {
                this.Opacity += 0.02;
                Sleep(12);
            }
            this.Opacity = 1;
            if (!File.Exists("Newtonsoft.Json.dll"))
            {
                MessageBox.Show(this, "The 'Newtonsoft.Json.dll' file (version 13.0.1) is missing." + _NL +
                    "You won't be able to process the logs without this file. Please place the file next to this app.", "ALEx", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SetAppTitle(bool showAssemblyVersion = false)
        {
            this.Text = $"ALEx (Axway Logs Extractor)  -  {Helpers.GetAppVersion(fieldCount: (showAssemblyVersion ? 4 : 2), addVPrefix: true, addRuntimeMode: true)}  -  AvA.Soft";
        }

        private void ProcessPaths(List<string> paths, bool checkItems = true)
        {
            foreach (string path in paths)
            {
                PathType pathType = GetPathType(path);
                if (pathType == PathType.File)
                {
                    if (!clb_Files.Items.Contains(path))
                    { clb_Files.Items.Add(path, checkItems); }
                }
                else if (pathType == PathType.Directory)
                {
                    if (!clb_Folders.Items.Contains(path))
                    { clb_Folders.Items.Add(path, checkItems); }
                }
            }
            UpdateInfoLabels();
        }

        private void UpdateInfoLabels()
        {
            lbl_FilesInfo.Text = $"Files ({clb_Files.Items.Count}):";
            lbl_FoldersInfo.Text = $"Folders ({clb_Folders.Items.Count}):";
        }

        private void PrepareFiles()
        {
            _files.Clear();
            _filesInFolders = 0;
            _files.AddRange(clb_Files.CheckedItems.OfType<string>().ToList());
            foreach (string folder in clb_Folders.CheckedItems.OfType<string>().ToList())
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(folder);
                List<FileInfo> folderFiles = directoryInfo.GetFiles(_foldersFilter, 
                    chk_IncludeSubfolders.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly).ToList();
                folderFiles.ForEach(f => _files.Add(f.FullName));
                _filesInFolders += folderFiles.Count;
            }
            int totalFilesCountTemp = _files.Count;
            _files = _files.Distinct().ToList();
            _totalFilesCount = _files.Count;
            _duplicateFiles = totalFilesCountTemp - _totalFilesCount;
        }

        private void PrepareFilters()
        {
            _filters.Clear();
            if (dgv_Filters.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgv_Filters.Rows)
                {
                    FilterType filterType = row.Cells[1].Value.ToString().Equals("contains", StringComparison.OrdinalIgnoreCase) ? FilterType.Contains : FilterType.DoesNotContain;
                    _filters.Add(new LogFilter(row.Cells[0].Value.ToString(), filterType));
                }
            }
        }

        private void PrepareReport()
        {
            _report.TotalFilesCount = _totalFilesCount;
            _report.ElapsedTime = _stopwatch.Elapsed;
            _report.ProcessResult = _result;
            _report.ReportDateTime = DateTime.Now.ToString("dddd, dd.MM.yyyy @ HH:mm:ss");
        }

        private FunctionResponse ProcessLOGS(
            List<string> logFiles,
            bool keepHeader = true,
            bool parseReqRes = true,
            bool saveAsJson = true,
            bool indented = false,
            bool overwriteFiles = false,
            List<LogFilter> filters = null,
            Label statusLabel = null)
        {
            try
            {
                _currentFileCount = 0;
                string statusLabelBackupText = "";
                if (statusLabel != null) { statusLabelBackupText = statusLabel.Text; }
                foreach (string filePath in logFiles)
                {
                    if (bgWorker.CancellationPending) { return null; }

                    _currentFileCount++;
                    if (statusLabel != null)
                    {
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            statusLabel.Text = statusLabelBackupText + $" Processing file {_currentFileCount} out of {_totalFilesCount} . . .";
                            statusLabel.Refresh();
                        }));
                    }

                    if (!File.Exists(filePath)) { _report.MissingFiles.AddPath(filePath.ReversePathSlashes()); continue; }
                    List<string> fileDataLines = new List<string>();
                    List<string> fileDataLinesBackup = new List<string>();
                    LogHeader logHeader = new LogHeader();
                    AxwayLog axwayLog = new AxwayLog();

                    FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                    using (StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8))
                    {
                        fileDataLines = streamReader.ReadToEnd().Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                        if (fileDataLines.Count == 0) 
                        {
                            _report.SkippedFiles.AddFile(new Report.SkippedFileInfo(filePath.ReversePathSlashes(), "The file does not have lines with data."));
                            continue;
                        }
                    }
                    fileDataLinesBackup = new List<string>(fileDataLines);

                    if (keepHeader)
                    {
                        string logHeaderString = fileDataLines.FirstOrDefault(line => line.StartsWith("{\"type\":\"header\","));
                        if (!logHeaderString.INOE())
                        {
                            logHeader = JsonConvert.DeserializeObject<LogHeader>(logHeaderString);
                            axwayLog.LogHeader = logHeader;
                        }
                    }

                    fileDataLines.RemoveAll(line => line.StartsWith("{\"type\":\"header\",") || line.StartsWith("{\"type\":\"system\","));
                    if (!fileDataLines.Any(l => l.StartsWith("{\"type\":\"transaction\","))) 
                    {
                        _report.SkippedFiles.AddFile(new Report.SkippedFileInfo(filePath.ReversePathSlashes(), "The file does not have lines that start with the property 'type' with value 'transaction'."));
                        continue;
                    }

                    if (filters != null && filters.Count > 0)
                    {
                        if (_filteringMode == FilteringMode.Strict)
                        {
                            List<string> filteredLines = new List<string>();
                            foreach (string line in fileDataLines)
                            {
                                if (bgWorker.CancellationPending) { return null; }

                                bool lineValid = true;
                                foreach (LogFilter logFilter in filters)
                                {
                                    if (logFilter.Type == LogFilter.FilterType.Contains)
                                    {
                                        if (!line.Contains(logFilter.Text, StringComparison.OrdinalIgnoreCase)) { lineValid = false; break; }
                                    }
                                    else if (logFilter.Type == LogFilter.FilterType.DoesNotContain)
                                    {
                                        if (line.Contains(logFilter.Text, StringComparison.OrdinalIgnoreCase)) { lineValid = false; break; }
                                    }
                                }
                                if (lineValid) { filteredLines.Add(line); }
                            }
                            fileDataLines = filteredLines;
                        }
                        else if (_filteringMode == FilteringMode.Union)
                        {
                            List<string> filteredLinesContains = new List<string>();
                            List<string> filteredLinesDoesNotContain = new List<string>();
                            foreach (LogFilter logFilter in filters)
                            {
                                if (logFilter.Type == LogFilter.FilterType.Contains)
                                {
                                    filteredLinesContains.AddRange(fileDataLines.Where(l => l.Contains(logFilter.Text, StringComparison.OrdinalIgnoreCase)));
                                }
                                else if (logFilter.Type == LogFilter.FilterType.DoesNotContain)
                                {
                                    filteredLinesDoesNotContain.AddRange(fileDataLines.Where(l => !l.Contains(logFilter.Text, StringComparison.OrdinalIgnoreCase)));
                                }
                            }
                            fileDataLines = filteredLinesContains.Distinct().Union(filteredLinesDoesNotContain.Distinct()).ToList();
                        }
                    }

                    if (fileDataLines.Count == 0)
                    {
                        _report.SkippedFiles.AddFile(new Report.SkippedFileInfo(filePath.ReversePathSlashes(), "The file does not meet the filters criteria."));
                        continue;
                    }

                    foreach (string fileLine in fileDataLines)
                    {
                        (JObject logTransaction, string validationMessage) = ParseStringToJson(stringData: fileLine, removeLineAndPositionFromMsg: true);
                        if (logTransaction is null)
                        {
                            int lineNumber = fileDataLinesBackup.FindIndex(l => l.Equals(fileLine)) + 1;
                            if (lineNumber > 0) { validationMessage = $"Line: {lineNumber}. {validationMessage}"; }

                            string currentFilePathReversed = filePath.ReversePathSlashes();
                            if (_report.JsonValidationErrors.ContainsKey(currentFilePathReversed))
                            {
                                _report.JsonValidationErrors[currentFilePathReversed].Add(validationMessage);
                            }
                            else
                            {
                                _report.JsonValidationErrors.Add(currentFilePathReversed, new List<string> { validationMessage });
                            }
                            continue;
                        }

                        if (parseReqRes && logTransaction.ContainsKey("customMsgAtts") && logTransaction["customMsgAtts"] != null)
                        {
                            JObject customMsgAtts = logTransaction["customMsgAtts"].ToObject<JObject>();
                            if (customMsgAtts.ContainsKey("requestLog") && customMsgAtts["requestLog"] != null)
                            {
                                logTransaction["customMsgAtts"]["requestLog"] = ParseReqResLog(logTransaction["customMsgAtts"]["requestLog"].ToString(), returnAsSerializedString: false);
                            }
                            if (customMsgAtts.ContainsKey("responseLog") && customMsgAtts["responseLog"] != null)
                            {
                                logTransaction["customMsgAtts"]["responseLog"] = ParseReqResLog(logTransaction["customMsgAtts"]["responseLog"].ToString(), returnAsSerializedString: false);
                            }
                        }

                        axwayLog.LogTransactions.Add(logTransaction);
                    }

                    axwayLog.NumberOfTransactions = axwayLog.LogTransactions.Count();
                    string serializedAxwayLog = JsonConvert.SerializeObject(axwayLog, (indented ? Formatting.Indented : Formatting.None));

                    string filePathOnly = Path.GetDirectoryName(filePath);
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
                    string alex = fileNameWithoutExtension.Contains(" ") ? " ALEx" : "_ALEx";
                    string fileExtension = saveAsJson ? ".json" : Path.GetExtension(filePath);
                    string newFilePath = $"{filePathOnly}\\{fileNameWithoutExtension + alex + fileExtension}";

                    if (!overwriteFiles && File.Exists(newFilePath))
                    {
                        int copy = 1;
                        string copyName = $"{filePathOnly}\\{fileNameWithoutExtension + alex}_{copy + fileExtension}";
                        while (File.Exists(copyName))
                        {
                            copy++;
                            copyName = $"{filePathOnly}\\{fileNameWithoutExtension + alex}_{copy + fileExtension}";
                        }
                        newFilePath = copyName;
                    }

                    fileStream = new FileStream(newFilePath, FileMode.Create, FileAccess.Write);
                    using (StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
                    {
                        streamWriter.Write(serializedAxwayLog);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }

                    _report.SuccessfulFiles.AddPath(filePath.ReversePathSlashes());
                }
                return new FunctionResponse(error: false, message: "Process was completed successfully!");
            }
            catch (Exception ex)
            {
                return new FunctionResponse(error: true, message: ex.Message, stackTrace: ex.StackTrace);
            }
        }

        private dynamic ParseReqResLog(string stringData, bool returnAsSerializedString = false)
        {
            if (stringData.INOE()) { return ""; }
            string cleanStringData = stringData.Replace("\"{", "{")
                .Replace("}\"", "}")
                .Replace("\\r\\n", "")
                .Replace("\\n", "")
                .Replace("\\\"", "\"")
                .Replace("\"payload\": ,", "\"payload\": \"\",");

            JObject jsonObj = ParseStringToJson(cleanStringData).jObject;
            if (jsonObj is null)
            {
                return stringData;
            }
            else
            {
                if (returnAsSerializedString)
                { return JsonConvert.SerializeObject(jsonObj); }
                else { return jsonObj; }
            }
        }

        private (JObject jObject, string validationMessage) ParseStringToJson(string stringData, bool removeLineAndPositionFromMsg = true)
        {
            try
            {
                return (JObject.Parse(stringData), "");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Path 'payload'", StringComparison.OrdinalIgnoreCase))
                {
                    string fixedJson = Try2FixJson(stringData);
                    var (isValid, jObject, validationError) = fixedJson.Parse2Json();
                    if (isValid)
                    {
                        return (jObject, "");
                    }
                }
                return (null, removeLineAndPositionFromMsg ? Regex.Replace(ex.Message, @", line \d+, position \d+", "") : ex.Message);
            }
        }

        private string Try2FixJson(string jsonData)
        {
            try
            {
                //string payloadFixPattern = @"""payload""\s*:(.*?)\,\s*""customerId""";
                string payloadFixPattern = @"(?<=""payload"":)(.*?)(?=\,\s*""customerId"")";
                MatchCollection payloadMatches = Regex.Matches(jsonData, payloadFixPattern);
                if (payloadMatches.Count == 1)
                {
                    string payloadData = payloadMatches[0].Groups[1].Value.Trim().Replace("\"", "\\\"");
                    string fixedJson = Regex.Replace(jsonData, payloadFixPattern, $" \"{payloadData}\"");
                    return fixedJson;
                }
                return jsonData;
            }
            catch (Exception)
            {
                return jsonData;
            }
        }

        private enum PathType { File = 0, Directory = 1, Unknown = 2 }
        private PathType GetPathType(string path)
        {
            if (path.INOE()) { return PathType.Unknown; }
            FileAttributes fileAttributes = File.GetAttributes(path);
            if ((fileAttributes & FileAttributes.Directory) == FileAttributes.Directory)
            { return PathType.Directory; }
            else
            { return PathType.File; }
        }

        private enum ViewType { Main = 0, DragDrop = 1 }
        private void SetView(ViewType viewType)
        {
            if (viewType == ViewType.Main)
            {
                pnl_DragDrop.Visible = lbl_DragDropStuck.Visible = false;
                pnl_FILES.Visible = pnl_FOLDERS.Visible = pnl_OPTIONS.Visible = pnl_FILTERS.Visible = pnl_REPORT.Visible = true;
            }
            else if (viewType == ViewType.DragDrop)
            {
                pnl_FILES.Visible = pnl_FOLDERS.Visible = pnl_OPTIONS.Visible = pnl_FILTERS.Visible = pnl_REPORT.Visible = false;
                pnl_DragDrop.Visible = true;
            }
        }

        private void GeneralDragENTER(object sender, DragEventArgs e)
        {
            SetView(ViewType.DragDrop);
        }

        private void pnl_DragDrop_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) { e.Effect = DragDropEffects.Copy; }
        }

        private void pnl_DragDrop_DragLeave(object sender, EventArgs e)
        {
            SetView(ViewType.Main);
        }

        private void pnl_DragDrop_DragDrop(object sender, DragEventArgs e)
        {
            string[] paths = new string[] { };
            paths = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (paths.Count() > 0) { ProcessPaths(paths.ToList()); }
            SetView(ViewType.Main);
        }

        private void btn_RemoveFile_Click(object sender, EventArgs e)
        {
            if (clb_Files.Items.Count == 0 || clb_Files.SelectedItems.Count == 0) { return; }
            clb_Files.Items.Remove(clb_Files.SelectedItem);
            UpdateInfoLabels();
        }

        private void btn_RemoveAllFiles_Click(object sender, EventArgs e)
        {
            clb_Files.Items.Clear();
            UpdateInfoLabels();
        }

        private void btn_ChkAllFiles_Click(object sender, EventArgs e)
        {
            clb_Files.CheckAllItems(true);
        }

        private void btn_ChkNoneFiles_Click(object sender, EventArgs e)
        {
            clb_Files.CheckAllItems(false);
        }

        private void btn_ChkInvFiles_Click(object sender, EventArgs e)
        {
            clb_Files.CheckAllItems(inverse: true);
        }

        private void btn_RemoveFolder_Click(object sender, EventArgs e)
        {
            if (clb_Folders.Items.Count == 0 || clb_Folders.SelectedItems.Count == 0) { return; }
            clb_Folders.Items.Remove(clb_Folders.SelectedItem);
            UpdateInfoLabels();
        }

        private void btn_RemoveAllFolders_Click(object sender, EventArgs e)
        {
            clb_Folders.Items.Clear();
            UpdateInfoLabels();
        }

        private void btn_ChkAllFolders_Click(object sender, EventArgs e)
        {
            clb_Folders.CheckAllItems(true);
        }

        private void btn_ChkNoneFolders_Click(object sender, EventArgs e)
        {
            clb_Folders.CheckAllItems(false);
        }

        private void btn_ChkInvFolders_Click(object sender, EventArgs e)
        {
            clb_Folders.CheckAllItems(inverse: true);
        }

        private void btn_WORK_Click(object sender, EventArgs e)
        {
            if (clb_Files.Items.Count == 0 && clb_Folders.Items.Count == 0)
            {
                MessageBox.Show(this, "There are no files and no folders added.", "ALEx", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (clb_Files.CheckedItems.Count == 0 && clb_Folders.CheckedItems.Count == 0)
            {
                MessageBox.Show(this, "There are no files and no folders checked.", "ALEx", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!File.Exists("Newtonsoft.Json.dll"))
            {
                MessageBox.Show(this, "The 'Newtonsoft.Json.dll' file (version 13.0.1) is missing." + _NL +
                    "You won't be able to process the logs without this file. Please place the file next to this app's executable.", "ALEx", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmb_FolderFilter.Text.INOE()) { cmb_FolderFilter.SelectedIndex = 0; }
            _foldersFilter = cmb_FolderFilter.Text;

            bgWorker.RunWorkerAsync();
        }

        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                while (this.Opacity >= 0.02)
                {
                    this.Opacity -= 0.02;
                    Sleep(12);
                }
                this.Opacity = 0;
                Application.Exit();
            }
        }

        private void EnableControls(bool enabled)
        {
            pnl_FILES.Enabled = pnl_FOLDERS.Enabled = pnl_FILTERS.Enabled = enabled;
        }

        private void SetWorkingView(bool visible)
        {
            pnl_STATUS.Visible = visible;
            pnl_OPTIONS.Visible = !visible;
        }

        private void UpdateWorkingStatus()
        {
            int files = clb_Files.CheckedItems.Count;
            int folders = clb_Folders.CheckedItems.Count;
            int total = files + _filesInFolders;
            lbl_Status.Text = $"Selected {files.ToSingOrPlur("file", "files", keepNumber: true)} and {folders.ToSingOrPlur("folder", "folders", keepNumber: true)} " +
                $"(containing {_filesInFolders.ToSingOrPlur("file", "files", keepNumber: true)}), in total: {total.ToSingOrPlur("file", "files", keepNumber: true)} " +
                $"({_duplicateFiles} duplicate {_duplicateFiles.ToSingOrPlur("file", "files", keepNumber: false)}).";
        }

        private void btn_CancelWork_Click(object sender, EventArgs e)
        {
            if (bgWorker.IsBusy)
            {
                bgWorker.CancelAsync();
            }
            EnableControls(true);
            SetWorkingView(false);
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _report.Clear();
            _result = new FunctionResponse();
            _stopwatch.Reset();
            _stopwatch.Start();

            this.Invoke(new MethodInvoker(delegate ()
            {
                EnableControls(false);
                SetWorkingView(true);
                pnl_STATUS.Refresh();
            }));

            PrepareFiles();
            PrepareFilters();

            this.Invoke(new MethodInvoker(delegate ()
            {
                UpdateWorkingStatus();
                pnl_STATUS.Refresh();
            }));

            _result = ProcessLOGS(_files, chk_KeepHeader.Checked, chk_ParseReqRes.Checked, chk_SaveAsJSON.Checked, 
                chk_Indent.Checked, chk_Overwrite.Checked, _filters, lbl_Status);
            if (_result is null) { e.Cancel = true; }

            FinishWork();
        }

        private void FinishWork()
        {
            _stopwatch.Stop();
            PrepareReport();
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Refresh();
            int missingCount = _report.MissingFiles.Count;
            int skippedCount = _report.SkippedFiles.Count;
            int validationErrors = _report.JsonValidationErrors.Count;
            string message = "Process finished!";
            string processedFilesMsg = _NL + $"Processed {_currentFileCount.ToSingOrPlur("file", "files", keepNumber: true)} out of {_totalFilesCount}." + _NL;
            string missingFilesMsg = missingCount > 0 ? _NL + $"Missing files: {missingCount}" : "";
            string skippedFilesMsg = skippedCount > 0 ? _NL + $"Skipped (non-compliant) files: {skippedCount}" : "";
            string jsonValidationErrors = validationErrors > 0 ? _NL + $"Files with json validation errors: {validationErrors}" : "";
            string duplicateFilesMsg = _duplicateFiles > 0 ? _NL + $"Duplicated (ignored) files: {_duplicateFiles}" : "";
            MessageBoxIcon messageBoxIcon = MessageBoxIcon.Information;
            if (e.Cancelled)
            {
                _report.ProcessResult = new FunctionResponse(error: false, message: "The process was cancelled by the user.");
                message = "The process was cancelled by the user." + processedFilesMsg + missingFilesMsg + skippedFilesMsg + jsonValidationErrors + duplicateFilesMsg;
                messageBoxIcon = MessageBoxIcon.Warning;
            }
            else if (e.Error != null)
            {
                FinishWork();
                _report.ProcessResult = new FunctionResponse(error: true, message: $"There was an error running the process: {e.Error.Message}", stackTrace: e.Error.StackTrace);
                message = $"There was an error running the process: {e.Error.Message + _NL}" + processedFilesMsg + missingFilesMsg + skippedFilesMsg + jsonValidationErrors + duplicateFilesMsg;
                messageBoxIcon = MessageBoxIcon.Error;
            }
            else if (_result.Error)
            {
                message = $"There was an error running the process: {_result.Message + _NL}" + processedFilesMsg + missingFilesMsg + skippedFilesMsg + jsonValidationErrors + duplicateFilesMsg;
                messageBoxIcon = MessageBoxIcon.Error;
            }
            else
            {
                message = "Process was completed successfully!" + processedFilesMsg + missingFilesMsg + skippedFilesMsg + jsonValidationErrors + duplicateFilesMsg;
            }
            if (_hasTextEditors && chk_OpenReport.Checked)
            {
                message += _NL.Repeat() + $"The report will open in {cmb_OpenReportWith.Text}.";
            }
            MessageBox.Show(this, message, "ALEx - Process report", MessageBoxButtons.OK, messageBoxIcon);
            EnableControls(true);
            SetWorkingView(false);
            if (_hasTextEditors && chk_OpenReport.Checked) { GenerateAndOpenReport(); }
            else if (!_hasTextEditors && chk_CopyReportToCB.Checked) { Clipboard.SetText(_report.ToJson()); }
        }

        private void UpdateFiltersInfo()
        {
            lbl_FiltersInfo.Text = $"Filters: {dgv_Filters.Rows.Count}";
        }

        private void btn_AddFilter_Click(object sender, EventArgs e)
        {
            if (txt_FilterString.Text.INOE())
            {
                MessageBox.Show(this, "The filter string is missing.", "ALEx", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgv_Filters.Contains(txt_FilterString.Text, cmb_FilterType.SelectedItem.ToString()))
            {
                MessageBox.Show(this, "This filter is already added.", "ALEx", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string filterTypeInverse = cmb_FilterType.SelectedItem.ToString().Equals("Contains", StringComparison.OrdinalIgnoreCase) ? "Doesn't contain" : "Contains";
            if (dgv_Filters.Contains(txt_FilterString.Text, filterTypeInverse))
            {
                MessageBox.Show(this, $"This filter is already added but with the '{filterTypeInverse}' type." + _NL +
                    "Adding two filters with opposite types will yield no results.", "ALEx", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmb_FilterType.Items.Count == 1000)
            {
                MessageBox.Show(this, "For performance reasons, a limit of 1000 filters is accepted.", "ALEx", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dgv_Filters.Rows.Add(txt_FilterString.Text.Trim(), cmb_FilterType.SelectedItem);
            txt_FilterString.Text = "";
            cmb_FilterType.SelectedIndex = 0;
            UpdateFiltersInfo();
        }

        private void btn_DelAllFilters_Click(object sender, EventArgs e)
        {
            dgv_Filters.Rows.Clear();
            UpdateFiltersInfo();
        }

        private void btn_DelSelFilter_Click(object sender, EventArgs e)
        {
            if (dgv_Filters.SelectedRows.Count == 0) { return; }
            dgv_Filters.Rows.RemoveAt(dgv_Filters.SelectedCells[0].RowIndex);
            UpdateFiltersInfo();
        }

        private void txt_FilterString_MouseEnter(object sender, EventArgs e)
        {
            (string cbText, bool hasLB) = GetClipBoardText();
            if (!cbText.INOE())
            {
                string tooltipMsg = $"Double-click the textbox to add a filter with your clipboard data.{_NL}" +
                    $"This is the text from your clipboard{(hasLB ? " (ATTENTION: the line breaks were removed!)" : "")}:{_NL + cbText}";
                toolTips.SetToolTip(txt_FilterString, tooltipMsg);
                toolTips.Show(tooltipMsg, txt_FilterString, 0, 24);
                lbl_StringFilterTitle.Top = 34;
                lbl_StringFilterSubtitle.Visible = true;
            }
        }

        private void txt_FilterString_MouseLeave(object sender, EventArgs e)
        {
            lbl_StringFilterTitle.Top = 48;
            lbl_StringFilterSubtitle.Visible = false;
            toolTips.Hide(txt_FilterString);
            toolTips.SetToolTip(txt_FilterString, "Double-click the textbox to add a filter with your clipboard data.");
        }

        private void txt_FilterString_DoubleClick(object sender, EventArgs e)
        {
            string cbData = GetClipBoardText().clipboardText;
            if (!cbData.INOE())
            {
                toolTips.Hide(txt_FilterString);
                txt_FilterString.Text = cbData;
                btn_AddFilter_Click(sender, e);
            }
        }

        private (string clipboardText, bool hasLineBreaks) GetClipBoardText()
        {
            string cbData = Clipboard.GetText();
            return (cbData.Replace("\r\n", ""), cbData.Contains("\r\n"));
        }

        private void chk_OpenReport_CheckedChanged(object sender, EventArgs e)
        {
            cmb_OpenReportWith.Enabled = bnt_OpenLastReport.Enabled = chk_OpenReport.Checked;
        }

        private void bnt_OpenLastReport_Click(object sender, EventArgs e)
        {
            if (_report.IsEmpty)
            {
                MessageBox.Show(this, "The last report is empty.", "ALEx", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            GenerateAndOpenReport();
        }

        private void GenerateAndOpenReport()
        {
            string reportJson = _report.ToJson();
            ComboboxItem textEditor = cmb_OpenReportWith.SelectedItem as ComboboxItem;

            if (textEditor.Text.Equals("Microsoft Notepad", StringComparison.OrdinalIgnoreCase))
            {
                NotepadHelper.ShowMessage(reportJson, "ALEx - Process report");
                return;
            }

            (bool created, string filePath) = Helpers.CreateTempFile(_appDataFolder, "ALEx last report.json", reportJson);
            if (!created) 
            {
                MessageBox.Show(this, "An error occurred while trying to create the report file.",
                    "ALEx - Process report", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Process.Start(textEditor.Value, $"\"{filePath}\"");
        }

        private void lbl_FilteringModeHelp_Click(object sender, EventArgs e)
        {
            string info = "1. Strict - I check that each transaction within a file, meets the conditions from all filters." + _NL.Repeat() +
                "2. Union - For each file, I create a collection of transactions that meet AT LEAST ONE of the 'Contains' filters. " +
                "Then I create another collection of transactions that meet AT LEAST ONE of the 'Doesn't contain' filters. " +
                "Then I perform a union operation on these two collections and that is the final result (also, any duplicated transactions will be removed).";
            MessageBox.Show(this, info, "ALEx - Filtering mode info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_CopyLastReport_Click(object sender, EventArgs e)
        {
            if (_report.IsEmpty)
            {
                MessageBox.Show(this, "The last report is empty.", "ALEx", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Clipboard.SetText(_report.ToJson());
        }

        private void cmb_FilteringMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_FilteringMode.SelectedIndex == 0) { _filteringMode = FilteringMode.Strict; }
            else { _filteringMode = FilteringMode.Union; }
        }

        private void tmr_Pulse_Tick(object sender, EventArgs e)
        {
            while (this.Opacity >= 0.5)
            {
                this.Opacity -= 0.02;
                Sleep(12);
            }
            while (this.Opacity <= 0.92)
            {
                this.Opacity += 0.02;
                Sleep(12);
            }
            this.Opacity = 1;
        }

        private void frm_Main_DoubleClick(object sender, EventArgs e)
        {
            _showAssemblyVersion.Invert();
            SetAppTitle(_showAssemblyVersion);
        }

        private void lbl_DragDropStuck_Click(object sender, EventArgs e)
        {
        }

        private void pnl_DragDrop_MouseEnter(object sender, EventArgs e)
        {
            lbl_DragDropStuck.Visible = true;
        }

        private void pnl_DragDrop_MouseLeave(object sender, EventArgs e)
        {
            SetView(ViewType.Main);
        }

        private void pnl_DragDrop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
