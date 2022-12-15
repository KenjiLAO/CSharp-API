using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

    //Get weapon by name
    [HttpGet]
    [Route("GetweaponByName")]
    public async Task<ActionResult<List<Weapon>>> GetName(string WeaponName)
    {
        Weapon selectedWeapon = _context.weapon.Where(x => x.WeaponName == WeaponName).FirstOrDefault();
        if (selectedWeapon != null)
        {
            return Ok(selectedWeapon);
        }
        return Ok(selectedWeapon);
    }

    //Add weapon
    [HttpPost]
    [Route("AddWeapon")]
    public async Task<ActionResult<List<Weapon>>> Post(string name)
    {
        _context.weapon.Add(new Weapon()
        {
            WeaponName = name
        });
        _context.SaveChanges();
        return Ok(await _context.weapon.ToListAsync());

    }


    //Update weapon
    [HttpPut]
    [Route("UpdateWeapon")]
    public async Task<ActionResult<List<Weapon>>> Update(string Name)
    {
        _context.SaveChanges();
        return Ok(await _context.weapon.ToListAsync());
    }

    //Delete weapon
    [HttpDelete]
    [Route("DeleteWeapon")]
    public async Task<ActionResult<List<Weapon>>> Delete(string name)
    {
        Weapon deleteWeapon = _context.weapon.Where(x => x.WeaponName == name).FirstOrDefault();
        _context.weapon.Remove(deleteWeapon);
        _context.SaveChanges();
        return Ok(await _context.weapon.ToListAsync());
    }
}
