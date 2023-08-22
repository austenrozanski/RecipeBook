using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Business.AppUsers.Create;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{
    private readonly IAppUserRepository _appUserRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserCommandHandler(
        IAppUserRepository appUserRepository,
        IUnitOfWork unitOfWork)
    {
        _appUserRepository = appUserRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (!await _appUserRepository.IsUserNameUniqueAsync(request.User.UserName))
        {
            throw new UserNameAlreadyExistsException();
        }
        
        var user = request.User.ToUserEntity();
        _appUserRepository.Add(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}