using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using monAPI.Context;
using monAPI.Entities;

namespace monAPI.Controllers;

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
        _context.region.Add(new Region()
        {
            RegionName = name,
            RegionDescription = description
        });
        _context.SaveChanges();
        return Ok(await _context.region.ToListAsync());

    }


    //Update Region
    [HttpPut]
    [Route("UpdateRegion")]
    public async Task<ActionResult<List<Region>>> Update(string Name, string Description)
    {
        _context.SaveChanges();
        return Ok(await _context.region.ToListAsync());
    }

    //Delete Region
    [HttpDelete]
    [Route("Deleteregion")]
    public async Task<ActionResult<List<Region>>> Delete(string name)
    {
        Region deleteCharacter = _context.region.Where(x => x.RegionName == name).FirstOrDefault();
        _context.region.Remove(deleteCharacter);
        _context.SaveChanges();
        return Ok(await _context.region.ToListAsync());
    }

}