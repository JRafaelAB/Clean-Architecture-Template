using System;
using System.Text.RegularExpressions;
using Domain.Utils;
using Xunit;

namespace UnitTests.Utils
{
    public class CryptographyUtilsTest
    {
        private const int HASH_LENGTH = 128;
        private const string PEPPER_ENVIRONMENT_KEY = "PEPPER";
        
        [Fact]
        public void TestingSucess_GenerateSalt()
        {
            for (uint size = 0; size < 1000; size++)
            {
                string salt = Cryptography.GenerateSalt(size);
                Assert.Equal((int)size, salt.Length);
                foreach (char c in salt)
                {
                    Assert.Matches(new Regex("([a-z]|[0-9]|[A-Z])"), c.ToString());
                }
            }
        }
        
        [Theory]
        [InlineData("senha", "sal", "pimenta")]
        [InlineData("senha", "", "pimenta")]
        [InlineData("senha", "sal", "")]
        [InlineData("senha", "", "")]
        public void TestingSucess_EncryptPassword(string password, string salt, string pepper)
        {
            if(string.IsNullOrWhiteSpace(pepper)) Environment.SetEnvironmentVariable(PEPPER_ENVIRONMENT_KEY, pepper);
            
            string hash = Cryptography.EncryptPassword(password, salt);
            
            Assert.Equal(HASH_LENGTH, hash.Length);
        }
        
        [Theory]
        [InlineData("", "sal", "pimenta")]
        [InlineData("", "", "pimenta")]
        [InlineData("", "sal", "")]
        [InlineData("", "", "")]
        [InlineData(" ", "sal", "pimenta")]
        [InlineData(" ", "", "pimenta")]
        [InlineData(" ", "sal", "")]
        [InlineData(" ", "", "")]
        public void TestingArgumentException_EncryptPassword(string password, string salt, string pepper)
        {
            if(string.IsNullOrWhiteSpace(pepper)) Environment.SetEnvironmentVariable(PEPPER_ENVIRONMENT_KEY, pepper);
            
            Assert.Throws<ArgumentException>(() => Cryptography.EncryptPassword(password, salt));
        }
    }
}
