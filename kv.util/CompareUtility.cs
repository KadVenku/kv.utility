namespace kv.util
{
    public sealed class CompareUtility
    {
        public static bool IsOneOf(object obj, params object[] objectsToCompare)
        {
            if (obj == null) return false;
            if (objectsToCompare == null) return false;
            if (objectsToCompare.Length < 1) return false;
            bool returnVal = false;
            foreach (object otherObj in objectsToCompare)
            {
                if (IsEqualTo(obj, otherObj))
                {
                    returnVal = true;
                }
            }
            return returnVal;
        }

        public static bool IsEqualTo(object obj, object otherObj)
        {
            if (obj == null || otherObj == null) return false;
            if (obj is string a && otherObj is string b)
            {
                return StringUtility.IsEqual(a, b);
            }
            return obj.GetType() == otherObj.GetType() && obj.Equals(otherObj);
        }
    }
}