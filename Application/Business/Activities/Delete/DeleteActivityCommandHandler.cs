using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Business.Activities.Delete;

public class DeleteActivityCommandHandler : IRequestHandler<DeleteActivityCommand>
{
    private readonly IActivityRepository _activityRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteActivityCommandHandler(
        IActivityRepository activityRepository,
        IUnitOfWork unitOfWork)
    {
        _activityRepository = activityRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteActivityCommand request, CancellationToken cancellationToken)
    {
        var activity = await _activityRepository.GetByIdAsync(request.ActivityId, cancellationToken);

        if (activity == null)
        {
            throw new ActivityNotFoundException(request.ActivityId);
        }

        _activityRepository.Remove(activity);
        _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}