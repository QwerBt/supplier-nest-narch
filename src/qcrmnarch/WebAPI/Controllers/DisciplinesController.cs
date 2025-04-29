using Application.Features.Disciplines.Commands.Create;
using Application.Features.Disciplines.Commands.Delete;
using Application.Features.Disciplines.Commands.Update;
using Application.Features.Disciplines.Queries.GetById;
using Application.Features.Disciplines.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DisciplinesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedDisciplineResponse>> Add([FromBody] CreateDisciplineCommand command)
    {
        CreatedDisciplineResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedDisciplineResponse>> Update([FromBody] UpdateDisciplineCommand command)
    {
        UpdatedDisciplineResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedDisciplineResponse>> Delete([FromRoute] int id)
    {
        DeleteDisciplineCommand command = new() { Id = id };

        DeletedDisciplineResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdDisciplineResponse>> GetById([FromRoute] int id)
    {
        GetByIdDisciplineQuery query = new() { Id = id };

        GetByIdDisciplineResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListDisciplineListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListDisciplineQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListDisciplineListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}