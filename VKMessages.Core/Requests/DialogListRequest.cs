namespace VKMessages.Core.Requests
{
    public class DialogListRequest : NonAuthApiRequest
    {
        public override string Method
        {
            get
            {
                return "messages.getDialogs"; 
            }
        }
    }
}