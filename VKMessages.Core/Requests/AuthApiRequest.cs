namespace VKMessages.Core.Requests
{
    public abstract class AuthApiRequest : BaseRequest
    {
        public override string ApiUrl
        {
            get
            {
                return @"https://oauth.vk.com";
            }
        }
    }
}