using System;
using PEPlugin.Pmx;

namespace WPlugins.ObjIO
{
    public class ImportResult
    {
        public enum ResultType { Undefined, Success, Fail, Cancel }

        public ResultType Result { get; set; } = ResultType.Undefined;

        public IPXPmx Pmx { get; set; }
        public Exception Exception { get; set; }
        public string Message { get; set; }

        public int ErrorCount { get; set; }
        public int WarningCount { get; set; }

        public static ImportResult Success(IPXPmx pmx, int warningCount, int errorCount)
        {
            ImportResult result = new ImportResult
            {
                Result = ResultType.Success,
                Pmx = pmx,
                ErrorCount = errorCount,
                WarningCount = warningCount
            };
            return result;
        }

        public static ImportResult Cancel(int warningCount, int errorCount)
        {
            ImportResult result = new ImportResult
            {
                Result = ResultType.Cancel,
                ErrorCount = errorCount
            };
            return result;
        }

        public static ImportResult Fail(Exception ex, int warningCount, int errorCount)
        {
            ImportResult result = new ImportResult
            {
                Result = ResultType.Fail,
                Exception = ex,
                ErrorCount = errorCount,
                WarningCount = warningCount
            };
            return result;
        }
    }
}
