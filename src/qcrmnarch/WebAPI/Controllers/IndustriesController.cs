using Application.Features.Industries.Commands.Create;
using Application.Features.Industries.Commands.Delete;
using Application.Features.Industries.Commands.Update;
using Application.Features.Industries.Queries.GetById;
using Application.Features.Industries.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IndustriesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedIndustryResponse>> Add([FromBody] CreateIndustryCommand command)
    {
        CreatedIndustryResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedIndustryResponse>> Update([FromBody] UpdateIndustryCommand command)
    {
        UpdatedIndustryResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedIndustryResponse>> Delete([FromRoute] int id)
    {
        DeleteIndustryCommand command = new() { Id = id };

        DeletedIndustryResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdIndustryResponse>> GetById([FromRoute] int id)
    {
        GetByIdIndustryQuery query = new() { Id = id };

        GetByIdIndustryResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListIndustryListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListIndustryQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListIndustryListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}