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

        public DialogListRequest(int count = 10)
        {
            Params.Add("count", count.ToString());
        }
    }
}