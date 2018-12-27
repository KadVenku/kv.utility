using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace kv.util.tests
{
    [TestClass]
    public class StringUtilityTests
    {
        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow("       ")]
        [DataRow("  \n  \t  ")]
        public void StringUtilityTest_IsNullEmptyOrWhitespace(string value)
        {
            bool val = StringUtility.IsNullEmptyOrWhitespace(value);
            Assert.IsTrue(val, $"{value} is null, empty, or whitespace.");
        }

        [TestMethod]
        [DataRow(null, null, StringUtility.Comparison.IgnoreCase)]
        [DataRow(null, null, StringUtility.Comparison.CaseSensitive)]
        [DataRow("a", "a", StringUtility.Comparison.IgnoreCase)]
        [DataRow("a", "a", StringUtility.Comparison.CaseSensitive)]
        [DataRow("a", "A", StringUtility.Comparison.IgnoreCase)]
        public void StringUtilityTest_CompareEquality(string a, string b, StringUtility.Comparison c)
        {
            int val = StringUtility.Compare(a, b, c);
            Assert.AreEqual(0, val);
        }

        [TestMethod]
        [DataRow("a", null, StringUtility.Comparison.IgnoreCase)]
        [DataRow(null, "a", StringUtility.Comparison.IgnoreCase)]
        [DataRow("a", null, StringUtility.Comparison.CaseSensitive)]
        [DataRow(null, "a", StringUtility.Comparison.CaseSensitive)]
        public void StringUtilityTest_CompareNull(string a, string b, StringUtility.Comparison c)
        {
            int val = StringUtility.Compare(a, b, c);
            Assert.AreNotEqual(0, val);
        }
    }
}