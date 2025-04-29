using Application.Features.CompanyAddresses.Commands.Create;
using Application.Features.CompanyAddresses.Commands.Delete;
using Application.Features.CompanyAddresses.Commands.Update;
using Application.Features.CompanyAddresses.Queries.GetById;
using Application.Features.CompanyAddresses.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyAddressesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedCompanyAddressResponse>> Add([FromBody] CreateCompanyAddressCommand command)
    {
        CreatedCompanyAddressResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedCompanyAddressResponse>> Update([FromBody] UpdateCompanyAddressCommand command)
    {
        UpdatedCompanyAddressResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedCompanyAddressResponse>> Delete([FromRoute] int id)
    {
        DeleteCompanyAddressCommand command = new() { Id = id };

        DeletedCompanyAddressResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdCompanyAddressResponse>> GetById([FromRoute] int id)
    {
        GetByIdCompanyAddressQuery query = new() { Id = id };

        GetByIdCompanyAddressResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListCompanyAddressListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCompanyAddressQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListCompanyAddressListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}