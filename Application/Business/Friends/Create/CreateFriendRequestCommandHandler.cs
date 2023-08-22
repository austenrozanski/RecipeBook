using Application.Business.Friends.Models;
using Domain.Repositories;
using MediatR;

namespace Application.Business.Friends.Create;

public class CreateFriendRequestCommandHandler : IRequestHandler<CreateFriendRequestCommand>
{
    private readonly IFriendRepository _friendRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateFriendRequestCommandHandler(
        IFriendRepository friendRepository,
        IUnitOfWork unitOfWork)
    {
        _friendRepository = friendRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateFriendRequestCommand request, CancellationToken cancellationToken)
    {
        var friend = request.friendRequest.ToFriendEntity();
        _friendRepository.Add(friend);
        _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}