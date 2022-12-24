using AcaiStoreApi.Models;
using AcaiStoreApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AcaiApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AcaisController : ControllerBase
{
    private readonly AcaisService _acaisService;

    public AcaisController(AcaisService acaisService) =>
        _acaisService = acaisService;

    [HttpGet]
    public async Task<List<Acai>> Get() =>
    await _acaisService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Acai>> Get(string id)
    {
        var acai = await _acaisService.GetAsync(id);

        if (acai is null)
        {
            return NotFound();
        }

        return acai;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Acai newAcai)
    {

        await _acaisService.CreateAsync(newAcai);

        return CreatedAtAction(nameof(Get), new { id = newAcai.Id }, newAcai);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Acai updatedAcai)
    {
        var acai = await _acaisService.GetAsync(id);

        if (acai is null)
        {
            return NotFound();
        }

        updatedAcai.Id = acai.Id;

        await _acaisService.UpdateAsync(id, updatedAcai);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {

        var book = await _acaisService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        await _acaisService.RemoveAsync(id);

        return NoContent();
    }
}

