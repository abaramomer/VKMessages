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
using VKMessages.Core;
using VKMessages.Core.Models;
using VKMessages.Core.Requests;
using VKMessages.ViewModels;
using VKMessages.ViewModels.PageViewModels;

namespace VKMessages
{
    /// <summary>
    /// Interaction logic for Messages.xaml
    /// </summary>
    public partial class Messages : Window, IApplicationPage<DialogListPageViewModel>
    {
        private string accessToken;

        public DialogListPageViewModel PageViewModel { get; set; }

        public Messages()
        {
            InitializeComponent();
            PageViewModel = new DialogListPageViewModel();

            if (App.Current.Properties["AccessToken"] != null)
            {
                SendRequest();
            }

            Bind(PageViewModel);
        }

        private void SendRequest()
        {
            var dialogRequest = new DialogListRequest {AccessToken = App.Current.Properties["AccessToken"].ToString()};

            var response = HttpRequester.GetResponse(dialogRequest);

            var dialogs = new ResponseDeserializer().DeserializeMany<Dialog>(response);

            foreach (var dialog in dialogs)
            {
                var viewModel = new DialogViewModel(dialog);
                PageViewModel.Dialogs.Add(viewModel);
            }
        }

        public void Bind(DialogListPageViewModel viewModel)
        {
            DataContext = viewModel;
        }
    }
}
