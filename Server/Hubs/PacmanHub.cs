
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Hubs
{
    public class PacmanHub : Hub
    {
        public async Task SendConnectedMessage()
        {
            await Clients.All.SendAsync("ReceiveConnectedMessage", Context.ConnectionId);
        }
        public async Task SendPacmanCoordinates(int xCoordinate, int yCoordinate,int direction, string pacmanId)
        {
            await Clients.All.SendAsync("ReceivePacmanCoordinates", xCoordinate, yCoordinate, direction, pacmanId);
        }
    }
}
