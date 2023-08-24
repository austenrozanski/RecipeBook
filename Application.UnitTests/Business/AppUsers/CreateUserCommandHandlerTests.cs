using Xunit;
using Application.Business.AppUsers.Create;
using Application.Business.AppUsers.Models;
using Domain.Entities.AppUser;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Moq;

namespace Application.UnitTests.Business.AppUsers;

public class CreateUserCommandHandlerTests
{
    private readonly Mock<IAppUserRepository> _appUserRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;

    public CreateUserCommandHandlerTests()
    {
        _appUserRepositoryMock = new();
        _unitOfWorkMock = new();
    }
    
    [Fact]
    public async Task Handle_Should_ThrowException_WhenUserNameIsNotUnique()
    {
        // Arrange
        _appUserRepositoryMock.Setup(f =>
                f.IsUserNameUniqueAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);
        
        var command = new CreateUserCommand()
        {
            User = new UserRequest()
            {
                UserName = "myUserName"
            }
        };

        var handler = new CreateUserCommandHandler(
            _appUserRepositoryMock.Object,
            _unitOfWorkMock.Object);

        // Act
        var exception = await Record.ExceptionAsync(() =>
            handler.Handle(command, default));

        // Assert
        Assert.NotNull(exception);
        Assert.IsType<UserNameAlreadyExistsException>(exception);
    }
    
    [Fact]
    public async Task Handle_Should_NotThrowException_WhenUserNameIsUnique()
    {
        // Arrange
        _appUserRepositoryMock.Setup(f =>
                f.IsUserNameUniqueAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);
        
        var command = new CreateUserCommand()
        {
            User = new UserRequest()
            {
                UserName = "myUserName"
            }
        };

        var handler = new CreateUserCommandHandler(
            _appUserRepositoryMock.Object,
            _unitOfWorkMock.Object);

        // Act
        var exception = await Record.ExceptionAsync(() =>
            handler.Handle(command, default));

        // Assert
        Assert.Null(exception);
    }
    
    [Fact]
    public async Task Handle_Should_CallAddOnRepository_WhenUserNameIsUnique()
    {
        // Arrange
        _appUserRepositoryMock.Setup(f =>
                f.IsUserNameUniqueAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);
        
        var command = new CreateUserCommand()
        {
            User = new UserRequest()
            {
                UserName = "myUserName"
            }
        };

        var handler = new CreateUserCommandHandler(
            _appUserRepositoryMock.Object,
            _unitOfWorkMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        _appUserRepositoryMock.Verify(
            f => f.Add(It.Is<AppUser>(a => a.Id == result)),
            Times.Once);
    }
    
    [Fact]
    public async Task Handle_Should_NotCallUnitOfWork_WhenUserNameIsNotUnique()
    {
        // Arrange
        _appUserRepositoryMock.Setup(f =>
                f.IsUserNameUniqueAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);
        
        var command = new CreateUserCommand()
        {
            User = new UserRequest()
            {
                UserName = "myUserName"
            }
        };

        var handler = new CreateUserCommandHandler(
            _appUserRepositoryMock.Object,
            _unitOfWorkMock.Object);

        // Act
        try
        {
            var result = await handler.Handle(command, default);
        }
        catch (Exception e)
        {
        }

        // Assert
        _unitOfWorkMock.Verify(
            f => f.SaveChangesAsync(It.IsAny<CancellationToken>()),
            Times.Never);
    }
}