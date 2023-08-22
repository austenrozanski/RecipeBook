using Application.Business.AppUsers.Models;
using MediatR;

namespace Application.Business.AppUsers.Get;

public class GetUserQuery : IRequest<UserResponse>
{
    public long UserId { get; set; }
}