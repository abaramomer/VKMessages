using System.Collections.Generic;
using System.Text;

namespace VKMessages.Core.Requests
{
    public abstract class BaseRequest
    {
        public abstract string ApiUrl { get; }

        public abstract string Method { get; }

        protected Dictionary<string, string> Params { get; set; }

        protected BaseRequest()
        {
            Params = new Dictionary<string, string>();
        }

        public virtual string GetUrl()
        {
            var url = new StringBuilder(string.Format(@"{0}/{1}?", ApiUrl, Method));

            foreach (var param in Params)
            {
                url.AppendFormat("{0}={1}&", param.Key, param.Value);
            }

            return url.ToString().TrimEnd('&');
        }

        protected void SetParam(string key, object value)
        {
            Params.Add(key, value.ToString());
        } 
    }
}