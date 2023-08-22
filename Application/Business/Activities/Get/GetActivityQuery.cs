using Application.Business.Activities.Models;
using MediatR;

namespace Application.Business.Activities.Get;

public class GetActivityQuery : IRequest<ActivityResponse>
{
    public long ActivityId { get; set; }
}