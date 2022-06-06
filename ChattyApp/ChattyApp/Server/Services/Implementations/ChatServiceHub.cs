using ChattyApp.Server.Services.Interfaces;
using ChattyApp.Shared;
using Microsoft.AspNetCore.SignalR;

namespace ChattyApp.Server.Services.Implementations
{
    public class ChatServiceHub : Hub, IChatServiceHub
    {
        private static readonly Dictionary<string, string> _users = new();

        public override async Task OnConnectedAsync()
        {
            var username = Context.GetHttpContext()!.Request.Query["username"];

            _users.Add(Context.ConnectionId, username);

            await SendMessage(String.Empty, $"{username} joined Chatty-chat!");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var username = _users.FirstOrDefault(q => q.Key == Context.ConnectionId).Value;
            await SendMessage(string.Empty, $"{username} has left!");

            _users.Remove(Context.ConnectionId);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync(ChatTokens.RECEIVEMESSAGETOKEN, user, message);
        }
    }
}
