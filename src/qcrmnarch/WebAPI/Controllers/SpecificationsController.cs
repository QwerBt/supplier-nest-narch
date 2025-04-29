using Application.Features.Specifications.Commands.Create;
using Application.Features.Specifications.Commands.Delete;
using Application.Features.Specifications.Commands.Update;
using Application.Features.Specifications.Queries.GetById;
using Application.Features.Specifications.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpecificationsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedSpecificationResponse>> Add([FromBody] CreateSpecificationCommand command)
    {
        CreatedSpecificationResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedSpecificationResponse>> Update([FromBody] UpdateSpecificationCommand command)
    {
        UpdatedSpecificationResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedSpecificationResponse>> Delete([FromRoute] int id)
    {
        DeleteSpecificationCommand command = new() { Id = id };

        DeletedSpecificationResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdSpecificationResponse>> GetById([FromRoute] int id)
    {
        GetByIdSpecificationQuery query = new() { Id = id };

        GetByIdSpecificationResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListSpecificationListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSpecificationQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListSpecificationListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}