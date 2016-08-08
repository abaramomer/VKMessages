using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VKMessages
{
    /// <summary>
    /// Interaction logic for Messages.xaml
    /// </summary>
    public partial class Messages : Window
    {
        private string accessToken;

        public Messages()
        {
            InitializeComponent();

            if (App.Current.Properties["AccessToken"] != null)
            {
                SendRequest();
            }

            else
            {
                MessagesList.Text = "Please, login";
            }
        }

        private void SendRequest()
        {
            var url = string.Format(@"https://api.vk.com/method/messages.getDialogs?access_token={0}",
                App.Current.Properties["AccessToken"]);
            var request = HttpWebRequest.CreateHttp(url);

            var response = (HttpWebResponse) request.GetResponse();
            
            using (var stream = response.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    MessagesList.Text = reader.ReadToEnd();
                }
            }
        }
    }
}
