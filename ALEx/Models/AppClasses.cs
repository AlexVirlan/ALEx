using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ALEx.Models
{
    public class PublicVariables
    {
        public enum FilteringMode { Strict = 0, Union = 1 }
    }

    public class FunctionResponse
    {
        public bool Error { get; set; } = false;
        public string Message { get; set; } = "";
        public string StackTrace { get; set; } = "";

        public FunctionResponse() { }

        public FunctionResponse(bool error) => Error = error;

        public FunctionResponse(bool error, string message)
        {
            Error = error;
            Message = message;
        }

        public FunctionResponse(bool error, string message, string stackTrace)
        {
            Error = error;
            Message = message;
            StackTrace = stackTrace;
        }
    }

    public class LogFilter
    {
        public string Text { get; set; }
        public FilterType Type { get; set; }

        public enum FilterType { Contains = 0, DoesNotContain = 1 }

        public LogFilter() { }

        public LogFilter(string text, FilterType filterType)
        {
            Text = text;
            Type = filterType;
        }
    }

    public class Report
    {
        public int TotalFilesCount { get; set; } = 0;
        public TimeSpan ElapsedTime { get; set; } = TimeSpan.Zero;
        public FilesList SuccessfulFiles { get; set; } = new FilesList();
        public FilesList MissingFiles { get; set; } = new FilesList();
        public SkippedFilesList SkippedFiles { get; set; } = new SkippedFilesList();
        public Dictionary<string, List<string>> JsonValidationErrors { get; set; } = new Dictionary<string, List<string>>();
        public FunctionResponse ProcessResult { get; set; } = new FunctionResponse();
        public string ReportDateTime { get; set; } = "";

        [JsonIgnore]
        public bool IsEmpty { get { return CheckIfEmpty(); } private set { } }

        public Report() => Clear();

        public void Clear()
        {
            TotalFilesCount = 0;
            ElapsedTime = TimeSpan.Zero;
            SuccessfulFiles = new FilesList();
            MissingFiles = new FilesList();
            SkippedFiles = new SkippedFilesList();
            JsonValidationErrors = new Dictionary<string, List<string>>();
            ProcessResult = new FunctionResponse();
            ReportDateTime = "";
            IsEmpty = true;
        }

        private bool CheckIfEmpty()
        {
            return TotalFilesCount == 0 && ElapsedTime == TimeSpan.Zero && SuccessfulFiles.Count == 0 &&
                MissingFiles.Count == 0 && SkippedFiles.Count == 0 && JsonValidationErrors.Count == 0;
        }

        public class FilesList
        {
            public int Count { get { return GetPathsCount(); } private set { } }
            public List<string> Paths { get; private set; }

            public FilesList() { Paths = new List<string>(); Count = 0; }

            public void AddPath(string path)
            {
                Paths.Add(path);
                Count = Paths.Count;
            }

            public void ClearPaths()
            {
                Paths.Clear();
                Count = 0;
            }

            private int GetPathsCount() => Paths.Count;
        }

        public class SkippedFilesList
        {
            public int Count { get { return GetSkippedFilesCount(); } private set { } }
            public List<SkippedFileInfo> Paths { get; set; } = new List<SkippedFileInfo>();

            public SkippedFilesList() { Paths = new List<SkippedFileInfo>(); Count = 0; }

            public void AddFile(SkippedFileInfo skippedFileInfo)
            {
                Paths.Add(skippedFileInfo);
                Count = Paths.Count;
            }

            public void ClearSkippedFiles()
            {
                Paths.Clear();
                Count = 0;
            }

            private int GetSkippedFilesCount() => Paths.Count;
        }

        public class SkippedFileInfo
        {
            public string Path { get; set; } = "";
            public string Reason { get; set; } = "";

            public SkippedFileInfo() { }

            public SkippedFileInfo(string path, string reason)
            {
                Path = path;
                Reason = reason;
            }
        }
    }

    public class ComboboxItem
    {
        public string Text { get; set; }
        public string Value { get; set; }

        public ComboboxItem() { }

        public ComboboxItem(string text) => Text = text;

        public ComboboxItem(string text, string value)
        {
            Text = text;
            Value = value;
        }

        public override string ToString()
        {
            return Text;
        }
    }

    public class TextEditor
    {
        public string Name { get; set; }
        public bool Exists { get; set; }
        public string Path { get; set; }

        public TextEditor() { }

        public TextEditor(string name, bool exists)
        {
            Name = name;
            Exists = exists;
        }

        public TextEditor(string name, bool exists, string path)
        {
            Name = name;
            Exists = exists;
            Path = path;
        }
    }
}
