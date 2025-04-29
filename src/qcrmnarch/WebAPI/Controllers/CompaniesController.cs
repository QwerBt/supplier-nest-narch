using Application.Features.Companies.Commands.Create;
using Application.Features.Companies.Commands.Delete;
using Application.Features.Companies.Commands.Update;
using Application.Features.Companies.Queries.GetById;
using Application.Features.Companies.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompaniesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedCompanyResponse>> Add([FromBody] CreateCompanyCommand command)
    {
        CreatedCompanyResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedCompanyResponse>> Update([FromBody] UpdateCompanyCommand command)
    {
        UpdatedCompanyResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedCompanyResponse>> Delete([FromRoute] int id)
    {
        DeleteCompanyCommand command = new() { Id = id };

        DeletedCompanyResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdCompanyResponse>> GetById([FromRoute] int id)
    {
        GetByIdCompanyQuery query = new() { Id = id };

        GetByIdCompanyResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListCompanyListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCompanyQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListCompanyListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}