using KnifeZ.SignalRKit.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace KnifeZ.SignalRKit
{
    public class ServerNotifyHub
    {
        private readonly IHubContext<ClientNotifyHub> myHub;
        public ServerNotifyHub(IHubContext<ClientNotifyHub> _myHub)
        {
            myHub = _myHub;
        }
        public async Task SendWarnningAsync(string message, string toUser = null)
        {
            string clientAction = "WarnningMessage";
            await SendMessageAsync(message, toUser, clientAction);
        }
        public async Task SendInfoAsync(string message, string toUser = null)
        {
            string clientAction = "InfoMessage";
            await SendMessageAsync(message, toUser, clientAction);
        }
        public async Task SendErrorAsync(string message, string toUser = null)
        {
            string clientAction = "ErrorMessage";
            await SendMessageAsync(message, toUser, clientAction);
        }


        public async Task SendMessageAsync(string message, string toUser = null, string clientAction = "ReceiveMessage")
        {
            if (toUser == null)
            {
                await myHub.Clients.All.SendAsync(clientAction, new { message });
            }
            else
            {
                if (SimpleUserPool.Instance.Find(p => p.Key == toUser).Value != null)
                {
                    await myHub.Clients.Client(SimpleUserPool.Instance.Find(p => p.Key == toUser).Value)
                        .SendAsync(clientAction, new { message });
                }
            }
        }


    }
}
