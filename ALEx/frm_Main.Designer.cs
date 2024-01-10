
namespace ALEx
{
    partial class frm_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.clb_Files = new System.Windows.Forms.CheckedListBox();
            this.clb_Folders = new System.Windows.Forms.CheckedListBox();
            this.pnl_DragDrop = new System.Windows.Forms.Panel();
            this.lbl_DragDropStuck = new System.Windows.Forms.Label();
            this.lbl_FilesInfo = new System.Windows.Forms.Label();
            this.lbl_FoldersInfo = new System.Windows.Forms.Label();
            this.btn_RemoveAllFiles = new System.Windows.Forms.Button();
            this.btn_RemoveFile = new System.Windows.Forms.Button();
            this.btn_RemoveAllFolders = new System.Windows.Forms.Button();
            this.btn_RemoveFolder = new System.Windows.Forms.Button();
            this.btn_ChkInvFiles = new System.Windows.Forms.Button();
            this.btn_ChkNoneFiles = new System.Windows.Forms.Button();
            this.btn_ChkAllFiles = new System.Windows.Forms.Button();
            this.btn_ChkInvFolders = new System.Windows.Forms.Button();
            this.btn_ChkNoneFolders = new System.Windows.Forms.Button();
            this.btn_ChkAllFolders = new System.Windows.Forms.Button();
            this.chk_KeepHeader = new System.Windows.Forms.CheckBox();
            this.chk_ParseReqRes = new System.Windows.Forms.CheckBox();
            this.chk_Indent = new System.Windows.Forms.CheckBox();
            this.chk_Overwrite = new System.Windows.Forms.CheckBox();
            this.cmb_FolderFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_FILES = new System.Windows.Forms.Panel();
            this.pnl_FOLDERS = new System.Windows.Forms.Panel();
            this.chk_IncludeSubfolders = new System.Windows.Forms.CheckBox();
            this.pnl_OPTIONS = new System.Windows.Forms.Panel();
            this.btn_WORK = new System.Windows.Forms.Button();
            this.chk_SaveAsJSON = new System.Windows.Forms.CheckBox();
            this.pnl_STATUS = new System.Windows.Forms.Panel();
            this.btn_CancelWork = new System.Windows.Forms.Button();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.txt_FilterString = new System.Windows.Forms.TextBox();
            this.cmb_OpenReportWith = new System.Windows.Forms.ComboBox();
            this.chk_OpenReport = new System.Windows.Forms.CheckBox();
            this.chk_CopyReportToCB = new System.Windows.Forms.CheckBox();
            this.lbl_FilteringModeHelp = new System.Windows.Forms.Label();
            this.pnl_FILTERS = new System.Windows.Forms.Panel();
            this.cmb_FilteringMode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_StringFilterTitle = new System.Windows.Forms.Label();
            this.cmb_FilterType = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_FiltersInfo = new System.Windows.Forms.Label();
            this.lbl_StringFilterSubtitle = new System.Windows.Forms.Label();
            this.btn_AddFilter = new System.Windows.Forms.Button();
            this.btn_DelAllFilters = new System.Windows.Forms.Button();
            this.btn_DelSelFilter = new System.Windows.Forms.Button();
            this.dgv_Filters = new System.Windows.Forms.DataGridView();
            this.String = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnl_REPORT = new System.Windows.Forms.Panel();
            this.bnt_OpenLastReport = new System.Windows.Forms.Button();
            this.btn_CopyLastReport = new System.Windows.Forms.Button();
            this.tmr_Pulse = new System.Windows.Forms.Timer(this.components);
            this.pnl_DragDrop.SuspendLayout();
            this.pnl_FILES.SuspendLayout();
            this.pnl_FOLDERS.SuspendLayout();
            this.pnl_OPTIONS.SuspendLayout();
            this.pnl_STATUS.SuspendLayout();
            this.pnl_FILTERS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Filters)).BeginInit();
            this.pnl_REPORT.SuspendLayout();
            this.SuspendLayout();
            // 
            // clb_Files
            // 
            this.clb_Files.AllowDrop = true;
            this.clb_Files.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.clb_Files.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clb_Files.ForeColor = System.Drawing.Color.White;
            this.clb_Files.FormattingEnabled = true;
            this.clb_Files.HorizontalScrollbar = true;
            this.clb_Files.Location = new System.Drawing.Point(5, 31);
            this.clb_Files.Name = "clb_Files";
            this.clb_Files.Size = new System.Drawing.Size(735, 122);
            this.clb_Files.TabIndex = 1;
            this.toolTips.SetToolTip(this.clb_Files, "Drag & drop files and/or folders here.");
            this.clb_Files.DragEnter += new System.Windows.Forms.DragEventHandler(this.GeneralDragENTER);
            // 
            // clb_Folders
            // 
            this.clb_Folders.AllowDrop = true;
            this.clb_Folders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.clb_Folders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clb_Folders.ForeColor = System.Drawing.Color.White;
            this.clb_Folders.FormattingEnabled = true;
            this.clb_Folders.HorizontalScrollbar = true;
            this.clb_Folders.Location = new System.Drawing.Point(5, 32);
            this.clb_Folders.Name = "clb_Folders";
            this.clb_Folders.Size = new System.Drawing.Size(735, 122);
            this.clb_Folders.TabIndex = 14;
            this.toolTips.SetToolTip(this.clb_Folders, "Drag & drop files and/or folders here.");
            this.clb_Folders.DragEnter += new System.Windows.Forms.DragEventHandler(this.GeneralDragENTER);
            // 
            // pnl_DragDrop
            // 
            this.pnl_DragDrop.AllowDrop = true;
            this.pnl_DragDrop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.pnl_DragDrop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnl_DragDrop.BackgroundImage")));
            this.pnl_DragDrop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnl_DragDrop.Controls.Add(this.lbl_DragDropStuck);
            this.pnl_DragDrop.Location = new System.Drawing.Point(0, 0);
            this.pnl_DragDrop.Name = "pnl_DragDrop";
            this.pnl_DragDrop.Size = new System.Drawing.Size(1186, 418);
            this.pnl_DragDrop.TabIndex = 2;
            this.pnl_DragDrop.Visible = false;
            this.pnl_DragDrop.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnl_DragDrop_DragDrop);
            this.pnl_DragDrop.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnl_DragDrop_DragEnter);
            this.pnl_DragDrop.DragLeave += new System.EventHandler(this.pnl_DragDrop_DragLeave);
            this.pnl_DragDrop.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_DragDrop_Paint);
            this.pnl_DragDrop.MouseEnter += new System.EventHandler(this.pnl_DragDrop_MouseEnter);
            this.pnl_DragDrop.MouseLeave += new System.EventHandler(this.pnl_DragDrop_MouseLeave);
            // 
            // lbl_DragDropStuck
            // 
            this.lbl_DragDropStuck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_DragDropStuck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DragDropStuck.ForeColor = System.Drawing.Color.Gray;
            this.lbl_DragDropStuck.Location = new System.Drawing.Point(184, 385);
            this.lbl_DragDropStuck.Name = "lbl_DragDropStuck";
            this.lbl_DragDropStuck.Size = new System.Drawing.Size(818, 33);
            this.lbl_DragDropStuck.TabIndex = 0;
            this.lbl_DragDropStuck.Text = resources.GetString("lbl_DragDropStuck.Text");
            this.lbl_DragDropStuck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_DragDropStuck.Visible = false;
            // 
            // lbl_FilesInfo
            // 
            this.lbl_FilesInfo.AutoSize = true;
            this.lbl_FilesInfo.ForeColor = System.Drawing.Color.White;
            this.lbl_FilesInfo.Location = new System.Drawing.Point(2, 11);
            this.lbl_FilesInfo.Name = "lbl_FilesInfo";
            this.lbl_FilesInfo.Size = new System.Drawing.Size(46, 13);
            this.lbl_FilesInfo.TabIndex = 3;
            this.lbl_FilesInfo.Text = "Files (0):";
            // 
            // lbl_FoldersInfo
            // 
            this.lbl_FoldersInfo.AutoSize = true;
            this.lbl_FoldersInfo.ForeColor = System.Drawing.Color.White;
            this.lbl_FoldersInfo.Location = new System.Drawing.Point(2, 12);
            this.lbl_FoldersInfo.Name = "lbl_FoldersInfo";
            this.lbl_FoldersInfo.Size = new System.Drawing.Size(59, 13);
            this.lbl_FoldersInfo.TabIndex = 3;
            this.lbl_FoldersInfo.Text = "Folders (0):";
            // 
            // btn_RemoveAllFiles
            // 
            this.btn_RemoveAllFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btn_RemoveAllFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_RemoveAllFiles.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_RemoveAllFiles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.btn_RemoveAllFiles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btn_RemoveAllFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_RemoveAllFiles.ForeColor = System.Drawing.Color.White;
            this.btn_RemoveAllFiles.Location = new System.Drawing.Point(426, 6);
            this.btn_RemoveAllFiles.Name = "btn_RemoveAllFiles";
            this.btn_RemoveAllFiles.Size = new System.Drawing.Size(71, 22);
            this.btn_RemoveAllFiles.TabIndex = 3;
            this.btn_RemoveAllFiles.Text = "Remove all";
            this.btn_RemoveAllFiles.UseVisualStyleBackColor = false;
            this.btn_RemoveAllFiles.Click += new System.EventHandler(this.btn_RemoveAllFiles_Click);
            // 
            // btn_RemoveFile
            // 
            this.btn_RemoveFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btn_RemoveFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_RemoveFile.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_RemoveFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.btn_RemoveFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btn_RemoveFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_RemoveFile.ForeColor = System.Drawing.Color.White;
            this.btn_RemoveFile.Location = new System.Drawing.Point(362, 6);
            this.btn_RemoveFile.Name = "btn_RemoveFile";
            this.btn_RemoveFile.Size = new System.Drawing.Size(58, 22);
            this.btn_RemoveFile.TabIndex = 2;
            this.btn_RemoveFile.Text = "Remove";
            this.btn_RemoveFile.UseVisualStyleBackColor = false;
            this.btn_RemoveFile.Click += new System.EventHandler(this.btn_RemoveFile_Click);
            // 
            // btn_RemoveAllFolders
            // 
            this.btn_RemoveAllFolders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btn_RemoveAllFolders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_RemoveAllFolders.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_RemoveAllFolders.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.btn_RemoveAllFolders.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btn_RemoveAllFolders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_RemoveAllFolders.ForeColor = System.Drawing.Color.White;
            this.btn_RemoveAllFolders.Location = new System.Drawing.Point(169, 7);
            this.btn_RemoveAllFolders.Name = "btn_RemoveAllFolders";
            this.btn_RemoveAllFolders.Size = new System.Drawing.Size(71, 22);
            this.btn_RemoveAllFolders.TabIndex = 8;
            this.btn_RemoveAllFolders.Text = "Remove all";
            this.btn_RemoveAllFolders.UseVisualStyleBackColor = false;
            this.btn_RemoveAllFolders.Click += new System.EventHandler(this.btn_RemoveAllFolders_Click);
            // 
            // btn_RemoveFolder
            // 
            this.btn_RemoveFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btn_RemoveFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_RemoveFolder.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_RemoveFolder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.btn_RemoveFolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btn_RemoveFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_RemoveFolder.ForeColor = System.Drawing.Color.White;
            this.btn_RemoveFolder.Location = new System.Drawing.Point(105, 7);
            this.btn_RemoveFolder.Name = "btn_RemoveFolder";
            this.btn_RemoveFolder.Size = new System.Drawing.Size(58, 22);
            this.btn_RemoveFolder.TabIndex = 7;
            this.btn_RemoveFolder.Text = "Remove";
            this.btn_RemoveFolder.UseVisualStyleBackColor = false;
            this.btn_RemoveFolder.Click += new System.EventHandler(this.btn_RemoveFolder_Click);
            // 
            // btn_ChkInvFiles
            // 
            this.btn_ChkInvFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btn_ChkInvFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ChkInvFiles.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_ChkInvFiles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.btn_ChkInvFiles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btn_ChkInvFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ChkInvFiles.ForeColor = System.Drawing.Color.White;
            this.btn_ChkInvFiles.Location = new System.Drawing.Point(653, 6);
            this.btn_ChkInvFiles.Name = "btn_ChkInvFiles";
            this.btn_ChkInvFiles.Size = new System.Drawing.Size(86, 22);
            this.btn_ChkInvFiles.TabIndex = 6;
            this.btn_ChkInvFiles.Text = "Check inverse";
            this.btn_ChkInvFiles.UseVisualStyleBackColor = false;
            this.btn_ChkInvFiles.Click += new System.EventHandler(this.btn_ChkInvFiles_Click);
            // 
            // btn_ChkNoneFiles
            // 
            this.btn_ChkNoneFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btn_ChkNoneFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ChkNoneFiles.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_ChkNoneFiles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.btn_ChkNoneFiles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btn_ChkNoneFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ChkNoneFiles.ForeColor = System.Drawing.Color.White;
            this.btn_ChkNoneFiles.Location = new System.Drawing.Point(571, 6);
            this.btn_ChkNoneFiles.Name = "btn_ChkNoneFiles";
            this.btn_ChkNoneFiles.Size = new System.Drawing.Size(76, 22);
            this.btn_ChkNoneFiles.TabIndex = 5;
            this.btn_ChkNoneFiles.Text = "Check none";
            this.btn_ChkNoneFiles.UseVisualStyleBackColor = false;
            this.btn_ChkNoneFiles.Click += new System.EventHandler(this.btn_ChkNoneFiles_Click);
            // 
            // btn_ChkAllFiles
            // 
            this.btn_ChkAllFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btn_ChkAllFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ChkAllFiles.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_ChkAllFiles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.btn_ChkAllFiles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btn_ChkAllFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ChkAllFiles.ForeColor = System.Drawing.Color.White;
            this.btn_ChkAllFiles.Location = new System.Drawing.Point(503, 6);
            this.btn_ChkAllFiles.Name = "btn_ChkAllFiles";
            this.btn_ChkAllFiles.Size = new System.Drawing.Size(62, 22);
            this.btn_ChkAllFiles.TabIndex = 4;
            this.btn_ChkAllFiles.Text = "Check all";
            this.btn_ChkAllFiles.UseVisualStyleBackColor = false;
            this.btn_ChkAllFiles.Click += new System.EventHandler(this.btn_ChkAllFiles_Click);
            // 
            // btn_ChkInvFolders
            // 
            this.btn_ChkInvFolders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btn_ChkInvFolders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ChkInvFolders.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_ChkInvFolders.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.btn_ChkInvFolders.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btn_ChkInvFolders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ChkInvFolders.ForeColor = System.Drawing.Color.White;
            this.btn_ChkInvFolders.Location = new System.Drawing.Point(396, 7);
            this.btn_ChkInvFolders.Name = "btn_ChkInvFolders";
            this.btn_ChkInvFolders.Size = new System.Drawing.Size(86, 22);
            this.btn_ChkInvFolders.TabIndex = 11;
            this.btn_ChkInvFolders.Text = "Check inverse";
            this.btn_ChkInvFolders.UseVisualStyleBackColor = false;
            this.btn_ChkInvFolders.Click += new System.EventHandler(this.btn_ChkInvFolders_Click);
            // 
            // btn_ChkNoneFolders
            // 
            this.btn_ChkNoneFolders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btn_ChkNoneFolders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ChkNoneFolders.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_ChkNoneFolders.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.btn_ChkNoneFolders.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btn_ChkNoneFolders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ChkNoneFolders.ForeColor = System.Drawing.Color.White;
            this.btn_ChkNoneFolders.Location = new System.Drawing.Point(314, 7);
            this.btn_ChkNoneFolders.Name = "btn_ChkNoneFolders";
            this.btn_ChkNoneFolders.Size = new System.Drawing.Size(76, 22);
            this.btn_ChkNoneFolders.TabIndex = 10;
            this.btn_ChkNoneFolders.Text = "Check none";
            this.btn_ChkNoneFolders.UseVisualStyleBackColor = false;
            this.btn_ChkNoneFolders.Click += new System.EventHandler(this.btn_ChkNoneFolders_Click);
            // 
            // btn_ChkAllFolders
            // 
            this.btn_ChkAllFolders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btn_ChkAllFolders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ChkAllFolders.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_ChkAllFolders.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.btn_ChkAllFolders.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btn_ChkAllFolders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ChkAllFolders.ForeColor = System.Drawing.Color.White;
            this.btn_ChkAllFolders.Location = new System.Drawing.Point(246, 7);
            this.btn_ChkAllFolders.Name = "btn_ChkAllFolders";
            this.btn_ChkAllFolders.Size = new System.Drawing.Size(62, 22);
            this.btn_ChkAllFolders.TabIndex = 9;
            this.btn_ChkAllFolders.Text = "Check all";
            this.btn_ChkAllFolders.UseVisualStyleBackColor = false;
            this.btn_ChkAllFolders.Click += new System.EventHandler(this.btn_ChkAllFolders_Click);
            // 
            // chk_KeepHeader
            // 
            this.chk_KeepHeader.AutoSize = true;
            this.chk_KeepHeader.Checked = true;
            this.chk_KeepHeader.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_KeepHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chk_KeepHeader.Location = new System.Drawing.Point(5, 14);
            this.chk_KeepHeader.Name = "chk_KeepHeader";
            this.chk_KeepHeader.Size = new System.Drawing.Size(120, 17);
            this.chk_KeepHeader.TabIndex = 21;
            this.chk_KeepHeader.Text = "Keep log file header";
            this.toolTips.SetToolTip(this.chk_KeepHeader, "Keep the first line of the log file that contains header info.");
            this.chk_KeepHeader.UseVisualStyleBackColor = true;
            // 
            // chk_ParseReqRes
            // 
            this.chk_ParseReqRes.AutoSize = true;
            this.chk_ParseReqRes.Checked = true;
            this.chk_ParseReqRes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_ParseReqRes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chk_ParseReqRes.Location = new System.Drawing.Point(131, 14);
            this.chk_ParseReqRes.Name = "chk_ParseReqRes";
            this.chk_ParseReqRes.Size = new System.Drawing.Size(191, 17);
            this.chk_ParseReqRes.TabIndex = 22;
            this.chk_ParseReqRes.Text = "Parse request and response strings";
            this.toolTips.SetToolTip(this.chk_ParseReqRes, "If checked, the request and response fields (that came as string), will be parsed" +
        " as JSON objects.\r\nThey should be in the \'customMsgAtts\' property.\r\nOtherwise, t" +
        "hey will remain as a string.");
            this.chk_ParseReqRes.UseVisualStyleBackColor = true;
            // 
            // chk_Indent
            // 
            this.chk_Indent.AutoSize = true;
            this.chk_Indent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chk_Indent.Location = new System.Drawing.Point(430, 14);
            this.chk_Indent.Name = "chk_Indent";
            this.chk_Indent.Size = new System.Drawing.Size(87, 17);
            this.chk_Indent.TabIndex = 24;
            this.chk_Indent.Text = "Indent JSON";
            this.toolTips.SetToolTip(this.chk_Indent, "If checked, the JSON data will be indented.\r\nRecommended to be disabled to save f" +
        "ile space.");
            this.chk_Indent.UseVisualStyleBackColor = true;
            // 
            // chk_Overwrite
            // 
            this.chk_Overwrite.AutoSize = true;
            this.chk_Overwrite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chk_Overwrite.Location = new System.Drawing.Point(523, 14);
            this.chk_Overwrite.Name = "chk_Overwrite";
            this.chk_Overwrite.Size = new System.Drawing.Size(125, 17);
            this.chk_Overwrite.TabIndex = 25;
            this.chk_Overwrite.Text = "Overwrite output files";
            this.toolTips.SetToolTip(this.chk_Overwrite, "If checked and the output file already exists, it will be overwritten.\r\nOtherwise" +
        ", a new file will be created.");
            this.chk_Overwrite.UseVisualStyleBackColor = true;
            // 
            // cmb_FolderFilter
            // 
            this.cmb_FolderFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.cmb_FolderFilter.ForeColor = System.Drawing.Color.White;
            this.cmb_FolderFilter.FormattingEnabled = true;
            this.cmb_FolderFilter.Items.AddRange(new object[] {
            "*.log",
            "*.txt",
            "*.*"});
            this.cmb_FolderFilter.Location = new System.Drawing.Point(538, 8);
            this.cmb_FolderFilter.Name = "cmb_FolderFilter";
            this.cmb_FolderFilter.Size = new System.Drawing.Size(90, 21);
            this.cmb_FolderFilter.TabIndex = 12;
            this.cmb_FolderFilter.Text = "*.log";
            this.toolTips.SetToolTip(this.cmb_FolderFilter, "Only files with this extension will be processed.");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(487, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Filter files:";
            // 
            // pnl_FILES
            // 
            this.pnl_FILES.AllowDrop = true;
            this.pnl_FILES.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_FILES.Controls.Add(this.clb_Files);
            this.pnl_FILES.Controls.Add(this.lbl_FilesInfo);
            this.pnl_FILES.Controls.Add(this.btn_RemoveFile);
            this.pnl_FILES.Controls.Add(this.btn_RemoveAllFiles);
            this.pnl_FILES.Controls.Add(this.btn_ChkAllFiles);
            this.pnl_FILES.Controls.Add(this.btn_ChkNoneFiles);
            this.pnl_FILES.Controls.Add(this.btn_ChkInvFiles);
            this.pnl_FILES.Location = new System.Drawing.Point(12, 12);
            this.pnl_FILES.Name = "pnl_FILES";
            this.pnl_FILES.Size = new System.Drawing.Size(747, 160);
            this.pnl_FILES.TabIndex = 16;
            this.pnl_FILES.DragEnter += new System.Windows.Forms.DragEventHandler(this.GeneralDragENTER);
            // 
            // pnl_FOLDERS
            // 
            this.pnl_FOLDERS.AllowDrop = true;
            this.pnl_FOLDERS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_FOLDERS.Controls.Add(this.clb_Folders);
            this.pnl_FOLDERS.Controls.Add(this.chk_IncludeSubfolders);
            this.pnl_FOLDERS.Controls.Add(this.lbl_FoldersInfo);
            this.pnl_FOLDERS.Controls.Add(this.cmb_FolderFilter);
            this.pnl_FOLDERS.Controls.Add(this.label1);
            this.pnl_FOLDERS.Controls.Add(this.btn_RemoveFolder);
            this.pnl_FOLDERS.Controls.Add(this.btn_RemoveAllFolders);
            this.pnl_FOLDERS.Controls.Add(this.btn_ChkAllFolders);
            this.pnl_FOLDERS.Controls.Add(this.btn_ChkNoneFolders);
            this.pnl_FOLDERS.Controls.Add(this.btn_ChkInvFolders);
            this.pnl_FOLDERS.Location = new System.Drawing.Point(12, 188);
            this.pnl_FOLDERS.Name = "pnl_FOLDERS";
            this.pnl_FOLDERS.Size = new System.Drawing.Size(747, 161);
            this.pnl_FOLDERS.TabIndex = 16;
            this.pnl_FOLDERS.DragEnter += new System.Windows.Forms.DragEventHandler(this.GeneralDragENTER);
            // 
            // chk_IncludeSubfolders
            // 
            this.chk_IncludeSubfolders.AutoSize = true;
            this.chk_IncludeSubfolders.Checked = true;
            this.chk_IncludeSubfolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_IncludeSubfolders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chk_IncludeSubfolders.Location = new System.Drawing.Point(633, 11);
            this.chk_IncludeSubfolders.Name = "chk_IncludeSubfolders";
            this.chk_IncludeSubfolders.Size = new System.Drawing.Size(112, 17);
            this.chk_IncludeSubfolders.TabIndex = 13;
            this.chk_IncludeSubfolders.Text = "Include subfolders";
            this.chk_IncludeSubfolders.UseVisualStyleBackColor = true;
            // 
            // pnl_OPTIONS
            // 
            this.pnl_OPTIONS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_OPTIONS.Controls.Add(this.btn_WORK);
            this.pnl_OPTIONS.Controls.Add(this.chk_KeepHeader);
            this.pnl_OPTIONS.Controls.Add(this.chk_ParseReqRes);
            this.pnl_OPTIONS.Controls.Add(this.chk_SaveAsJSON);
            this.pnl_OPTIONS.Controls.Add(this.chk_Indent);
            this.pnl_OPTIONS.Controls.Add(this.chk_Overwrite);
            this.pnl_OPTIONS.Location = new System.Drawing.Point(12, 364);
            this.pnl_OPTIONS.Name = "pnl_OPTIONS";
            this.pnl_OPTIONS.Size = new System.Drawing.Size(747, 43);
            this.pnl_OPTIONS.TabIndex = 17;
            this.pnl_OPTIONS.DragEnter += new System.Windows.Forms.DragEventHandler(this.GeneralDragENTER);
            // 
            // btn_WORK
            // 
            this.btn_WORK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btn_WORK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_WORK.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_WORK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.btn_WORK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btn_WORK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_WORK.ForeColor = System.Drawing.Color.White;
            this.btn_WORK.Location = new System.Drawing.Point(675, 9);
            this.btn_WORK.Name = "btn_WORK";
            this.btn_WORK.Size = new System.Drawing.Size(62, 24);
            this.btn_WORK.TabIndex = 26;
            this.btn_WORK.Text = "R U N !";
            this.toolTips.SetToolTip(this.btn_WORK, "The output files will be saved in the same location as the original files.");
            this.btn_WORK.UseVisualStyleBackColor = false;
            this.btn_WORK.Click += new System.EventHandler(this.btn_WORK_Click);
            // 
            // chk_SaveAsJSON
            // 
            this.chk_SaveAsJSON.AutoSize = true;
            this.chk_SaveAsJSON.Checked = true;
            this.chk_SaveAsJSON.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_SaveAsJSON.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chk_SaveAsJSON.Location = new System.Drawing.Point(328, 14);
            this.chk_SaveAsJSON.Name = "chk_SaveAsJSON";
            this.chk_SaveAsJSON.Size = new System.Drawing.Size(96, 17);
            this.chk_SaveAsJSON.TabIndex = 23;
            this.chk_SaveAsJSON.Text = "Save as JSON";
            this.toolTips.SetToolTip(this.chk_SaveAsJSON, "If checked, the output files will have the .json extension.\r\nOtherwise, the origi" +
        "nal extension will be used.");
            this.chk_SaveAsJSON.UseVisualStyleBackColor = true;
            // 
            // pnl_STATUS
            // 
            this.pnl_STATUS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_STATUS.Controls.Add(this.btn_CancelWork);
            this.pnl_STATUS.Controls.Add(this.lbl_Status);
            this.pnl_STATUS.Location = new System.Drawing.Point(12, 364);
            this.pnl_STATUS.Name = "pnl_STATUS";
            this.pnl_STATUS.Size = new System.Drawing.Size(747, 43);
            this.pnl_STATUS.TabIndex = 18;
            this.pnl_STATUS.Visible = false;
            // 
            // btn_CancelWork
            // 
            this.btn_CancelWork.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btn_CancelWork.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CancelWork.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_CancelWork.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.btn_CancelWork.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btn_CancelWork.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CancelWork.ForeColor = System.Drawing.Color.White;
            this.btn_CancelWork.Location = new System.Drawing.Point(689, 8);
            this.btn_CancelWork.Name = "btn_CancelWork";
            this.btn_CancelWork.Size = new System.Drawing.Size(51, 24);
            this.btn_CancelWork.TabIndex = 15;
            this.btn_CancelWork.Text = "Cancel";
            this.btn_CancelWork.UseVisualStyleBackColor = false;
            this.btn_CancelWork.Click += new System.EventHandler(this.btn_CancelWork_Click);
            // 
            // lbl_Status
            // 
            this.lbl_Status.AutoSize = true;
            this.lbl_Status.ForeColor = System.Drawing.Color.White;
            this.lbl_Status.Location = new System.Drawing.Point(9, 13);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(10, 13);
            this.lbl_Status.TabIndex = 3;
            this.lbl_Status.Text = "-";
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.WorkerSupportsCancellation = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // toolTips
            // 
            this.toolTips.AutomaticDelay = 26;
            this.toolTips.AutoPopDelay = 26000;
            this.toolTips.InitialDelay = 260;
            this.toolTips.ReshowDelay = 100;
            this.toolTips.ShowAlways = true;
            this.toolTips.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTips.ToolTipTitle = "ALEx";
            // 
            // txt_FilterString
            // 
            this.txt_FilterString.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.txt_FilterString.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_FilterString.ForeColor = System.Drawing.Color.White;
            this.txt_FilterString.Location = new System.Drawing.Point(6, 63);
            this.txt_FilterString.Name = "txt_FilterString";
            this.txt_FilterString.Size = new System.Drawing.Size(241, 20);
            this.txt_FilterString.TabIndex = 15;
            this.toolTips.SetToolTip(this.txt_FilterString, "Double-click the textbox to add a filter with your clipboard data.");
            this.txt_FilterString.DoubleClick += new System.EventHandler(this.txt_FilterString_DoubleClick);
            this.txt_FilterString.MouseEnter += new System.EventHandler(this.txt_FilterString_MouseEnter);
            this.txt_FilterString.MouseLeave += new System.EventHandler(this.txt_FilterString_MouseLeave);
            // 
            // cmb_OpenReportWith
            // 
            this.cmb_OpenReportWith.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_OpenReportWith.Enabled = false;
            this.cmb_OpenReportWith.FormattingEnabled = true;
            this.cmb_OpenReportWith.Location = new System.Drawing.Point(117, 11);
            this.cmb_OpenReportWith.Name = "cmb_OpenReportWith";
            this.cmb_OpenReportWith.Size = new System.Drawing.Size(152, 21);
            this.cmb_OpenReportWith.TabIndex = 28;
            this.toolTips.SetToolTip(this.cmb_OpenReportWith, resources.GetString("cmb_OpenReportWith.ToolTip"));
            // 
            // chk_OpenReport
            // 
            this.chk_OpenReport.AutoSize = true;
            this.chk_OpenReport.ForeColor = System.Drawing.Color.White;
            this.chk_OpenReport.Location = new System.Drawing.Point(6, 13);
            this.chk_OpenReport.Name = "chk_OpenReport";
            this.chk_OpenReport.Size = new System.Drawing.Size(111, 17);
            this.chk_OpenReport.TabIndex = 27;
            this.chk_OpenReport.Text = "Open the report in";
            this.toolTips.SetToolTip(this.chk_OpenReport, resources.GetString("chk_OpenReport.ToolTip"));
            this.chk_OpenReport.UseVisualStyleBackColor = true;
            this.chk_OpenReport.CheckedChanged += new System.EventHandler(this.chk_OpenReport_CheckedChanged);
            // 
            // chk_CopyReportToCB
            // 
            this.chk_CopyReportToCB.AutoSize = true;
            this.chk_CopyReportToCB.ForeColor = System.Drawing.Color.White;
            this.chk_CopyReportToCB.Location = new System.Drawing.Point(6, 13);
            this.chk_CopyReportToCB.Name = "chk_CopyReportToCB";
            this.chk_CopyReportToCB.Size = new System.Drawing.Size(183, 17);
            this.chk_CopyReportToCB.TabIndex = 27;
            this.chk_CopyReportToCB.Text = "Copy the report to clipboard auto.";
            this.toolTips.SetToolTip(this.chk_CopyReportToCB, resources.GetString("chk_CopyReportToCB.ToolTip"));
            this.chk_CopyReportToCB.UseVisualStyleBackColor = true;
            this.chk_CopyReportToCB.Visible = false;
            // 
            // lbl_FilteringModeHelp
            // 
            this.lbl_FilteringModeHelp.AutoSize = true;
            this.lbl_FilteringModeHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_FilteringModeHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FilteringModeHelp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbl_FilteringModeHelp.Location = new System.Drawing.Point(146, 313);
            this.lbl_FilteringModeHelp.Name = "lbl_FilteringModeHelp";
            this.lbl_FilteringModeHelp.Size = new System.Drawing.Size(13, 13);
            this.lbl_FilteringModeHelp.TabIndex = 34;
            this.lbl_FilteringModeHelp.Text = "?";
            this.toolTips.SetToolTip(this.lbl_FilteringModeHelp, "Click here to learn more about the filtering modes.");
            this.lbl_FilteringModeHelp.Click += new System.EventHandler(this.lbl_FilteringModeHelp_Click);
            // 
            // pnl_FILTERS
            // 
            this.pnl_FILTERS.AllowDrop = true;
            this.pnl_FILTERS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_FILTERS.Controls.Add(this.cmb_FilteringMode);
            this.pnl_FILTERS.Controls.Add(this.lbl_FilteringModeHelp);
            this.pnl_FILTERS.Controls.Add(this.label3);
            this.pnl_FILTERS.Controls.Add(this.lbl_StringFilterTitle);
            this.pnl_FILTERS.Controls.Add(this.cmb_FilterType);
            this.pnl_FILTERS.Controls.Add(this.label14);
            this.pnl_FILTERS.Controls.Add(this.label2);
            this.pnl_FILTERS.Controls.Add(this.lbl_FiltersInfo);
            this.pnl_FILTERS.Controls.Add(this.lbl_StringFilterSubtitle);
            this.pnl_FILTERS.Controls.Add(this.txt_FilterString);
            this.pnl_FILTERS.Controls.Add(this.btn_AddFilter);
            this.pnl_FILTERS.Controls.Add(this.btn_DelAllFilters);
            this.pnl_FILTERS.Controls.Add(this.btn_DelSelFilter);
            this.pnl_FILTERS.Controls.Add(this.dgv_Filters);
            this.pnl_FILTERS.Location = new System.Drawing.Point(771, 12);
            this.pnl_FILTERS.Name = "pnl_FILTERS";
            this.pnl_FILTERS.Size = new System.Drawing.Size(404, 337);
            this.pnl_FILTERS.TabIndex = 19;
            this.pnl_FILTERS.DragEnter += new System.Windows.Forms.DragEventHandler(this.GeneralDragENTER);
            // 
            // cmb_FilteringMode
            // 
            this.cmb_FilteringMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.cmb_FilteringMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_FilteringMode.ForeColor = System.Drawing.Color.White;
            this.cmb_FilteringMode.FormattingEnabled = true;
            this.cmb_FilteringMode.Items.AddRange(new object[] {
            "Strict",
            "Union"});
            this.cmb_FilteringMode.Location = new System.Drawing.Point(80, 309);
            this.cmb_FilteringMode.Name = "cmb_FilteringMode";
            this.cmb_FilteringMode.Size = new System.Drawing.Size(62, 21);
            this.cmb_FilteringMode.TabIndex = 33;
            this.cmb_FilteringMode.SelectedIndexChanged += new System.EventHandler(this.cmb_FilteringMode_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(4, 313);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Filtering mode:";
            // 
            // lbl_StringFilterTitle
            // 
            this.lbl_StringFilterTitle.AutoSize = true;
            this.lbl_StringFilterTitle.ForeColor = System.Drawing.Color.Silver;
            this.lbl_StringFilterTitle.Location = new System.Drawing.Point(3, 48);
            this.lbl_StringFilterTitle.Name = "lbl_StringFilterTitle";
            this.lbl_StringFilterTitle.Size = new System.Drawing.Size(171, 13);
            this.lbl_StringFilterTitle.TabIndex = 32;
            this.lbl_StringFilterTitle.Text = "String to look for (case insensitive):";
            // 
            // cmb_FilterType
            // 
            this.cmb_FilterType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.cmb_FilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_FilterType.ForeColor = System.Drawing.Color.White;
            this.cmb_FilterType.FormattingEnabled = true;
            this.cmb_FilterType.Items.AddRange(new object[] {
            "Contains",
            "Doesn\'t contain"});
            this.cmb_FilterType.Location = new System.Drawing.Point(253, 61);
            this.cmb_FilterType.Name = "cmb_FilterType";
            this.cmb_FilterType.Size = new System.Drawing.Size(98, 21);
            this.cmb_FilterType.TabIndex = 16;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Silver;
            this.label14.Location = new System.Drawing.Point(250, 45);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "Filter type:";
            // 
            // label2
            // 
            this.label2.AllowDrop = true;
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(394, 28);
            this.label2.TabIndex = 32;
            this.label2.Text = "Transactions filters - use this section to filter through all transactions within" +
    " the log files. Insert strings (text) and select types for them (contains or doe" +
    "sn\'t contain).";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.DragEnter += new System.Windows.Forms.DragEventHandler(this.GeneralDragENTER);
            // 
            // lbl_FiltersInfo
            // 
            this.lbl_FiltersInfo.ForeColor = System.Drawing.Color.Silver;
            this.lbl_FiltersInfo.Location = new System.Drawing.Point(165, 308);
            this.lbl_FiltersInfo.Name = "lbl_FiltersInfo";
            this.lbl_FiltersInfo.Size = new System.Drawing.Size(65, 22);
            this.lbl_FiltersInfo.TabIndex = 32;
            this.lbl_FiltersInfo.Text = "Filters: 0";
            this.lbl_FiltersInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_StringFilterSubtitle
            // 
            this.lbl_StringFilterSubtitle.AutoSize = true;
            this.lbl_StringFilterSubtitle.ForeColor = System.Drawing.Color.Silver;
            this.lbl_StringFilterSubtitle.Location = new System.Drawing.Point(3, 48);
            this.lbl_StringFilterSubtitle.Name = "lbl_StringFilterSubtitle";
            this.lbl_StringFilterSubtitle.Size = new System.Drawing.Size(115, 13);
            this.lbl_StringFilterSubtitle.TabIndex = 32;
            this.lbl_StringFilterSubtitle.Text = "Please read the tooltip.";
            this.lbl_StringFilterSubtitle.Visible = false;
            // 
            // btn_AddFilter
            // 
            this.btn_AddFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btn_AddFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AddFilter.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_AddFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btn_AddFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_AddFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddFilter.ForeColor = System.Drawing.Color.White;
            this.btn_AddFilter.Location = new System.Drawing.Point(357, 60);
            this.btn_AddFilter.Name = "btn_AddFilter";
            this.btn_AddFilter.Size = new System.Drawing.Size(39, 22);
            this.btn_AddFilter.TabIndex = 17;
            this.btn_AddFilter.Text = "Add";
            this.btn_AddFilter.UseVisualStyleBackColor = false;
            this.btn_AddFilter.Click += new System.EventHandler(this.btn_AddFilter_Click);
            // 
            // btn_DelAllFilters
            // 
            this.btn_DelAllFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btn_DelAllFilters.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DelAllFilters.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_DelAllFilters.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btn_DelAllFilters.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_DelAllFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DelAllFilters.ForeColor = System.Drawing.Color.White;
            this.btn_DelAllFilters.Location = new System.Drawing.Point(334, 308);
            this.btn_DelAllFilters.Name = "btn_DelAllFilters";
            this.btn_DelAllFilters.Size = new System.Drawing.Size(62, 22);
            this.btn_DelAllFilters.TabIndex = 20;
            this.btn_DelAllFilters.Text = "Delete all";
            this.btn_DelAllFilters.UseVisualStyleBackColor = false;
            this.btn_DelAllFilters.Click += new System.EventHandler(this.btn_DelAllFilters_Click);
            // 
            // btn_DelSelFilter
            // 
            this.btn_DelSelFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btn_DelSelFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DelSelFilter.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_DelSelFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btn_DelSelFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_DelSelFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DelSelFilter.ForeColor = System.Drawing.Color.White;
            this.btn_DelSelFilter.Location = new System.Drawing.Point(236, 308);
            this.btn_DelSelFilter.Name = "btn_DelSelFilter";
            this.btn_DelSelFilter.Size = new System.Drawing.Size(92, 22);
            this.btn_DelSelFilter.TabIndex = 19;
            this.btn_DelSelFilter.Text = "Delete selected";
            this.btn_DelSelFilter.UseVisualStyleBackColor = false;
            this.btn_DelSelFilter.Click += new System.EventHandler(this.btn_DelSelFilter_Click);
            // 
            // dgv_Filters
            // 
            this.dgv_Filters.AllowDrop = true;
            this.dgv_Filters.AllowUserToAddRows = false;
            this.dgv_Filters.AllowUserToDeleteRows = false;
            this.dgv_Filters.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_Filters.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Filters.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.dgv_Filters.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Filters.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Filters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Filters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.String,
            this.Type});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Filters.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Filters.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_Filters.EnableHeadersVisualStyles = false;
            this.dgv_Filters.Location = new System.Drawing.Point(6, 88);
            this.dgv_Filters.MultiSelect = false;
            this.dgv_Filters.Name = "dgv_Filters";
            this.dgv_Filters.ReadOnly = true;
            this.dgv_Filters.RowHeadersVisible = false;
            this.dgv_Filters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Filters.Size = new System.Drawing.Size(390, 214);
            this.dgv_Filters.TabIndex = 18;
            this.dgv_Filters.DragEnter += new System.Windows.Forms.DragEventHandler(this.GeneralDragENTER);
            // 
            // String
            // 
            this.String.HeaderText = "String";
            this.String.Name = "String";
            this.String.ReadOnly = true;
            this.String.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.String.Width = 245;
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Type.Width = 120;
            // 
            // pnl_REPORT
            // 
            this.pnl_REPORT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnl_REPORT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_REPORT.Controls.Add(this.bnt_OpenLastReport);
            this.pnl_REPORT.Controls.Add(this.cmb_OpenReportWith);
            this.pnl_REPORT.Controls.Add(this.chk_OpenReport);
            this.pnl_REPORT.Controls.Add(this.chk_CopyReportToCB);
            this.pnl_REPORT.Controls.Add(this.btn_CopyLastReport);
            this.pnl_REPORT.Location = new System.Drawing.Point(771, 364);
            this.pnl_REPORT.Name = "pnl_REPORT";
            this.pnl_REPORT.Size = new System.Drawing.Size(404, 43);
            this.pnl_REPORT.TabIndex = 0;
            this.pnl_REPORT.DragEnter += new System.Windows.Forms.DragEventHandler(this.GeneralDragENTER);
            // 
            // bnt_OpenLastReport
            // 
            this.bnt_OpenLastReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.bnt_OpenLastReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bnt_OpenLastReport.Enabled = false;
            this.bnt_OpenLastReport.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.bnt_OpenLastReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.bnt_OpenLastReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.bnt_OpenLastReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnt_OpenLastReport.ForeColor = System.Drawing.Color.White;
            this.bnt_OpenLastReport.Location = new System.Drawing.Point(281, 9);
            this.bnt_OpenLastReport.Name = "bnt_OpenLastReport";
            this.bnt_OpenLastReport.Size = new System.Drawing.Size(115, 24);
            this.bnt_OpenLastReport.TabIndex = 29;
            this.bnt_OpenLastReport.Text = "Open the last report";
            this.bnt_OpenLastReport.UseVisualStyleBackColor = false;
            this.bnt_OpenLastReport.Click += new System.EventHandler(this.bnt_OpenLastReport_Click);
            // 
            // btn_CopyLastReport
            // 
            this.btn_CopyLastReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btn_CopyLastReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CopyLastReport.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_CopyLastReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.btn_CopyLastReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btn_CopyLastReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CopyLastReport.ForeColor = System.Drawing.Color.White;
            this.btn_CopyLastReport.Location = new System.Drawing.Point(203, 9);
            this.btn_CopyLastReport.Name = "btn_CopyLastReport";
            this.btn_CopyLastReport.Size = new System.Drawing.Size(193, 24);
            this.btn_CopyLastReport.TabIndex = 29;
            this.btn_CopyLastReport.Text = "Copy the last report to the clipboard";
            this.btn_CopyLastReport.UseVisualStyleBackColor = false;
            this.btn_CopyLastReport.Visible = false;
            this.btn_CopyLastReport.Click += new System.EventHandler(this.btn_CopyLastReport_Click);
            // 
            // tmr_Pulse
            // 
            this.tmr_Pulse.Interval = 500;
            this.tmr_Pulse.Tick += new System.EventHandler(this.tmr_Pulse_Tick);
            // 
            // frm_Main
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1186, 418);
            this.Controls.Add(this.pnl_REPORT);
            this.Controls.Add(this.pnl_FILTERS);
            this.Controls.Add(this.pnl_OPTIONS);
            this.Controls.Add(this.pnl_FOLDERS);
            this.Controls.Add(this.pnl_FILES);
            this.Controls.Add(this.pnl_STATUS);
            this.Controls.Add(this.pnl_DragDrop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_Main";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ALEx (Axway Logs Extractor) - AvA.Soft";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Main_FormClosing);
            this.Load += new System.EventHandler(this.frm_Main_Load);
            this.Shown += new System.EventHandler(this.frm_Main_Shown);
            this.DoubleClick += new System.EventHandler(this.frm_Main_DoubleClick);
            this.pnl_DragDrop.ResumeLayout(false);
            this.pnl_FILES.ResumeLayout(false);
            this.pnl_FILES.PerformLayout();
            this.pnl_FOLDERS.ResumeLayout(false);
            this.pnl_FOLDERS.PerformLayout();
            this.pnl_OPTIONS.ResumeLayout(false);
            this.pnl_OPTIONS.PerformLayout();
            this.pnl_STATUS.ResumeLayout(false);
            this.pnl_STATUS.PerformLayout();
            this.pnl_FILTERS.ResumeLayout(false);
            this.pnl_FILTERS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Filters)).EndInit();
            this.pnl_REPORT.ResumeLayout(false);
            this.pnl_REPORT.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clb_Files;
        private System.Windows.Forms.CheckedListBox clb_Folders;
        private System.Windows.Forms.Panel pnl_DragDrop;
        private System.Windows.Forms.Label lbl_FilesInfo;
        private System.Windows.Forms.Label lbl_FoldersInfo;
        private System.Windows.Forms.Button btn_RemoveAllFiles;
        private System.Windows.Forms.Button btn_RemoveFile;
        private System.Windows.Forms.Button btn_RemoveAllFolders;
        private System.Windows.Forms.Button btn_RemoveFolder;
        private System.Windows.Forms.Button btn_ChkInvFiles;
        private System.Windows.Forms.Button btn_ChkNoneFiles;
        private System.Windows.Forms.Button btn_ChkAllFiles;
        private System.Windows.Forms.Button btn_ChkInvFolders;
        private System.Windows.Forms.Button btn_ChkNoneFolders;
        private System.Windows.Forms.Button btn_ChkAllFolders;
        private System.Windows.Forms.CheckBox chk_KeepHeader;
        private System.Windows.Forms.CheckBox chk_ParseReqRes;
        private System.Windows.Forms.CheckBox chk_Indent;
        private System.Windows.Forms.CheckBox chk_Overwrite;
        private System.Windows.Forms.ComboBox cmb_FolderFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnl_FILES;
        private System.Windows.Forms.Panel pnl_FOLDERS;
        private System.Windows.Forms.Panel pnl_OPTIONS;
        private System.Windows.Forms.Button btn_WORK;
        private System.Windows.Forms.CheckBox chk_IncludeSubfolders;
        private System.Windows.Forms.Panel pnl_STATUS;
        private System.Windows.Forms.Button btn_CancelWork;
        private System.Windows.Forms.Label lbl_Status;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.CheckBox chk_SaveAsJSON;
        private System.Windows.Forms.ToolTip toolTips;
        private System.Windows.Forms.Panel pnl_FILTERS;
        private System.Windows.Forms.DataGridView dgv_Filters;
        private System.Windows.Forms.Button btn_DelAllFilters;
        private System.Windows.Forms.Button btn_DelSelFilter;
        private System.Windows.Forms.ComboBox cmb_FilterType;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbl_StringFilterTitle;
        private System.Windows.Forms.TextBox txt_FilterString;
        private System.Windows.Forms.Button btn_AddFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_FiltersInfo;
        private System.Windows.Forms.Label lbl_StringFilterSubtitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn String;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.Panel pnl_REPORT;
        private System.Windows.Forms.CheckBox chk_OpenReport;
        private System.Windows.Forms.ComboBox cmb_OpenReportWith;
        private System.Windows.Forms.CheckBox chk_CopyReportToCB;
        private System.Windows.Forms.Button bnt_OpenLastReport;
        private System.Windows.Forms.ComboBox cmb_FilteringMode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_FilteringModeHelp;
        private System.Windows.Forms.Button btn_CopyLastReport;
        private System.Windows.Forms.Timer tmr_Pulse;
        private System.Windows.Forms.Label lbl_DragDropStuck;
    }
}

