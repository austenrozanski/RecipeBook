using Domain.Exceptions;
using Domain.Repositories;
using MediatR;

namespace Application.Business.Activities.Update;

public class UpdateActivityCommandHandler : IRequestHandler<UpdateActivityCommand>
{
    private readonly IActivityRepository _activityRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateActivityCommandHandler(
        IActivityRepository activityRepository,
        IUnitOfWork unitOfWork)
    {
        _activityRepository = activityRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateActivityCommand request, CancellationToken cancellationToken)
    {
        var activity = await _activityRepository.GetByIdAsync(request.ActivityId);

        if (activity == null)
        {
            throw new ActivityNotFoundException(request.ActivityId);
        }

        activity.Title = request.Activity.Title;
        activity.Description = request.Activity.Description;
        activity.Rating = request.Activity.Rating;
        activity.StartTime = request.Activity.StartTime;
        activity.PhotoUrls = request.Activity.PhotoUrls;

        _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}