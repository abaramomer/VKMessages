namespace VKMessages.Core.Models
{
    public class Dialog : ResponseModel
    {
        [ResponseProperty("mid")]
        public string MessageId { get; set; }

        [ResponseProperty("uid")]
        public string DialogId { get; set; }

        [ResponseProperty("read_state")]
        public bool IsReaded { get; set; }

        [ResponseProperty("out")]
        public bool IsNotMy { get; set; }

        [ResponseProperty("date")]
        public string Date { get; set; }

        [ResponseProperty("body")]
        public string Text { get; set; }
    }
}