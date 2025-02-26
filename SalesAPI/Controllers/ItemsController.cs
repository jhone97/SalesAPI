
using Entities.Models;
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
        public async Task<ActionResult<List<Item>>> GetAllItems()
        {
            var results = await _applicationDb.Items.
                Include(m => m.Manufacturer).ToListAsync();
            return Ok(results);
        }



        [HttpGet("/GetItemByCode")]
        public async Task<IActionResult> GetByCode(string itemCode)
        {
            return Ok();
        }



        [HttpPost("/AddItem")]
        public async Task<IActionResult> AddItem(Item item)
        {
           return Ok();
        }

        
    }
}
