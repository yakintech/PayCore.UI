using Microsoft.AspNetCore.SignalR;

namespace PayCore.UI.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string username, string message)
        {
            Clients.All.SendAsync("addMessage", username, message);
        }
    }
}
