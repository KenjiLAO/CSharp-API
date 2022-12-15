using Microsoft.AspNetCore.Mvc;
using monAPI.Context;

namespace monAPI.Entities
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public VisionController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        //Get Vision
        [HttpGet]
        [Route("GetVision")]
        public async Task<ActionResult<List<Vision>>> Get()
        {
            return Ok(_context.vision);
        }

        //Get Vision by type
        [HttpGet]
        [Route("GetVisionByType")]
        public async Task<ActionResult<List<Vision>>> GetVisionType(string visionType)
        {
            Vision selectedVision = _context.vision.Where(x => x.VisionType == visionType).FirstOrDefault();
            return Ok(selectedVision);
        }

        //Add Vision
        [HttpPost]
        [Route("AddVision")]
        public async Task<ActionResult<List<Vision>>> Post(string name)
        {
            //Verify if the name is already in the database
            var Name = _context.vision.Where(x => x.VisionType == name).FirstOrDefault();
            if (Name != null)
            {
                return BadRequest("The name is already taken");
            }
            _context.vision.Add(new Vision()
            {
                VisionType = name
            });
            //Show the created vision
            var createdVision = _context.characters.Where(x => x.Name == name);
            _context.SaveChanges();
            return Ok(createdVision);
        }

        //Update Vision
        [HttpPatch]
        [Route("ModifyVision")]
        public async Task<ActionResult<List<Vision>>> Update(string Name, string newName)
        {
            //Modify a vision by his name
            var vision = _context.vision.FirstOrDefault(x => x.VisionType == Name);
            vision.VisionType = newName;
            _context.SaveChanges();
            return Ok(vision);
        }

        //Delete Vision
        [HttpDelete]
        [Route("DeleteVision")]
        public async Task<ActionResult<List<Vision>>> Delete(string name)
        {
            //Delete vision by his name
            Vision deleteCharacter = _context.vision.Where(x => x.VisionType == name).FirstOrDefault();
            _context.vision.Remove(deleteCharacter);
            _context.SaveChanges();
            return Ok("Vision deleted");
        }
    }
}