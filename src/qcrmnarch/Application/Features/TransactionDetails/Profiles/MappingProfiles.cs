using Application.Features.TransactionDetails.Commands.Create;
using Application.Features.TransactionDetails.Commands.Delete;
using Application.Features.TransactionDetails.Commands.Update;
using Application.Features.TransactionDetails.Queries.GetById;
using Application.Features.TransactionDetails.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.TransactionDetails.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateTransactionDetailCommand, TransactionDetail>();
        CreateMap<TransactionDetail, CreatedTransactionDetailResponse>();

        CreateMap<UpdateTransactionDetailCommand, TransactionDetail>();
        CreateMap<TransactionDetail, UpdatedTransactionDetailResponse>();

        CreateMap<DeleteTransactionDetailCommand, TransactionDetail>();
        CreateMap<TransactionDetail, DeletedTransactionDetailResponse>();

        CreateMap<TransactionDetail, GetByIdTransactionDetailResponse>();

        CreateMap<TransactionDetail, GetListTransactionDetailListItemDto>();
        CreateMap<IPaginate<TransactionDetail>, GetListResponse<GetListTransactionDetailListItemDto>>();
    }
}