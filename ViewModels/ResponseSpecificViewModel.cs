using VKMessages.Core.Models;

namespace VKMessages.ViewModels
{
    public abstract class ResponseSpecificViewModel<TModel> where TModel : ResponseModel
    {
        protected ResponseSpecificViewModel(TModel model)
        {
            ConvertFromModel(model);    
        } 

        protected abstract void ConvertFromModel(TModel model);
    }
}