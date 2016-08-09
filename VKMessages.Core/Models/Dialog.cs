namespace VKMessages.Core.Models
{
    public class Dialog : ResponseModel
    {
        [ResponcePropertyName("mid")]
        public string MessageId { get; set; }

        [ResponcePropertyName("uid")]
        public string DialogId { get; set; }

        [ResponcePropertyName("read_state")]
        public bool IsReaded { get; set; }

        [ResponcePropertyName("out")]
        public string IsMy { get; set; }

        [ResponcePropertyName("date")]
        public string Date { get; set; }

        [ResponcePropertyName("body")]
        public string Text { get; set; }
    }
}