using Microsoft.AspNet.SignalR.Infrastructure;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Forum.SignalR
{
    public class NotificationHub:Hub
    {
        private IConnectionManager _manager;
        public NotificationHub(IConnectionManager manager)
        {
            _manager = manager;
        }
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
