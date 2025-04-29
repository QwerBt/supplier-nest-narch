using Application.Features.CompanyCategories.Commands.Create;
using Application.Features.CompanyCategories.Commands.Delete;
using Application.Features.CompanyCategories.Commands.Update;
using Application.Features.CompanyCategories.Queries.GetById;
using Application.Features.CompanyCategories.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.CompanyCategories.Queries.GetListByDynamic;
using NArchitecture.Core.Persistence.Dynamic;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyCategoriesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedCompanyCategoryResponse>> Add([FromBody] CreateCompanyCategoryCommand command)
    {
        CreatedCompanyCategoryResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedCompanyCategoryResponse>> Update([FromBody] UpdateCompanyCategoryCommand command)
    {
        UpdatedCompanyCategoryResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedCompanyCategoryResponse>> Delete([FromRoute] int id)
    {
        DeleteCompanyCategoryCommand command = new() { Id = id };

        DeletedCompanyCategoryResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdCompanyCategoryResponse>> GetById([FromRoute] int id)
    {
        GetByIdCompanyCategoryQuery query = new() { Id = id };

        GetByIdCompanyCategoryResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListCompanyCategoryListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCompanyCategoryQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListCompanyCategoryListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }



    [HttpPost("GetListByDynamic")]
    public async Task<ActionResult<GetListByDynamicCompanyCategoryResponse>> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery? dynamicQuery=null)
    {

        GetListByDynamicQuery getListByDynamicQuery = new() { PageRequest = pageRequest, DynamicQuery = dynamicQuery };
        GetListResponse<GetListByDynamicCompanyCategoryResponse> response = await Mediator.Send(getListByDynamicQuery);


        return Ok(response);
    }
}
