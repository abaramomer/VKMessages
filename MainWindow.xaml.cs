using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;

namespace VKMessages
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            var login = new Login();
            login.ShowDialog();
        }

        private void MessagesClick(object sender, RoutedEventArgs e)
        {
            var messages = new Messages();
            messages.ShowDialog();
        }
    }
}
