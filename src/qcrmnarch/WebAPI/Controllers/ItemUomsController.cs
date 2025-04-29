using Application.Features.ItemUoms.Commands.Create;
using Application.Features.ItemUoms.Commands.Delete;
using Application.Features.ItemUoms.Commands.Update;
using Application.Features.ItemUoms.Queries.GetById;
using Application.Features.ItemUoms.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemUomsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedItemUomResponse>> Add([FromBody] CreateItemUomCommand command)
    {
        CreatedItemUomResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedItemUomResponse>> Update([FromBody] UpdateItemUomCommand command)
    {
        UpdatedItemUomResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedItemUomResponse>> Delete([FromRoute] int id)
    {
        DeleteItemUomCommand command = new() { Id = id };

        DeletedItemUomResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdItemUomResponse>> GetById([FromRoute] int id)
    {
        GetByIdItemUomQuery query = new() { Id = id };

        GetByIdItemUomResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListItemUomListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListItemUomQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListItemUomListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}