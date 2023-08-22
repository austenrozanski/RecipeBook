using MediatR;

namespace Application.Business.AppUsers.Delete;

public class DeleteUserCommand : IRequest
{
    public long UserId { get; set; }
}