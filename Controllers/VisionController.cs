using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            if (selectedVision != null)
            {
                return Ok(selectedVision);
            }
            return Ok(selectedVision);
        }

        //Add Vision
        [HttpPost]
        [Route("AddVision")]
        public async Task<ActionResult<List<Vision>>> Post(string name)
        {
            _context.vision.Add(new Vision()
            {
                VisionType = name
            });
            _context.SaveChanges();
            return Ok(await _context.vision.ToListAsync());

        }

        //Update Vision
        [HttpPut]
        [Route("UpdateVision")]
        public async Task<ActionResult<List<Vision>>> Update(string Name)
        {
            _context.SaveChanges();
            return Ok(await _context.vision.ToListAsync());
        }

        //Delete Vision
        [HttpDelete]
        [Route("DeleteVision")]
        public async Task<ActionResult<List<Vision>>> Delete(string name)
        {
            Vision deleteCharacter = _context.vision.Where(x => x.VisionType == name).FirstOrDefault();
            _context.vision.Remove(deleteCharacter);
            _context.SaveChanges();
            return Ok(await _context.vision.ToListAsync());
        }
    }
}