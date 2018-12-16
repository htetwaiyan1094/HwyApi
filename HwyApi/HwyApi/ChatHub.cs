using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using static HwyApi.Logics.TicTacToe;

namespace HwyApi
{
    public class ChatHub : Hub
    {
        private static IList<string> onlineConnId = new List<string>();
        private static IList<UserInfo> userInfos = new List<UserInfo>();
        public Task Hello(string nick, string message)
        {
            Console.WriteLine(Context.ConnectionId);
            return Clients.All.SendAsync("hello", nick, message);
        }

        public override Task OnConnectedAsync()
        {
            onlineConnId.Add(Context.ConnectionId);
            UpdateUserCount();

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            onlineConnId.Remove(Context.ConnectionId);
            UpdateUserCount();

            return base.OnDisconnectedAsync(exception);
        }

        public void UpdateUserCount()
        {
            Clients.All.SendAsync("updateCount", onlineConnId.Count);
        }
    }

    public class UserInfo
    {
        public string TempId { get; set; }
        public string Name { get; set; }
        public State userState { get; set; }
        public int Score { get; set; }
    }
}
