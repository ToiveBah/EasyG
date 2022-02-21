namespace EasyG.Messages
{
    public class BaseMessage
    {
        public BaseMessage(object sender)
        {
            Sender = sender;
        }

        public object Sender { get; set; }
    }
}
