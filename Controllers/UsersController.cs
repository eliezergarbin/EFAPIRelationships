using EFAPIRelationships.Data;
using EFAPIRelationships.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFAPIRelationships.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            var users = await _context.Users.Include(u => u.Characters).ToListAsync();

            return users;
        }

        [HttpGet("user")]
        public async Task<ActionResult<List<User>>> GetbyId(int userId)
        {
            var users = await _context.Users.Where(u => u.Id == userId).Include(u => u.Characters).ToListAsync();

            return users;
        }

    }

}
