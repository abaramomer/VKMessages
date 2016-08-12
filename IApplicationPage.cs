using VKMessages.ViewModels.PageViewModels;

namespace VKMessages
{
    public interface IApplicationPage<TViewModel> where TViewModel : BasePageViewModel
    {
        TViewModel PageViewModel { get; set; }

        void Bind(TViewModel viewModel);
    }
}