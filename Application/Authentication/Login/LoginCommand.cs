using MediatR;

namespace Application.Authentication.Login;

public class LoginCommand : IRequest<string>
{
    public string UserName { get; set; }
}