using Domain.Exceptions;
using Domain.Repositories;
using MediatR;

namespace Application.Business.Friends.Delete;

public class DeleteFriendRequestCommandHandler : IRequestHandler<DeleteFriendRequestCommand>
{
    private readonly IFriendRepository _friendRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteFriendRequestCommandHandler(
        IFriendRepository friendRepository,
        IUnitOfWork unitOfWork)
    {
        _friendRepository = friendRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteFriendRequestCommand request, CancellationToken cancellationToken)
    {
        var friendRequest = await _friendRepository.GetByIdAsync(request.FriendRequestId);

        if (friendRequest == null)
        {
            throw new FriendRequestNotFoundException(request.FriendRequestId);
        }

        _friendRepository.Remove(friendRequest);
        _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}