using NArchitecture.Core.Application.Responses;

namespace Application.Features.Transactions.Commands.Delete;

public class DeletedTransactionResponse : IResponse
{
    public int Id { get; set; }
}