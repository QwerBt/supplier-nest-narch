using Application.Features.Items.Commands.Create;
using Application.Features.Items.Commands.Delete;
using Application.Features.Items.Commands.Update;
using Application.Features.Items.Queries.GetById;
using Application.Features.Items.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedItemResponse>> Add([FromBody] CreateItemCommand command)
    {
        CreatedItemResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedItemResponse>> Update([FromBody] UpdateItemCommand command)
    {
        UpdatedItemResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedItemResponse>> Delete([FromRoute] int id)
    {
        DeleteItemCommand command = new() { Id = id };

        DeletedItemResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdItemResponse>> GetById([FromRoute] int id)
    {
        GetByIdItemQuery query = new() { Id = id };

        GetByIdItemResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListItemListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListItemQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListItemListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}