using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Forms;


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
            Browser.Url = new Uri("https://oauth.vk.com/authorize?client_id=5578183&display=page&redirect_uri=https://oauth.vk.com/blank.html&scope=messages&response_type=token&v=5.53&state=123456");
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
