using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Services
{
    public class SignalR
    {
        private HubConnection _hubConnection;

        public SignalR(HubConnection connection)
        {
            _hubConnection = connection;
        }
        public async Task<bool> ConnectPlayer()
        {
            try
            {
                await _hubConnection.StartAsync();
                await _hubConnection.InvokeAsync("SendConnectedMessage");
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async void SendCoordinates(Pacman pacman)
        {
            try
            {
                await _hubConnection.InvokeAsync("SendPacmanCoordinates", pacman.xCoordinate, pacman.yCoordinate, pacman.nextDirection, pacman.Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
