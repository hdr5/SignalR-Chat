using Microsoft.AspNetCore.SignalR;
using BlazorServerSignalRApp.Data;


namespace BlazorServerSignalRApp.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ChatService _service;

        public ChatHub(ChatService service)
        {
            _service = service;
        }

        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", _service.Users.FirstOrDefault(u => u.Key == Context.ConnectionId), message);
        }

        public async Task SendPrivateMessage(string toUser, string message)
        {
            await Clients.Client(toUser).SendAsync("ReceiveMessage", _service.Users.FirstOrDefault(u => u.Key == Context.ConnectionId), message);
        }


    }
}
