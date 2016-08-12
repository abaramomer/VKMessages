using System;
using System.Text.RegularExpressions;

namespace VKMessages.Core
{
    public class AccesTokenProccessor
    {
        private const string AccesTokeParamName = "access_token";
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
        }
    }
}