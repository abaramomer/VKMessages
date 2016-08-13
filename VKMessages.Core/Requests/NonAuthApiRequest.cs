using VKMessages.Data;

namespace VKMessages.Core.Requests
{
    public abstract class NonAuthApiRequest : BaseRequest
    {
        private AccessTokenProvider provider;

        protected NonAuthApiRequest()
        {
            provider = new AccessTokenProvider();
        }

        public string AccessToken { get; set; }

        public override string ApiUrl
        {
            get
            {
                return "https://api.vk.com/method"; 
            }
        }

        public override string GetUrl()
        {
            SetParam("access_token", GetAccessToken());

            return base.GetUrl();
        }

        private string GetAccessToken()
        {
            return provider.GetAccessToken();
        }
    }
}