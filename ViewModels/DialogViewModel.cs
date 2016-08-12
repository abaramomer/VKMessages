using System.Windows.Media;
using VKMessages.Core.Models;

namespace VKMessages.ViewModels
{
    public class DialogViewModel : ResponseSpecificViewModel<Dialog>
    {
        public DialogViewModel(Dialog model)
            : base(model)
        {
        }
        public string DialogId
        {
            get; set; 
        }

        public string Text
        {
            get; set; 
        }

        public Color MessageColor
        {
            get; set; 
        }

        protected override void ConvertFromModel(Dialog model)
        {
            DialogId = model.DialogId;
            Text = !model.IsNotMy ? model.Text : "Вы: " + model.Text;
            Text = Text.Replace(@"<br>", System.Environment.NewLine);
            MessageColor = model.IsReaded ? Colors.White : Colors.LightBlue;
        }
    }
}