using System.Linq;
using Newtonsoft.Json.Linq;
using VKMessages.Core.Models;

namespace VKMessages.Core
{
    public class ResponseSerializer
    {
        public object Deserialize(string response)
        {
            var obj = JObject.Parse(response);

            var p = obj.GetValue("response");


            var values = p.Value<JArray>().Skip(1).ToList();

            var dialog = new Dialog();
            foreach (var value in values)
            {
                var properties = dialog.GetType().GetProperties().Where(pp => pp.GetCustomAttributes(typeof(ResponcePropertyNameAttribute), true).Count() != 0);

                foreach (var property in properties)
                {
                    var attr = (ResponcePropertyNameAttribute) property.GetCustomAttributes(typeof (ResponcePropertyNameAttribute), true).First();

                    var name = attr.Name;
                    var val = value.SelectToken(name).ToString();
                    property.SetValue(dialog, val);
                }
            }

            return dialog;
        }
    }
}