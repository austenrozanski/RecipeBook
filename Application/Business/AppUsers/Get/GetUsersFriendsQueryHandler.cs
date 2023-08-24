using Application.Business.AppUsers.Models;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Business.AppUsers.Get;

public class GetUsersFriendsQueryHandler : IRequestHandler<GetUsersFriendsQuery,IEnumerable<UserSummaryResponse>>
{
    private readonly IFriendRepository _friendRepository;
    private readonly IAppUserRepository _appUserRepository;

    public GetUsersFriendsQueryHandler(
        IFriendRepository friendRepository,
        IAppUserRepository appUserRepository)
    {
        _friendRepository = friendRepository;
        _appUserRepository = appUserRepository;
    }

    public async Task<IEnumerable<UserSummaryResponse>> Handle(GetUsersFriendsQuery request, CancellationToken cancellationToken)
    {
        var friends = await _friendRepository.GetFriendsOfUserAsync(request.UserId, cancellationToken);
        var friendIds = friends.Select(f => f.FriendId).ToList();

        var users = await _appUserRepository.GetByIdsAsync(friendIds, cancellationToken);
        var userSummaries = users.Select(f => new UserSummaryResponse(f));
        return userSummaries;
    }
}