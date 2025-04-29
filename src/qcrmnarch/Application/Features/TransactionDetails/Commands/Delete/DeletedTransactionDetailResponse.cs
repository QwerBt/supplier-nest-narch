using NArchitecture.Core.Application.Responses;

namespace Application.Features.TransactionDetails.Commands.Delete;

public class DeletedTransactionDetailResponse : IResponse
{
    public int Id { get; set; }
}