using Application.Features.CompanyImages.Commands.Create;
using Application.Features.CompanyImages.Commands.Delete;
using Application.Features.CompanyImages.Commands.Update;
using Application.Features.CompanyImages.Queries.GetById;
using Application.Features.CompanyImages.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyImagesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedCompanyImageResponse>> Add([FromBody] CreateCompanyImageCommand command)
    {
        CreatedCompanyImageResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedCompanyImageResponse>> Update([FromBody] UpdateCompanyImageCommand command)
    {
        UpdatedCompanyImageResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedCompanyImageResponse>> Delete([FromRoute] Guid id)
    {
        DeleteCompanyImageCommand command = new() { Id = id };

        DeletedCompanyImageResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdCompanyImageResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdCompanyImageQuery query = new() { Id = id };

        GetByIdCompanyImageResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListCompanyImageListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCompanyImageQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListCompanyImageListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}