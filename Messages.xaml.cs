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
using VKMessages.Core.Requests;

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
            var dialogRequest = new DialogListRequest {AccessToken = App.Current.Properties["AccessToken"].ToString()};

            MessagesList.Text = HttpRequester.GetResponse(dialogRequest);
        }
    }
}
