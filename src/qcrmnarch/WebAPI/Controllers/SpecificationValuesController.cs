using Application.Features.SpecificationValues.Commands.Create;
using Application.Features.SpecificationValues.Commands.Delete;
using Application.Features.SpecificationValues.Commands.Update;
using Application.Features.SpecificationValues.Queries.GetById;
using Application.Features.SpecificationValues.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpecificationValuesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedSpecificationValueResponse>> Add([FromBody] CreateSpecificationValueCommand command)
    {
        CreatedSpecificationValueResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedSpecificationValueResponse>> Update([FromBody] UpdateSpecificationValueCommand command)
    {
        UpdatedSpecificationValueResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedSpecificationValueResponse>> Delete([FromRoute] int id)
    {
        DeleteSpecificationValueCommand command = new() { Id = id };

        DeletedSpecificationValueResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdSpecificationValueResponse>> GetById([FromRoute] int id)
    {
        GetByIdSpecificationValueQuery query = new() { Id = id };

        GetByIdSpecificationValueResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListSpecificationValueListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSpecificationValueQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListSpecificationValueListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}