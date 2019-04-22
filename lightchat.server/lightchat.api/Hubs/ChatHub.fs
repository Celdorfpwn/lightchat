module Hubs

open Microsoft.AspNetCore.SignalR


type ChatHub () = 
    inherit Hub()

    member this.Ping() =
        this.Clients.Caller.SendAsync("PingBack", "hello from the other side").Wait() |> ignore

        
        