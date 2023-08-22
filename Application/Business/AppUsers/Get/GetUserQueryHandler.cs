using Application.Business.AppUsers.Models;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Business.AppUsers.Get;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserResponse>
{
    private readonly IAppUserRepository _appUserRepository;

    public GetUserQueryHandler(IAppUserRepository appUserRepository)
    {
        _appUserRepository = appUserRepository;
    }

    public async Task<UserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _appUserRepository.GetByIdAsync(request.UserId);

        if (user == null)
        {
            throw new UserNotFoundException(request.UserId);
        }

        var response = new UserResponse(user);
        return response;
    }
}