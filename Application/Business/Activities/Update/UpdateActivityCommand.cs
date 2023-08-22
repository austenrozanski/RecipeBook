using Application.Business.Activities.Models;
using MediatR;

namespace Application.Business.Activities.Update;

public class UpdateActivityCommand : IRequest
{
    public long ActivityId { get; set; }
    public ActivityRequest Activity { get; set; }
}