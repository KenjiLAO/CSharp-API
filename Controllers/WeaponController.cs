using Microsoft.AspNetCore.Mvc;
using monAPI.Context;

namespace monAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WeaponController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public WeaponController(ApplicationDbContext dbContext)
    {
        _context = dbContext;
    }

    //Get weapon
    [HttpGet]
    [Route("Getweapon")]
    public async Task<ActionResult<List<Weapon>>> Get()
    {
        return Ok(_context.weapon);
    }

    //Add weapon
    [HttpPost]
    [Route("AddWeapon")]
    public async Task<ActionResult<List<Weapon>>> Post(string name)
    {
        //Verify if the name is already in the database
        var Name = _context.weapon.Where(x => x.WeaponName == name).FirstOrDefault();
        if (Name != null)
        {
            return BadRequest("The name is already taken");
        }
        _context.weapon.Add(new Weapon()
        {
            WeaponName = name
        });
        //Show the created weapon
        var createdWeapon = _context.characters.Where(x => x.Name == name);
        _context.SaveChanges();
        return Ok(createdWeapon);
    }


    //Update weapon
    [HttpPatch]
    [Route("ModifyWeapon")]
    public async Task<ActionResult<List<Weapon>>> Update(string Name, string newName)
    {
        //Modify a weapon by his name
        var weapon = _context.weapon.FirstOrDefault(x => x.WeaponName == Name);

        weapon.WeaponName = newName;
        _context.SaveChanges();
        return Ok(weapon);
    }

    //Delete weapon
    [HttpDelete]
    [Route("DeleteWeapon")]
    public async Task<ActionResult<List<Weapon>>> Delete(string name)
    {
        //delete a weapon by his name
        Weapon deleteWeapon = _context.weapon.Where(x => x.WeaponName == name).FirstOrDefault();
        _context.weapon.Remove(deleteWeapon);
        _context.SaveChanges();
        return Ok("Vision deleted");
    }
}
