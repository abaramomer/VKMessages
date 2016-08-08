using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Forms;
using VKMessages.Core.Requests;


namespace VKMessages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            Browser.Url = new Uri(new LoginRequest("messages").GetUrl());
            Browser.Navigated += BrowserOnNavigated;
        }

        private void BrowserOnNavigated(object sender, WebBrowserNavigatedEventArgs webBrowserNavigatedEventArgs)
        {
            var url = Browser.Url.AbsoluteUri;

            var accessToken = Regex.Match(url, @"access_token=.*&expires_in").Value
                .Replace("access_token=", "")
                .Replace("&expires_in", "");
            AccessToken.Text = accessToken;

            App.Current.Properties["AccessToken"] = accessToken;
        }
    }
}
