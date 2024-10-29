using Decisison.Maker.API.Data.Entities;
using Decisison.Maker.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Decisison.Maker.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DecisionController : ControllerBase
{
    private readonly IDecisionService _decisionService;

    public DecisionController(IDecisionService decisionService)
    {
        _decisionService = decisionService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Decision>>> GetDecisions()
    {
        try
        {
            var result = await _decisionService.GetAllDecisionsAsync();
            return Ok(result);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Decision>> GetDecisionById(Guid id)
    {
        try
        {
            var result = await _decisionService.GetDecisionByIdAsync(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Decision>> CreateDecision(Decision decision)
    {
        try
        {
            var result = await _decisionService.CreateDecisionAsync(decision);
            return Ok(result);
        }
        catch (Exception e)
        {

            throw new Exception(e.Message);
        }
    }

    [HttpPost("{id}/pros")]
    public async Task<ActionResult<Pro>> AddPro(Guid id, Pro pro)
    {
        try
        {
            var result = await _decisionService.AddProAsync(id, pro);
            if (result == null)
                return NotFound();

            return CreatedAtAction(nameof(GetDecisionById), new {id}, result);
        }
        catch (Exception e)
        {

            throw new Exception(e.Message);
        }
    }

    [HttpPost("{id}/cons")]
    public async Task<ActionResult<Con>> AddCon(Guid id, Con con)
    {
        try
        {
            var result = await _decisionService.AddConAsync(id, con);
            if (result == null)
                return NotFound();

            return CreatedAtAction(nameof(GetDecisionById), new { id }, result);
        }
        catch (Exception e)
        {

            throw new Exception(e.Message);
        }
    }

    [HttpPost("{id}/select")]
    public async Task<ActionResult<UserSelection>> SelectDecision(Guid id, UserSelection selection)
    {
        try
        {
            var result = await _decisionService.SelectDecisionAsync(id, selection);
            if (result == null)
                return NotFound();

            return Ok(result);
        }
        catch (Exception e)
        {

            throw new Exception(e.Message);
        }
    }
}
