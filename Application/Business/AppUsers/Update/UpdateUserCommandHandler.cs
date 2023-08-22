using Domain.Exceptions;
using Domain.Repositories;
using MediatR;

namespace Application.Business.AppUsers.Update;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly IAppUserRepository _appUserRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserCommandHandler(
        IAppUserRepository appUserRepository,
        IUnitOfWork unitOfWork)
    {
        _appUserRepository = appUserRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _appUserRepository.GetByIdAsync(request.UserId);

        if (user == null)
        {
            throw new UserNotFoundException(request.UserId);
        }

        user.UserName = request.User.UserName;

        _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}