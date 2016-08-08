namespace VKMessages.Core.Requests
{
    public class LoginRequest : AuthApiRequest
    {
        /// todo: move into config
        private const string LoginRedirectPage = @"https://oauth.vk.com/blank.html";

        private const string Display = "page";

        private const string AppId = "5578183";

        private const string ResponseType = "token";

        private const string State = "123456"; // wtf?

        public override string Method
        {
            get
            {
                return "authorize"; 
            }
        }

        public LoginRequest(string scope)
        {
            Params.Add("client_id", AppId);
            Params.Add("redirect_uri", LoginRedirectPage);
            Params.Add("scope", scope);
            Params.Add("response_type", ResponseType);
            Params.Add("state", State);
            Params.Add("display", Display);
        }
    }
}