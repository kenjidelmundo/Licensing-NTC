using LicensingAPI.Data;
using LicensingAPI.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CitizenCharterFormulaController : ControllerBase
{
    private readonly ApplicationDBContext _context;

    public CitizenCharterFormulaController(ApplicationDBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get() =>
        Ok(_context.CitizenCharterFormulas.ToList());

    [HttpGet("by-stage/{stageId}")]
    public IActionResult GetByStage(int stageId) =>
        Ok(_context.CitizenCharterFormulas
            .Where(f => f.StageId == stageId)
            .ToList());

    [HttpPost]
    public IActionResult Post(CitizenCharterFormula model)
    {
        if (!_context.CitizenCharterStages.Any(s => s.StageId == model.StageId))
            return BadRequest("Invalid StageId");

        _context.CitizenCharterFormulas.Add(model);
        _context.SaveChanges();
        return Ok(model);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, CitizenCharterFormula model)
    {
        var existing = _context.CitizenCharterFormulas.Find(id);
        if (existing == null) return NotFound();

        existing.StageId = model.StageId;
        existing.FormulaDescription = model.FormulaDescription;

        _context.SaveChanges();
        return Ok(existing);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var item = _context.CitizenCharterFormulas.Find(id);
        if (item == null) return NotFound();

        _context.CitizenCharterFormulas.Remove(item);
        _context.SaveChanges();
        return Ok();
    }
}
