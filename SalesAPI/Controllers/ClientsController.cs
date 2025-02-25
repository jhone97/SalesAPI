using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SalesAPI.DbContextes;
using SalesAPI.Hubs;
using SalesAPI.Services;

namespace SalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ApplicationDbContext _clientsContext;
        private readonly IHubContext<ChatHub, IChatClient> _hubContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtService _jwtService;

        public ClientsController(ApplicationDbContext companyContext, IHubContext<ChatHub, IChatClient> hubContext, UserManager<IdentityUser> userManager, JwtService jwtService)
        {
            _clientsContext = companyContext;
            _hubContext = hubContext;
            _userManager = userManager;
           _jwtService = jwtService;
        }


        [HttpPost]
       
        [Route("/clients/Register")]
        public async Task<ActionResult<Client>> PostUser(RegisterModel register)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userManager.CreateAsync(
                new IdentityUser() { UserName = register.Username, Email = register.EmailAddress },
                register.Password
            );

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            register.Password = null;
            return CreatedAtAction("GetUser", new { username = register.Username }, register);
        }

        // POST: api/Users/BearerToken
        [HttpPost("/clients/login")]
        public async Task<ActionResult<AuthenticationResponse>> CreateBearerToken(AuthenticationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bad credentials");
            }

            var user = await _userManager.FindByNameAsync(request.Username);

            if (user == null)
            {
                return BadRequest("Bad credentials");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!isPasswordValid)
            {
                return BadRequest("Bad credentials");
            }

            var token = _jwtService.CreateToken(user);

            return Ok(token);
        }



        [HttpGet("/clients/getconnected")]
        public async Task<IActionResult> GetConnected()
        {
            var c = await _clientsContext.Clients.Where(c => c.IsConnected).ToListAsync();
            return Ok(c);
        }

        [Authorize]
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
