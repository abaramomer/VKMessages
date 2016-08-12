using System.Collections.Generic;

namespace VKMessages.ViewModels.PageViewModels
{
    public class DialogListPageViewModel : BasePageViewModel
    {
        public DialogListPageViewModel()
        {
            Dialogs = new List<DialogViewModel>();    
        }

        public List<DialogViewModel> Dialogs { get; set; } 
    }
}