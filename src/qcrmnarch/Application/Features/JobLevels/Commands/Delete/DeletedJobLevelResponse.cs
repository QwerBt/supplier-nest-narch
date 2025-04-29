using NArchitecture.Core.Application.Responses;

namespace Application.Features.JobLevels.Commands.Delete;

public class DeletedJobLevelResponse : IResponse
{
    public int Id { get; set; }
}