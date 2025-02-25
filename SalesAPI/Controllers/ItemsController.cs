using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesAPI.DbContextes;

namespace SalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDb;

        public ItemsController(ApplicationDbContext applicationDb)
        {
            _applicationDb = applicationDb;
        }

        [HttpGet("/GetAll")]
        public async Task<IActionResult> GetAllItems()
        {
            var results = await _applicationDb.items.ToListAsync();
            return Ok(results);
        }

        
    }
}
