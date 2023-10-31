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
            var user = _service.Users.FirstOrDefault(u => u.Key == Context.ConnectionId);
            await Clients.All.SendAsync("ReceiveMessage", user.Value, message);
        }

        public async Task SendPrivateMessage(string toUser, string message)
        {
            var user = _service.Users.FirstOrDefault(u => u.Key == Context.ConnectionId);

            var connectionIdByUserName = _service.Users.FirstOrDefault(u => u.Value == toUser);
            if (connectionIdByUserName.Key is not null)
            {
                await Clients.Client(connectionIdByUserName.Key).SendAsync("ReceiveMessage", user.Value, message);
            }
            else
            {
                Console.WriteLine("The user is not exist");
            }
        }


    }
}
