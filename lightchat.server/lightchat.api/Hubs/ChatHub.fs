module Hubs

open Microsoft.AspNetCore.SignalR
open lightchat.contracts


type ChatHub () = 
    inherit Hub()

    let functionsMap = SimpleMessageFunctionsMap()

    member this.SendMessage(contract: SimpleMessageContract) =
        this.Clients.Caller.SendAsync(functionsMap.ClientReceiveMessage, contract).Wait() |> ignore

        
        