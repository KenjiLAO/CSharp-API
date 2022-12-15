using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using monAPI.Context;
using monAPI.Entities;

namespace monAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController: ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CharactersController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        //Get Characters
        [HttpGet]
        [Route("GetCharacters")]
        public async Task<ActionResult<List<Characters>>> Get()
        {
            return Ok(_context.characters);
        }

        //Get characters by name
        [HttpGet]
        [Route("GetCharactersByName")]
        public async Task<ActionResult<List<Characters>>> GetName(string characterName)
        {
            Characters selectedCharacter = _context.characters.Where(x => x.Name == characterName).FirstOrDefault();
            if (selectedCharacter != null)
            {
                return Ok(selectedCharacter);
            }
            return Ok(selectedCharacter);
        }

        //Add Characters
        [HttpPost]
        [Route("AddCharacters")]
        public async Task<ActionResult<List<Characters>>> Post(string name, string description)
        {
            _context.characters.Add(new Characters()
            {
                Name = name,
                Description = description
            });
            _context.SaveChanges();
            return Ok(await _context.characters.ToListAsync());
            
        }


        //Update characters
        [HttpPut]
        [Route("UpdateCharacters")]
        public async Task<ActionResult<List<Characters>>> Update(string Name, string Description)
        {
            _context.SaveChanges();
            return Ok(await _context.characters.ToListAsync());
        }

        //Delete characters
        [HttpDelete]
        [Route("DeleteCharacters")]
        public async Task<ActionResult<List<Characters>>> Delete(string name)
        {
            Characters deleteCharacter = _context.characters.Where(x => x.Name == name).FirstOrDefault();
            _context.characters.Remove(deleteCharacter);
            _context.SaveChanges();
            return Ok(await _context.characters.ToListAsync());
        }
    }
}
