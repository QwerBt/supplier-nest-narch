using Application.Features.JobLevels.Commands.Create;
using Application.Features.JobLevels.Commands.Delete;
using Application.Features.JobLevels.Commands.Update;
using Application.Features.JobLevels.Queries.GetById;
using Application.Features.JobLevels.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobLevelsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedJobLevelResponse>> Add([FromBody] CreateJobLevelCommand command)
    {
        CreatedJobLevelResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedJobLevelResponse>> Update([FromBody] UpdateJobLevelCommand command)
    {
        UpdatedJobLevelResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedJobLevelResponse>> Delete([FromRoute] int id)
    {
        DeleteJobLevelCommand command = new() { Id = id };

        DeletedJobLevelResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdJobLevelResponse>> GetById([FromRoute] int id)
    {
        GetByIdJobLevelQuery query = new() { Id = id };

        GetByIdJobLevelResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListJobLevelListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListJobLevelQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListJobLevelListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}