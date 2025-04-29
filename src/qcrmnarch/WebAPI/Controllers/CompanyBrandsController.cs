using Application.Features.CompanyBrands.Commands.Create;
using Application.Features.CompanyBrands.Commands.Delete;
using Application.Features.CompanyBrands.Commands.Update;
using Application.Features.CompanyBrands.Queries.GetById;
using Application.Features.CompanyBrands.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyBrandsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedCompanyBrandResponse>> Add([FromBody] CreateCompanyBrandCommand command)
    {
        CreatedCompanyBrandResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedCompanyBrandResponse>> Update([FromBody] UpdateCompanyBrandCommand command)
    {
        UpdatedCompanyBrandResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedCompanyBrandResponse>> Delete([FromRoute] int id)
    {
        DeleteCompanyBrandCommand command = new() { Id = id };

        DeletedCompanyBrandResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdCompanyBrandResponse>> GetById([FromRoute] int id)
    {
        GetByIdCompanyBrandQuery query = new() { Id = id };

        GetByIdCompanyBrandResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListCompanyBrandListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCompanyBrandQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListCompanyBrandListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}