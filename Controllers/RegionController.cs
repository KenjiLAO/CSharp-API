using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using monAPI.Context;
using monAPI.Entities;

namespace monAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class RegionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public RegionController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        //Get region
        [HttpGet]
        [Route("GetRegion")]
        public async Task<ActionResult<List<Region>>> Get()
        {
            return Ok(_context.region);
        }

        //Add Region
        [HttpPost]
        [Route("AddRegion")]
        public async Task<ActionResult<List<Region>>> Post(string name, string description)
        {
            //Verify if the name is already in the database
            var Name = _context.region.Where(c => c.RegionName == name).FirstOrDefault();
            if (Name != null)
            {
                return BadRequest("The name is already taken");
            }
            _context.region.Add(new Region()
            {
                RegionName = name,
                RegionDescription = description
            });
            //Show the created region
            var createdRegion = _context.characters.Where(x => x.Name == name);
            _context.SaveChanges();
            return Ok(createdRegion);
        }
        //Update Region
        [HttpPatch]
        [Route("ModifyRegion")]
        public async Task<ActionResult<List<Region>>> Update(string Name, string newName, string newDescription)
        {
            //Modify a region by his name and description
            var region = _context.region.FirstOrDefault(x => x.RegionName == Name);

            region.RegionName = newName;
            region.RegionDescription = newDescription;
            _context.SaveChanges();
            return Ok(region);
        }

        //Delete Region
        [HttpDelete]
        [Route("DeleteRegion")]
        public async Task<ActionResult<List<Region>>> Delete(string name)
        {
            Region deleteRegion = _context.region.Where(x => x.RegionName == name).FirstOrDefault();
            _context.region.Remove(deleteRegion);
            _context.SaveChanges();
            return Ok("Region deleted");
        }

    }
}