using Application.Features.Transactions.Commands.Create;
using Application.Features.Transactions.Commands.Delete;
using Application.Features.Transactions.Commands.Update;
using Application.Features.Transactions.Queries.GetById;
using Application.Features.Transactions.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransactionsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedTransactionResponse>> Add([FromBody] CreateTransactionCommand command)
    {
        CreatedTransactionResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedTransactionResponse>> Update([FromBody] UpdateTransactionCommand command)
    {
        UpdatedTransactionResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedTransactionResponse>> Delete([FromRoute] int id)
    {
        DeleteTransactionCommand command = new() { Id = id };

        DeletedTransactionResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdTransactionResponse>> GetById([FromRoute] int id)
    {
        GetByIdTransactionQuery query = new() { Id = id };

        GetByIdTransactionResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListTransactionListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTransactionQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListTransactionListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}