using EFAPIRelationships.Data;
using EFAPIRelationships.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFAPIRelationships.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : Controller
    {
        private readonly DataContext _context;

        public CharactersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Character>>> Get(int userId)
        {
            var characters = await _context.Characters.Where(x => x.UserId == userId).ToListAsync();

            return characters;
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>> Create(Character character)
        {
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            return await Get(character.UserId);
        }
    }
}
