using ALEx.Models;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ALEx.Classes
{
    public class Helpers
    {
        public static (bool created, string filePath) CreateTempFile(string path, string fileName = "temp_file.txt", string fileData = "")
        {
            if (string.IsNullOrEmpty(fileName)) { return (false, ""); }
            if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }
            if (!path.EndsWith("\\")) { path += "\\"; }
            FileStream fileStream = new FileStream(path + fileName, FileMode.Create, FileAccess.Write);
            using (StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
            {
                streamWriter.Write(fileData);
                streamWriter.Flush();
                streamWriter.Close();
            }
            return (File.Exists(fileStream.Name), fileStream.Name);
        }

        public static List<TextEditor> GetTextEditors(bool onlyExisting = true)
        {
            List<TextEditor> textEditors = new List<TextEditor>();

            #region VS Code
            string vsCodeReg = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Classes\vscode\shell\open\command", "", "").ToStringSafely();
            MatchCollection vscMatches = Regex.Matches(vsCodeReg, @"""(.*Code\.exe)""");
            if (vscMatches.Count == 1)
            {
                string vscPath = vscMatches[0].Groups[1].Value;
                textEditors.Add(new TextEditor("Visual Studio Code", File.Exists(vscPath), vscPath));
            }
            else
            {
                textEditors.Add(new TextEditor("Visual Studio Code", false));
            }
            #endregion

            #region Sublime
            string sublimeReg = Registry.GetValue(@"HKEY_CLASSES_ROOT\*\shell\Open with Sublime Text\command", "", "").ToStringSafely();
            if (!string.IsNullOrEmpty(sublimeReg) && sublimeReg.Contains(".exe"))
            { sublimeReg = sublimeReg.Remove(sublimeReg.LastIndexOf(".exe")) + ".exe"; }
            textEditors.Add(new TextEditor("Sublime Text", File.Exists(sublimeReg), sublimeReg));
            #endregion

            #region Notepad++
            RegistryKey localRegKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
                Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32);
            string nppReg = localRegKey.OpenSubKey(@"SOFTWARE\Notepad++")?.GetValue("").ToStringSafely(addText: "\\notepad++.exe");
            textEditors.Add(new TextEditor("Notepad++", File.Exists(nppReg), nppReg.ToStringSafely()));
            #endregion

            #region Atom
            string atomReg = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Classes\Applications\atom.exe\shell\open\command", "", "").ToStringSafely();
            if (string.IsNullOrEmpty(atomReg))
            { atomReg = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Classes\atom\shell\open\command", "", "").ToStringSafely(); }
            MatchCollection atomMatches = Regex.Matches(atomReg, @"""(.*atom\.exe)""");
            if (atomMatches.Count == 1)
            {
                string atomPath = atomMatches[0].Groups[1].Value;
                int atomLindex = atomPath.LastIndexOf(@"\atom\", StringComparison.InvariantCultureIgnoreCase);
                if (atomLindex > -1)
                {
                    atomPath = atomPath.Remove(atomLindex) + @"\atom\atom.exe";
                }
                textEditors.Add(new TextEditor("Atom", File.Exists(atomPath), atomPath));
            }
            else
            {
                textEditors.Add(new TextEditor("Atom", false));
            }
            #endregion

            #region Notepad
            bool notepadExists = File.Exists($"{Environment.SystemDirectory}\\notepad.exe");
            textEditors.Add(new TextEditor("Microsoft Notepad", notepadExists, $"{Environment.SystemDirectory}\\notepad.exe"));
            #endregion

            if (onlyExisting) { textEditors = textEditors.Where(te => te.Exists).ToList(); }
            return textEditors;
        }

        public static int TryFindLine(ref List<string> dataLines, string stringToFind)
        {
            return dataLines.FindIndex(l => l.Equals(stringToFind));
        }

        public static string GetAppVersion(int fieldCount = 4, bool addVPrefix = true, bool addRuntimeMode = true)
        {
            bool isDebugMode = false;
            if (fieldCount < 1) { fieldCount = 1; }
            if (fieldCount > 4) { fieldCount = 4; }
#if DEBUG
            isDebugMode = true;
#endif
            return (addVPrefix ? "v." : "") + Assembly.GetExecutingAssembly().GetName().Version.ToString(fieldCount) +
                (addRuntimeMode ? (isDebugMode ? "-D" : "-R") : "");
        }
    }

    public static class Extensions
    {
        #region Others
        public static void CheckAllItems(this CheckedListBox clb, bool @checked = true, bool inverse = false)
        {
            for (int i = 0; i < clb.Items.Count; i++)
            {
                clb.SetItemChecked(i, inverse ? !clb.GetItemChecked(i) : @checked);
            }
        }

        public static bool Contains(this DataGridView dataGridView, string col1, string col2)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(col1, StringComparison.OrdinalIgnoreCase) &&
                    row.Cells[1].Value.ToString().Equals(col2, StringComparison.OrdinalIgnoreCase))
                { return true; }
            }
            return false;
        }
        #endregion

        #region String
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source?.IndexOf(toCheck, comp) >= 0;
        }

        public static string ReversePathSlashes(this string source)
        {
            if (string.IsNullOrEmpty(source)) { return ""; }
            return source.Replace(@"\", "/");
        }

        public static (bool isValid, JObject jObject, string validationError) Parse2Json(this string stringData)
        {
            try
            {
                return (true, JObject.Parse(stringData), "");
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message);
            }
        }

        public enum StringRepeatType { Replace = 0, Concat = 1, SBInsert = 2, SBAppendJoin = 3 }
        public static string Repeat(this string str, int times = 2, StringRepeatType repeatType = StringRepeatType.SBInsert)
        {
            switch (repeatType)
            {
                case StringRepeatType.Replace:
                    return new string('X', times).Replace("X", str);

                case StringRepeatType.Concat:
                    return string.Concat(Enumerable.Repeat(str, times));

                default:
                case StringRepeatType.SBInsert:
                    return new StringBuilder(str.Length * times).Insert(0, str, times).ToString();

                case StringRepeatType.SBAppendJoin:
                    return new StringBuilder(str.Length * times).Insert(0, str, times).ToString();
                    //return new StringBuilder(str.Length * times).AppendJoin(str, new string[times + 1]).ToString(); // for .Net >= 5
            }
        }
        //public static string Repeat(this string s, int n = 2) => new StringBuilder(s.Length * n).Insert(0, s, n).ToString();

        public static bool INOE(this string str) => string.IsNullOrEmpty(str);
        #endregion

        #region Boolean
        public static bool Invert(ref this bool boolRef) => boolRef = !boolRef;
        #endregion

        #region Integer
        public static string ToSingOrPlur(this int number, string singular, string plural, bool keepNumber = true)
        {
            if (number < 0) { number = 0; }
            if (number == 1) { return keepNumber ? $"{number} {singular}" : singular; }
            else { return keepNumber ? $"{number} {plural}" : plural; }
        }
        #endregion

        #region Object
        public static string ToStringSafely(this object obj, string addText = "")
        {
            if (obj is null) { return ""; }
            try { return obj.ToString() + addText; }
            catch (Exception) { return ""; }
        }
        #endregion
    }

    public static class NotepadHelper
    {
        [DllImport("user32.dll", EntryPoint = "SetWindowText")]
        private static extern int SetWindowText(IntPtr hWnd, string text);

        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

        public static void ShowMessage(string message = null, string title = null)
        {
            Process notepad = Process.Start(new ProcessStartInfo("notepad.exe"));
            if (notepad != null)
            {
                notepad.WaitForInputIdle();
                if (!string.IsNullOrEmpty(title)) { SetWindowText(notepad.MainWindowHandle, title); }
                if (!string.IsNullOrEmpty(message))
                {
                    IntPtr child = FindWindowEx(notepad.MainWindowHandle, new IntPtr(0), "Edit", null);
                    SendMessage(child, 0x000C, 0, message);
                }
            }
        }
    }

    public static class Serializers
    {
        public static string ToJson(this Report self) => JsonConvert.SerializeObject(self, JSONConverter.Settings);
    }

    public static class JSONConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
