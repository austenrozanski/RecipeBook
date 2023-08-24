using Application.Business.Activities.Models;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Business.Activities.Get;

public class GetActivityQueryHandler : IRequestHandler<GetActivityQuery, ActivityResponse>
{
    private readonly IActivityRepository _activityRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetActivityQueryHandler(
        IActivityRepository activityRepository,
        IUnitOfWork unitOfWork)
    {
        _activityRepository = activityRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ActivityResponse> Handle(GetActivityQuery request, CancellationToken cancellationToken)
    {
        var activity = await _activityRepository.GetByIdAsync(request.ActivityId, cancellationToken);

        var response = new ActivityResponse(activity);
        return response;
    }
}