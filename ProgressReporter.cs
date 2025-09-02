using System;

namespace مُشفر
{
    /// <summary>
    /// فئة لإدارة تقارير التقدم أثناء عمليات التشفير وفك التشفير
    /// </summary>
    public class ProgressReporter
    {
        public event EventHandler<ProgressEventArgs>? ProgressChanged;
        public event EventHandler<FileProcessedEventArgs>? FileProcessed;
        public event EventHandler<ErrorEventArgs>? ErrorOccurred;

        public void ReportProgress(int percentage, string currentFile, int processedFiles, int totalFiles)
        {
            ProgressChanged?.Invoke(this, new ProgressEventArgs
            {
                Percentage = percentage,
                CurrentFile = currentFile,
                ProcessedFiles = processedFiles,
                TotalFiles = totalFiles
            });
        }

        public void ReportFileProcessed(string filePath, bool success, string? errorMessage = null)
        {
            FileProcessed?.Invoke(this, new FileProcessedEventArgs
            {
                FilePath = filePath,
                Success = success,
                ErrorMessage = errorMessage
            });
        }

        public void ReportError(string message, Exception? exception = null)
        {
            ErrorOccurred?.Invoke(this, new ErrorEventArgs
            {
                Message = message,
                Exception = exception
            });
        }
    }

    public class ProgressEventArgs : EventArgs
    {
        public int Percentage { get; set; }
        public string CurrentFile { get; set; } = string.Empty;
        public int ProcessedFiles { get; set; }
        public int TotalFiles { get; set; }
    }

    public class FileProcessedEventArgs : EventArgs
    {
        public string FilePath { get; set; } = string.Empty;
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
    }

    public class ErrorEventArgs : EventArgs
    {
        public string Message { get; set; } = string.Empty;
        public Exception? Exception { get; set; }
    }
}