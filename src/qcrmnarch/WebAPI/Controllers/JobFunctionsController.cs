using Application.Features.JobFunctions.Commands.Create;
using Application.Features.JobFunctions.Commands.Delete;
using Application.Features.JobFunctions.Commands.Update;
using Application.Features.JobFunctions.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.JobFunctions.Queries.GetById;
namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobFunctionsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedJobFunctionResponse>> Add([FromBody] CreateJobFunctionCommand command)
    {
        CreatedJobFunctionResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedJobFunctionResponse>> Update([FromBody] UpdateJobFunctionCommand command)
    {
        UpdatedJobFunctionResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedJobFunctionResponse>> Delete([FromRoute] int id)
    {
        DeleteJobFunctionCommand command = new() { Id = id };

        DeletedJobFunctionResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdJobFunctionResponse>> GetById([FromRoute] int id)
    {
        GetByIdJobFunctionQuery query = new() { Id = id };

        GetByIdJobFunctionResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListJobFunctionListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListJobFunctionQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListJobFunctionListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
 

}