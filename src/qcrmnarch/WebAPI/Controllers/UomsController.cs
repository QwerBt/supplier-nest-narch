using Application.Features.Uoms.Commands.Create;
using Application.Features.Uoms.Commands.Delete;
using Application.Features.Uoms.Commands.Update;
using Application.Features.Uoms.Queries.GetById;
using Application.Features.Uoms.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UomsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedUomResponse>> Add([FromBody] CreateUomCommand command)
    {
        CreatedUomResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedUomResponse>> Update([FromBody] UpdateUomCommand command)
    {
        UpdatedUomResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedUomResponse>> Delete([FromRoute] int id)
    {
        DeleteUomCommand command = new() { Id = id };

        DeletedUomResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdUomResponse>> GetById([FromRoute] int id)
    {
        GetByIdUomQuery query = new() { Id = id };

        GetByIdUomResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListUomListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUomQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListUomListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}