module Hubs

open Microsoft.AspNetCore.SignalR


type ChatHub () = 
    inherit Hub()

    member this.Ping() =
        async {
            this.Clients.User(this.Context.ConnectionId).SendAsync("PingBack") |> ignore
        }
        