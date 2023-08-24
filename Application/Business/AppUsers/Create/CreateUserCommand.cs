using Application.Business.AppUsers.Models;
using MediatR;

namespace Application.Business.AppUsers.Create;

public class CreateUserCommand : IRequest<long>
{
    public UserRequest User { get; set; }
}