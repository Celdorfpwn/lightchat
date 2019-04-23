using System;

namespace lightchat.contracts
{
    public class SimpleMessageFunctionsMap
    {
        public readonly string ServerSendMessage = "SendMessage";
        public readonly string ClientReceiveMessage = "ReceiveMessage";
    }

    public class SimpleMessageContract
    {
        public SimpleMessageContract() { }
        public string Text { get; set; }
    }
}
