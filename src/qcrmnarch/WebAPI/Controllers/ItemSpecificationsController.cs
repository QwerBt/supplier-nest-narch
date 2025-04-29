using Application.Features.ItemSpecifications.Commands.Create;
using Application.Features.ItemSpecifications.Commands.Delete;
using Application.Features.ItemSpecifications.Commands.Update;
using Application.Features.ItemSpecifications.Queries.GetById;
using Application.Features.ItemSpecifications.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemSpecificationsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedItemSpecificationResponse>> Add([FromBody] CreateItemSpecificationCommand command)
    {
        CreatedItemSpecificationResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedItemSpecificationResponse>> Update([FromBody] UpdateItemSpecificationCommand command)
    {
        UpdatedItemSpecificationResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedItemSpecificationResponse>> Delete([FromRoute] int id)
    {
        DeleteItemSpecificationCommand command = new() { Id = id };

        DeletedItemSpecificationResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdItemSpecificationResponse>> GetById([FromRoute] int id)
    {
        GetByIdItemSpecificationQuery query = new() { Id = id };

        GetByIdItemSpecificationResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListItemSpecificationListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListItemSpecificationQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListItemSpecificationListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}