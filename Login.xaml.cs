using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Forms;
using VKMessages.Core;
using VKMessages.Core.Requests;


namespace VKMessages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly AccesTokenProccessor proccessor;
        public Login()
        {
            InitializeComponent();
            
            proccessor = new AccesTokenProccessor();
            Browser.Url = new Uri(new LoginRequest("messages").GetUrl());
            Browser.Navigated += BrowserOnNavigated;
        }

        private void BrowserOnNavigated(object sender, WebBrowserNavigatedEventArgs webBrowserNavigatedEventArgs)
        {
            var url = Browser.Url.AbsoluteUri;
            var token = proccessor.SaveFromUrl(url);

            AccessToken.Text = token;
            App.Current.Properties["AccessToken"] = token;
        }
    }
}
