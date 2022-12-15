using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using monAPI.Context;
using monAPI.Entities;

namespace monAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
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
            return Ok(selectedCharacter);
        }

        //Add Characters
        [HttpPost]
        [Route("AddCharacters")]
        public async Task<ActionResult<List<Characters>>> Post(string name, string description, string regionName, string visionType, string weaponName)
        {
            //Verify if the name is already in the database
            var Name = _context.characters.Where(c => c.Name == name).FirstOrDefault();
            if (Name != null)
            {
                return BadRequest("The name is already taken");
            }

            var Region = _context.region.Where(x => x.RegionName == regionName).FirstOrDefault();
            var Vision = _context.vision.Where(x => x.VisionType == visionType).FirstOrDefault();
            var Weapon = _context.weapon.Where(x => x.WeaponName == weaponName).FirstOrDefault();

            if (Region == null)
            {
                return BadRequest("No region added");
            }
            if (Vision == null)
            {
                return BadRequest("No vision added");
            }
            if (Weapon == null)
            {
                return BadRequest("No weapon added");
            }
            _context.characters.Add( new Characters()
            {
                Name = name,
                Description = description,
                region = Region,
                vision = Vision,
                weapon = Weapon
            });

            //Show the created character
            var createdCharacter = _context.characters.Where(x => x.Name == name);
            _context.SaveChanges();
            return Ok(createdCharacter);
        }

        //Update characters
        [HttpPatch]
        [Route("ModifyCharacters")]
        public async Task<ActionResult<List<Characters>>> Modify(string name, string newName, string newDescription)
        {
            //Modify a character by his name and description
            var character = _context.characters.FirstOrDefault(x => x.Name == name);

            character.Name = newName;
            character.Description = newDescription;
            _context.SaveChanges();
            return Ok(character);
            
        }

        //Delete characters
        [HttpDelete]
        [Route("DeleteCharacters")]
        public async Task<ActionResult<List<Characters>>> Delete(string name)
        {
            Characters deleteCharacter = _context.characters.Where(x => x.Name == name).FirstOrDefault();
            _context.characters.Remove(deleteCharacter);
            _context.SaveChanges();
            return Ok("Character deleted");
        }
    }
}
