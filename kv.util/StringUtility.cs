using System.Globalization;
using System.Linq;

namespace kv.util
{
    public sealed class StringUtility
    {
        public enum Comparison
        {
            IgnoreCase,
            CaseSensitive
        }
        public static bool IsNullEmptyOrWhitespace(string s)
        {
            return string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s);
        }

        public static int Compare(string a, string b, Comparison c = Comparison.CaseSensitive)
        {
            if (IsNullEmptyOrWhitespace(a) && IsNullEmptyOrWhitespace(b))
            {
                return 0;
            }
            
            if (IsNullEmptyOrWhitespace(a))
            {
                return -1;
            }

            if (IsNullEmptyOrWhitespace(b))
            {
                return 1;
            }

            int result = int.MinValue;
            
            switch (c)
            {
                case Comparison.IgnoreCase:
                    result = string.CompareOrdinal(a.ToLower(CultureInfo.InvariantCulture), b.ToLower(CultureInfo.InvariantCulture));
                    break;
                case Comparison.CaseSensitive:
                    result = string.CompareOrdinal(a, b);
                    break;
            }

            return result;
        }

        public static bool IsEqual(string a, string b, Comparison comparison = Comparison.CaseSensitive)
        {
            return Compare(a, b, comparison) == 0;
        }

        public static bool IsOneOf(Comparison c, string a, params object[] ss)
        {

            if (IsNullEmptyOrWhitespace(a)) return false;
            if (ss == null) return false;
            return ss.Length >= 1 && (from string b in ss where !IsNullEmptyOrWhitespace(b) select b).Any(b => IsEqual(a, b, c));

        }

        public static string NormalizeString(string s)
        {
            return s.Trim().ToLowerInvariant();
        }
    }
}
