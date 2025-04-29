using Application.Features.CompanyContacts.Commands.Create;
using Application.Features.CompanyContacts.Commands.Delete;
using Application.Features.CompanyContacts.Commands.Update;
using Application.Features.CompanyContacts.Queries.GetById;
using Application.Features.CompanyContacts.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyContactsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedCompanyContactResponse>> Add([FromBody] CreateCompanyContactCommand command)
    {
        CreatedCompanyContactResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedCompanyContactResponse>> Update([FromBody] UpdateCompanyContactCommand command)
    {
        UpdatedCompanyContactResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedCompanyContactResponse>> Delete([FromRoute] int id)
    {
        DeleteCompanyContactCommand command = new() { Id = id };

        DeletedCompanyContactResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdCompanyContactResponse>> GetById([FromRoute] int id)
    {
        GetByIdCompanyContactQuery query = new() { Id = id };

        GetByIdCompanyContactResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListCompanyContactListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCompanyContactQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListCompanyContactListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}