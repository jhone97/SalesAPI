using Entities;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SalesAPI.DbContextes;

namespace SalesAPI.Hubs
{
    public class ChatHub : Hub<IChatClient>
    {
        private readonly ClientsContext _clientsContext;
        private readonly ILogger<ChatHub> _logger;

        public ChatHub(ClientsContext clientsContext, ILogger<ChatHub> logger)
        {
            _clientsContext = clientsContext;
            _logger = logger;
        }

        // on client connect
        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var username = httpContext?.Request.Query["username"].ToString();

            // username not provided
            if (string.IsNullOrEmpty(username))
            {
                _logger.LogError("No username provided. Disconnecting client.");
                Context.Abort(); // Force disconnect if no username
                return;
            }

            // username not in db
            var client = await _clientsContext.Clients.FirstOrDefaultAsync(x => x.Username == username);

            if (client == null)
            {
                _logger.LogError("Username {Username} not found in db. Disconnecting client.", username);
                Context.Abort(); // Force disconnect if no username not in db
                return;
            }

            _logger.LogInformation("Connected client: {Client}", JsonConvert.SerializeObject(client, Formatting.Indented));
            client.SignalRConnectionId = Context.ConnectionId;
            client.IsConnected = true;
            _clientsContext.Clients.Update(client);
            await _clientsContext.SaveChangesAsync();
           
            await base.OnConnectedAsync();
        }

        // on disconnect client
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var client = await _clientsContext.Clients.FirstOrDefaultAsync(x => x.SignalRConnectionId == Context.ConnectionId);
            if (client != null)
            {
                client.IsConnected = false;
                _clientsContext.Clients.Update(client);
                await _clientsContext.SaveChangesAsync();
                _logger.LogInformation("Disconnected client: {Client}", JsonConvert.SerializeObject(client, Formatting.Indented));
            }
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(PublicMessage message)
        {
            await Clients.All.ReceiveMessage(message);
        }

        public async Task SendPrivateMessage(PrivateMessage message)
        {
            await Clients.Client(message.To.SignalRConnectionId).RecivePrivateMessage(message); 
        }




    }
}

        

    

