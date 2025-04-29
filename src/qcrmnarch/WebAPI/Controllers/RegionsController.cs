using Application.Features.Regions.Commands.Create;
using Application.Features.Regions.Commands.Delete;
using Application.Features.Regions.Commands.Update;
using Application.Features.Regions.Queries.GetById;
using Application.Features.Regions.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegionsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedRegionResponse>> Add([FromBody] CreateRegionCommand command)
    {
        CreatedRegionResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedRegionResponse>> Update([FromBody] UpdateRegionCommand command)
    {
        UpdatedRegionResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedRegionResponse>> Delete([FromRoute] int id)
    {
        DeleteRegionCommand command = new() { Id = id };

        DeletedRegionResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdRegionResponse>> GetById([FromRoute] int id)
    {
        GetByIdRegionQuery query = new() { Id = id };

        GetByIdRegionResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListRegionListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListRegionQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListRegionListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}