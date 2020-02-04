using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KnifeZ.SignalRKit.Hubs
{
    public class ClientNotifyHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            var lastConnection = SimpleUserPool.Instance.Find(p => p.Key == Context.User.Identity.Name);
            if (lastConnection.Key != null)
            {
                SimpleUserPool.Instance.Remove(lastConnection);
            }
            SimpleUserPool.Instance.Add(new System.Collections.Generic.KeyValuePair<string, string>(
                Context.User.Identity.Name,
                Context.ConnectionId));
            await base.OnConnectedAsync();
        }

        //发送消息--发送给所有连接的客户端
        public void Register()
        {

        }
        //发送消息--发送给所有连接的客户端
        public async Task GetNotification(string message)
        {
            await Clients.All.SendAsync("getNotification", message);
        }
        
        //发送消息--发送给所有连接的客户端
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }

        //发送消息--发送给指定用户
        public Task SendPrivateMessage(string userId, string message)
        {
            return Clients.User(userId).SendAsync("ReceiveMessage", message);
        }

        public Task OnNotify(string data)
        {
            throw new NotImplementedException();
        }
    }
}
