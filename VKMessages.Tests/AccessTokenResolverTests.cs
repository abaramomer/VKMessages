using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VKMessages.Core;

namespace VKMessages.Tests
{
    [TestClass]
    public class AccessTokenResolverTests
    {
        private const string Url =
            "https://oauth.vk.com/blank.html#access_token=228By&expires_in=325&user_id=141&state=123456";

        private AccesTokenProccessor proccessor;

        [TestInitialize]
        public void Init()
        {
            proccessor = new AccesTokenProccessor();
        }

        [TestMethod]
        public void SaveFromUrl_UrlPassed_ReturnsCorrectToken()
        {
            var token = proccessor.SaveFromUrl(Url);

            token.Should().Be("228By");
        }
    }
}