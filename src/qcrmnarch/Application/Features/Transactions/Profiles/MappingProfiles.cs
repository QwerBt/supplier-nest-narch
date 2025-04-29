using Application.Features.Transactions.Commands.Create;
using Application.Features.Transactions.Commands.Delete;
using Application.Features.Transactions.Commands.Update;
using Application.Features.Transactions.Queries.GetById;
using Application.Features.Transactions.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Transactions.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateTransactionCommand, Transaction>();
        CreateMap<Transaction, CreatedTransactionResponse>();

        CreateMap<UpdateTransactionCommand, Transaction>();
        CreateMap<Transaction, UpdatedTransactionResponse>();

        CreateMap<DeleteTransactionCommand, Transaction>();
        CreateMap<Transaction, DeletedTransactionResponse>();

        CreateMap<Transaction, GetByIdTransactionResponse>();

        CreateMap<Transaction, GetListTransactionListItemDto>();
        CreateMap<IPaginate<Transaction>, GetListResponse<GetListTransactionListItemDto>>();
    }
}