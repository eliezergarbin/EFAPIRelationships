using EFAPIRelationships.Data;
using EFAPIRelationships.DTO;
using EFAPIRelationships.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

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
            var characters = await _context.Characters
                .Where(x => x.UserId == userId)
                .Include(x => x.Weapon)
                .Include(x => x.Skills)
                .ToListAsync();

            return characters;
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>> Create(CreateCharacterDTO request)
        {
            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null)
                return NotFound();

            var newCharacter = new Character
            {
                Name = request.Name,
                PublishedBy = request.PublishedBy,
                User = user
            };

            _context.Characters.Add(newCharacter);
            await _context.SaveChangesAsync();

            return await Get(newCharacter.UserId);
        }

        [HttpPost("weapon")]
        public async Task<ActionResult<Character>> AddWeapon(AddWeaponDTO request)
        {
            var character = await _context.Characters.FindAsync(request.CharacterId);
            if (character == null)
                return NotFound();

            var newWeapon = new Weapon
            {
                Name = request.Name,
                Damage = request.Damage,
                Character = character
            };

            _context.Weapons.Add(newWeapon);
            await _context.SaveChangesAsync();

            return character;
        }

        [HttpPost("skill")]
        public async Task<ActionResult<Character>> AddCharacterSkill(AddCharacterSkillDTO request) 
        {
            var character = await _context.Characters
                .Where(c => c.Id == request.CharacterId)
                .Include(c => c.Skills)
                .FirstOrDefaultAsync();

            if (character == null) return NotFound();

            var skill = await _context.Skills.FindAsync(request.SkillId);
            if (skill == null) return NotFound();

            character.Skills.Add(skill);
            await _context.SaveChangesAsync();

            return character;
        }


    }
}
