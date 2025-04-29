using Application.Features.Towns.Commands.Create;
using Application.Features.Towns.Commands.Delete;
using Application.Features.Towns.Commands.Update;
using Application.Features.Towns.Queries.GetById;
using Application.Features.Towns.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TownsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedTownResponse>> Add([FromBody] CreateTownCommand command)
    {
        CreatedTownResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedTownResponse>> Update([FromBody] UpdateTownCommand command)
    {
        UpdatedTownResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedTownResponse>> Delete([FromRoute] int id)
    {
        DeleteTownCommand command = new() { Id = id };

        DeletedTownResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdTownResponse>> GetById([FromRoute] int id)
    {
        GetByIdTownQuery query = new() { Id = id };

        GetByIdTownResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListTownListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTownQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListTownListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}