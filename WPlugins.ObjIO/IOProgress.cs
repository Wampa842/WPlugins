using System;

namespace WPlugins.ObjIO
{
    public class IOProgress
    {
        public static int Percent(long progress, long total)
        {
            return (int)Math.Round((progress / (double)total) * 100);
        }

        public int ErrorCount { get; set; }
        public int WarningCount { get; set; }
        public int LineNumber { get; set; }

        /// <summary>
        /// Method that is called when a text message should be reported to the user.
        /// </summary>
        public Action<string> ReportMessageCallback;
        /// <summary>
        /// Method that is called when a progress percentage should be reported to the user.
        /// </summary>
        public Action<int> ReportPercentCallback;
        /// <summary>
        /// Method that is called when a non-terminating error is encountered.
        /// </summary>
        public Action<string, int> ReportWarningCallback;
        /// <summary>
        /// Method that is called when a potentially terminating error is encountered. The return value indicates if execution should be terminated.
        /// </summary>
        public Func<string, int, bool> ReportErrorCallback;

        public System.Threading.CancellationToken CancellationToken { get; set; }

        public void Report(string message)
        {
            if (ReportMessageCallback != null)
                ReportMessageCallback.Invoke(message);
        }

        public void Report(int percent)
        {
            if (ReportPercentCallback != null)
                ReportPercentCallback.Invoke(percent);
        }

        public void Report(int percent, string message)
        {
            Report(percent);
            Report(message);
        }

        public void ReportWarning(string message)
        {
            ++WarningCount;
            if (ReportWarningCallback != null)
                ReportWarningCallback.Invoke(message, LineNumber);
        }

        public bool ReportError(string message)
        {
            ++ErrorCount;
            if (ReportErrorCallback != null)
                return ReportErrorCallback.Invoke(message, LineNumber);

            return false;
        }

        public IOProgress() { }
    }
}
