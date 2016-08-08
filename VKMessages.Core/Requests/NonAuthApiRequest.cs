namespace VKMessages.Core.Requests
{
    public abstract class NonAuthApiRequest : BaseRequest
    {
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
            Params.Add("access_token", AccessToken);
            return base.GetUrl();
        }

        private string GetAccessToken()
        {
            return "123";
        }
    }
}