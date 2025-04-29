using Application.Features.CompanyUsers.Commands.Create;
using Application.Features.CompanyUsers.Commands.Delete;
using Application.Features.CompanyUsers.Commands.Update;
using Application.Features.CompanyUsers.Queries.GetById;
using Application.Features.CompanyUsers.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyUsersController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedCompanyUserResponse>> Add([FromBody] CreateCompanyUserCommand command)
    {
        CreatedCompanyUserResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedCompanyUserResponse>> Update([FromBody] UpdateCompanyUserCommand command)
    {
        UpdatedCompanyUserResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedCompanyUserResponse>> Delete([FromRoute] int id)
    {
        DeleteCompanyUserCommand command = new() { Id = id };

        DeletedCompanyUserResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdCompanyUserResponse>> GetById([FromRoute] int id)
    {
        GetByIdCompanyUserQuery query = new() { Id = id };

        GetByIdCompanyUserResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListCompanyUserListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCompanyUserQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListCompanyUserListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}