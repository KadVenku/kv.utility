using System;

namespace kv.util
{
    public class DateTimeUtility
    {
        private const string DATE_TIME_FORMAT_LOG = "MM-dd-yyyy HH:mm:ss,fff";
        internal static string GetLogTimeStamp()
        {
            return DateTime.Now.ToString(DATE_TIME_FORMAT_LOG);
        }
    }
}