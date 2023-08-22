using Domain.Exceptions;
using Domain.Repositories;
using MediatR;

namespace Application.Business.AppUsers.Delete;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IAppUserRepository _appUserRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserCommandHandler(
        IAppUserRepository appUserRepository,
        IUnitOfWork unitOfWork)
    {
        _appUserRepository = appUserRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _appUserRepository.GetByIdAsync(request.UserId);

        if (user == null)
        {
            throw new UserNotFoundException(request.UserId);
        }
        
        _appUserRepository.Remove(user);
        _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}