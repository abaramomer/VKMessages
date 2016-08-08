using System.IO;
using System.Net;
using VKMessages.Core.Requests;

namespace VKMessages
{
    public static class HttpRequester
    {
        public static string GetResponse(BaseRequest request)
        {
            var httpRequest = WebRequest.CreateHttp(request.GetUrl());

            var response = (HttpWebResponse)httpRequest.GetResponse();

            using (var stream = response.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}