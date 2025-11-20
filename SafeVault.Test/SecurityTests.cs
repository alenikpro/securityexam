using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace SafeVault.Tests
{
    [TestClass]
    public class SecurityTests
    {
        [TestMethod]
        public void ValidateInput_ValidInput_ReturnsInput()
        {
            string input = "valid_username";
            string result = SecureCode.ValidateInput(input);
            NUnit.Framework.Assert.AreEqual(input, result);
        }

        [TestMethod]
        public void ValidateInput_InvalidInput_ThrowsException()
        {
            SecureCode.ValidateInput("invalid-username!");
        }

        [TestMethod]
        public void SanitizeInput_XSSInput_ReturnsSanitizedString()
        {
            string input = "<script>alert('XSS')</script>";
            string result = SecureCode.SanitizeInput(input);
            NUnit.Framework.Assert.AreEqual("&lt;script&gt;alert('XSS')&lt;/script&gt;", result);
        }
    }
}
