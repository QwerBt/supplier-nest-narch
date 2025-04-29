using Application.Features.Services.Commands.Create;
using Application.Features.Services.Commands.Delete;
using Application.Features.Services.Commands.Update;
using Application.Features.Services.Queries.GetById;
using Application.Features.Services.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServicesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedServiceResponse>> Add([FromBody] CreateServiceCommand command)
    {
        CreatedServiceResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedServiceResponse>> Update([FromBody] UpdateServiceCommand command)
    {
        UpdatedServiceResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedServiceResponse>> Delete([FromRoute] int id)
    {
        DeleteServiceCommand command = new() { Id = id };

        DeletedServiceResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdServiceResponse>> GetById([FromRoute] int id)
    {
        GetByIdServiceQuery query = new() { Id = id };

        GetByIdServiceResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListServiceListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListServiceQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListServiceListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}