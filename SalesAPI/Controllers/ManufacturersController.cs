using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesAPI.DbContextes;

namespace SalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDb;

        public ManufacturersController(ApplicationDbContext applicationDb)
        {
            _applicationDb = applicationDb;
        }

        [HttpPost]
        [Route("/AddManufacturer")]
        public async Task<IActionResult> AddManufacturer(Manufacturer manufacturer)
        {
            manufacturer.Id = 0;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _applicationDb.Manufacturers.Add(manufacturer);
            await _applicationDb.SaveChangesAsync();
            return CreatedAtAction("GetManufacturer", new { id = manufacturer.Id }, manufacturer);
        }
    }
}
