using System.Windows.Input;
using Application.Interfaces.Services;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Authentication.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
{
    private readonly IAppUserRepository _appUserRepository;
    private readonly IJwtService _jwtService;
    
    public LoginCommandHandler(
        IAppUserRepository appUserRepository,
        IJwtService jwtService)
    {
        _appUserRepository = appUserRepository;
        _jwtService = jwtService;
    }
    
    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _appUserRepository.GetByUserNameAsync(request.UserName);

        if (user == null)
        {
            throw new UserNotFoundException(request.UserName);
        }
        
        var token = _jwtService.Generate(user);
        return token;
    }
}