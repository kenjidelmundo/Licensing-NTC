using LicensingAPI.Data;
using LicensingAPI.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CitizenCharterStagesController : ControllerBase
{
    private readonly ApplicationDBContext _context;

    public CitizenCharterStagesController(ApplicationDBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get() =>
        Ok(_context.CitizenCharterStages.ToList());

    [HttpGet("by-group/{groupId}")]
    public IActionResult GetByGroup(int groupId) =>
        Ok(_context.CitizenCharterStages
            .Where(s => s.GroupId == groupId)
            .ToList());

    [HttpPost]
    public IActionResult Post(CitizenCharterStages model)
    {
        if (!_context.CitizenCharterGroups.Any(g => g.GroupId == model.GroupId))
            return BadRequest("Invalid GroupId");

        _context.CitizenCharterStages.Add(model);
        _context.SaveChanges();
        return Ok(model);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, CitizenCharterStages model)
    {
        var existing = _context.CitizenCharterStages.Find(id);
        if (existing == null) return NotFound();

        existing.GroupId = model.GroupId;
        existing.StageName = model.StageName;
        existing.Description = model.Description;

        _context.SaveChanges();
        return Ok(existing);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var item = _context.CitizenCharterStages.Find(id);
        if (item == null) return NotFound();

        _context.CitizenCharterStages.Remove(item);
        _context.SaveChanges();
        return Ok();
    }
}
