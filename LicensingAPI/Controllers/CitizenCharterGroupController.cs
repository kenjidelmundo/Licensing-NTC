using LicensingAPI.Data;
using LicensingAPI.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CitizenCharterGroupController : ControllerBase
{
    private readonly ApplicationDBContext _context;

    public CitizenCharterGroupController(ApplicationDBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get() =>
        Ok(_context.CitizenCharterGroups.ToList());

    [HttpPost]
    public IActionResult Post(CitizenCharterGroup model)
    {
        _context.CitizenCharterGroups.Add(model);
        _context.SaveChanges();
        return Ok(model);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, CitizenCharterGroup model)
    {
        var existing = _context.CitizenCharterGroups.Find(id);
        if (existing == null) return NotFound();

        existing.GroupName = model.GroupName;
        existing.Description = model.Description;

        _context.SaveChanges();
        return Ok(existing);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var item = _context.CitizenCharterGroups.Find(id);
        if (item == null) return NotFound();

        _context.CitizenCharterGroups.Remove(item);
        _context.SaveChanges();
        return Ok();
    }
}
