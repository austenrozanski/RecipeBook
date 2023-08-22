using Application.Business.Activities.Models;
using MediatR;

namespace Application.Business.Activities.Create;

public class CreateActivityCommand : IRequest
{
    public ActivityRequest Activity { get; set; }
}