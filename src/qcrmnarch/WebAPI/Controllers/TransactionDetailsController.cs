using Application.Features.TransactionDetails.Commands.Create;
using Application.Features.TransactionDetails.Commands.Delete;
using Application.Features.TransactionDetails.Commands.Update;
using Application.Features.TransactionDetails.Queries.GetById;
using Application.Features.TransactionDetails.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransactionDetailsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedTransactionDetailResponse>> Add([FromBody] CreateTransactionDetailCommand command)
    {
        CreatedTransactionDetailResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedTransactionDetailResponse>> Update([FromBody] UpdateTransactionDetailCommand command)
    {
        UpdatedTransactionDetailResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedTransactionDetailResponse>> Delete([FromRoute] int id)
    {
        DeleteTransactionDetailCommand command = new() { Id = id };

        DeletedTransactionDetailResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdTransactionDetailResponse>> GetById([FromRoute] int id)
    {
        GetByIdTransactionDetailQuery query = new() { Id = id };

        GetByIdTransactionDetailResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListTransactionDetailListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTransactionDetailQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListTransactionDetailListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}