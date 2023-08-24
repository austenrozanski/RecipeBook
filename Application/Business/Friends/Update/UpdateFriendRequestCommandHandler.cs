using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Business.Friends.Update;

public class UpdateFriendRequestCommandHandler : IRequestHandler<UpdateFriendRequestCommand>
{
    private readonly IFriendRepository _friendRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateFriendRequestCommandHandler(
        IFriendRepository friendRepository,
        IUnitOfWork unitOfWork)
    {
        _friendRepository = friendRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateFriendRequestCommand request, CancellationToken cancellationToken)
    {
        var friendRequest = await _friendRepository.GetByIdAsync(request.FriendRequestId, cancellationToken);

        if (friendRequest == null)
        {
            throw new FriendRequestNotFoundException(request.FriendRequestId);
        }

        friendRequest.UserId = request.FriendRequest.UserId;
        friendRequest.FriendId = request.FriendRequest.FriendId;
        friendRequest.IsPending = request.FriendRequest.IsPending;
        friendRequest.AcceptedDate = request.FriendRequest.AcceptedDate;
        friendRequest.SentDate = request.FriendRequest.SentDate;
        friendRequest.IsDeleted = request.FriendRequest.IsDeleted;

        _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}