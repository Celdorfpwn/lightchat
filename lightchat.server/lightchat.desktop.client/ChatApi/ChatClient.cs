using lightchat.contracts;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace lightchat.desktop.client.ChatApi
{
    public class ChatClient
    {
        private readonly HubConnection connection;
        private readonly SimpleMessageFunctionsMap functionsMap = new SimpleMessageFunctionsMap();

        private readonly ReplaySubject<SimpleMessageContract> receiveMessageSubject = new ReplaySubject<SimpleMessageContract>();

        public IObservable<Unit> Initialize { get; private set; }

        public IObservable<SimpleMessageContract> MessageReceived => receiveMessageSubject;

        public IObservable<Unit> SendMessage(SimpleMessageContract contract)
        {
            return Observable.FromAsync(async () =>
            {
                await connection.InvokeAsync(functionsMap.ServerSendMessage, contract);
            });
        }

        public ChatClient()
        {
            connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:44392/chatserver")
                .Build();


            Initialize = Observable.FromAsync(async () =>
            {
                await connection.StartAsync();
            });


            connection.On<SimpleMessageContract>(functionsMap.ClientReceiveMessage, contract =>
            {
                receiveMessageSubject.OnNext(contract);
            });
        }
    }
}
