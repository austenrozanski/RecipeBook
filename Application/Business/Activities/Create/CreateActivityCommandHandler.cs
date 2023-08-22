using Domain.Repositories;
using MediatR;

namespace Application.Business.Activities.Create;

public class CreateActivityCommandHandler : IRequestHandler<CreateActivityCommand>
{
    private readonly IActivityRepository _activityRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateActivityCommandHandler(
        IActivityRepository activityRepository,
        IUnitOfWork unitOfWork)
    {
        _activityRepository = activityRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateActivityCommand request, CancellationToken cancellationToken)
    {
        var activity = request.Activity.ToActivityEntity();
        _activityRepository.Add(activity);
        _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}