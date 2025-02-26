
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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


        [HttpGet]
        [Route("/GetAllManufacturers")]
        public async Task<ActionResult<List<Manufacturer>>> GetAll()
        {
            var results = await _applicationDb.Manufacturers.ToListAsync();
            return Ok(results);
        }


       
    }
}
