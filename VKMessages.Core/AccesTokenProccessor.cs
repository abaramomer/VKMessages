using System.Text.RegularExpressions;
using VKMessages.Data;

namespace VKMessages.Core
{
    public class AccesTokenProccessor
    {
        private const string AccesTokeParamName = "access_token";
        private AccessTokenProvider provider;

        public AccesTokenProccessor()
        {
            provider = new AccessTokenProvider();
        }

        public string SaveFromUrl(string url)
        {
            var pattern = string.Format("#{0}=([A-z0-9]*)", AccesTokeParamName);
            var token = Regex.Match(url, pattern).Groups[1].Value;

            Save(token);

            return token;
        }

        public string GetAccesToken()
        {
            return string.Empty;
        }

        public void Save(string token)
        {
            provider.Save(token);   
        }
    }
}