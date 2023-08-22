using MediatR;

namespace Application.Business.Activities.Delete;

public class DeleteActivityCommand : IRequest
{
    public long ActivityId { get; set; }
}