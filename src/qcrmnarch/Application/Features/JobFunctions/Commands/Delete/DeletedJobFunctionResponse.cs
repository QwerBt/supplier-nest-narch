using NArchitecture.Core.Application.Responses;

namespace Application.Features.JobFunctions.Commands.Delete;

public class DeletedJobFunctionResponse : IResponse
{
    public int Id { get; set; }
}