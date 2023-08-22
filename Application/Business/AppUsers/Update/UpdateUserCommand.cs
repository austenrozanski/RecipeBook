using Application.Business.AppUsers.Models;
using MediatR;

namespace Application.Business.AppUsers.Update;

public class UpdateUserCommand : IRequest
{
    public long UserId { get; set; }
    public UserRequest User { get; set; }
}