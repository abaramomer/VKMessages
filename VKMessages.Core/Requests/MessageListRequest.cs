namespace VKMessages.Core.Requests
{
    public class MessageListRequest : AuthApiRequest
    {
        public override string Method
        {
            get
            {
                return "messages.getHistory"; 
            }
        }

        public MessageListRequest(string id, bool isChat, int count = 10)
        {
            SetParam(isChat ? "chat_id" : "uid", id);
            SetParam("count", count);
        }
    }
}