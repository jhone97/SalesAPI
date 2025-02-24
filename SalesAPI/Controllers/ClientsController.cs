using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SalesAPI.DbContextes;
using SalesAPI.Hubs;

namespace SalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ClientsContext _clientsContext;
        private readonly IHubContext<ChatHub, IChatClient> _hubContext;

        public ClientsController(ClientsContext companyContext, IHubContext<ChatHub, IChatClient> hubContext)
        {
            _clientsContext = companyContext;
            _hubContext = hubContext;
           
        }

        [HttpGet("/clients/getall")]
        public async Task<IActionResult> GetAll()
        {
            var c = await _clientsContext.Clients.ToListAsync();
            return Ok(c); 
        }

        [HttpGet("/clients/getconnected")]
        public async Task<IActionResult> GetConnected()
        {
            var c = await _clientsContext.Clients.Where(c => c.IsConnected).ToListAsync();
            return Ok(c);
        }

        [HttpPost("/clients/SendPublicMessage")]
        public async Task<IActionResult> SendPublicMessage([FromBody] PublicMessage message)
        {
            await _hubContext.Clients.All.ReceiveMessage(message);
            return Ok();
        }


        [HttpPost("/clients/SendPrivateMessage")]
        public async Task<IActionResult> SendPrivateMessage([FromBody] PrivateMessage message)
        {
            await _hubContext.Clients.All.RecivePrivateMessage(message);
            return Ok();
        }






    }
}
