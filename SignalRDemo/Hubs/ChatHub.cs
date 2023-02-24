using System;
using Microsoft.AspNetCore.SignalR;

namespace SignalRDemo.Hubs;

public class ChatHub : Hub
{
    public Task SendMessageAsync(string user, string message)
    {
        return Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}

