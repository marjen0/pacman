
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Hubs
{
    public class PacmanHub : Hub
    {
        public async Task SendConnectedMessage(string username, int id)
        {
            await Clients.All.SendAsync("ReceiveConnectedMessage", username, id);
        }
        public async Task SendPacmanCoordinates(int xCoordinate, int yCoordinate, int pacmanId)
        {
            await Clients.All.SendAsync("ReceivePacmanCoordinates", xCoordinate, yCoordinate, pacmanId);
        }
    }
}
