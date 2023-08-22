using Application.Business.Activities.Create;
using Application.Business.Activities.Delete;
using Application.Business.Activities.Get;
using Application.Business.Activities.Models;
using Application.Business.Activities.Update;
using Application.Business.Recipes.Models;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActivitiesController : ControllerBase
{
    private readonly ISender _sender;

    public ActivitiesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ActivityResponse>> GetActivity(int id)
    {
        try
        {
            var request = new GetActivityQuery()
            {
                ActivityId = id
            };

            var response = await _sender.Send(request);
            return Ok(response);
        }
        catch (ActivityNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateActivity([FromBody] ActivityRequest activity)
    {
        var request = new CreateActivityCommand()
        {
            Activity = activity
        };

        await _sender.Send(request);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateActivity(int id, [FromBody] ActivityRequest activity)
    {
        try
        {
            var request = new UpdateActivityCommand()
            {
                ActivityId = id,
                Activity = activity
            };

            await _sender.Send(request);
            return Ok();
        }
        catch (ActivityNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteActivity(int id)
    {
        try
        {
            var request = new DeleteActivityCommand()
            {
                ActivityId = id
            };

            await _sender.Send(request);
            return Ok();
        }
        catch (ActivityNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}