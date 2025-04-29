using Application.Features.CompanyServices.Commands.Create;
using Application.Features.CompanyServices.Commands.Delete;
using Application.Features.CompanyServices.Commands.Update;
using Application.Features.CompanyServices.Queries.GetById;
using Application.Features.CompanyServices.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyServicesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedCompanyServiceResponse>> Add([FromBody] CreateCompanyServiceCommand command)
    {
        CreatedCompanyServiceResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedCompanyServiceResponse>> Update([FromBody] UpdateCompanyServiceCommand command)
    {
        UpdatedCompanyServiceResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedCompanyServiceResponse>> Delete([FromRoute] int id)
    {
        DeleteCompanyServiceCommand command = new() { Id = id };

        DeletedCompanyServiceResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdCompanyServiceResponse>> GetById([FromRoute] int id)
    {
        GetByIdCompanyServiceQuery query = new() { Id = id };

        GetByIdCompanyServiceResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListCompanyServiceListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCompanyServiceQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListCompanyServiceListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}