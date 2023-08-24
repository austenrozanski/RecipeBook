using Application.Business.AppUsers.Create;
using Application.Business.AppUsers.Delete;
using Application.Business.AppUsers.Models;
using Domain.Entities.AppUser;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Moq;
using Xunit;

namespace Application.UnitTests.Business.AppUsers;

public class DeleteUserCommandHandlerTests
{
    private readonly Mock<IAppUserRepository> _appUserRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;

    public DeleteUserCommandHandlerTests()
    {
        _appUserRepositoryMock = new();
        _unitOfWorkMock = new();
    }
    
    [Fact]
    public async Task Handle_Should_ThrowException_WhenUserNotFound()
    {
        // Arrange
        _appUserRepositoryMock.Setup(f =>
                f.GetByIdAsync(
                    It.IsAny<long>(),
                    It.IsAny<CancellationToken>()))
            .ReturnsAsync((AppUser)null);

        var command = new DeleteUserCommand()
        {
            UserId = 123
        };

        var handler = new DeleteUserCommandHandler(
            _appUserRepositoryMock.Object,
            _unitOfWorkMock.Object);

        // Act
        var exception = await Record.ExceptionAsync(() =>
            handler.Handle(command, default));

        // Assert
        Assert.NotNull(exception);
        Assert.IsType<UserNotFoundException>(exception);
    }
    
    [Fact]
    public async Task Handle_Should_CallRemoveOnRepository_WhenUserExists()
    {
        // Arrange
        var userId = 123;
        _appUserRepositoryMock.Setup(f =>
                f.GetByIdAsync(
                    It.IsAny<long>(),
                    It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AppUser()
            {
                UserName = "",
                Id = userId
            });

        var command = new DeleteUserCommand()
        {
            UserId = userId
        };

        var handler = new DeleteUserCommandHandler(
            _appUserRepositoryMock.Object,
            _unitOfWorkMock.Object);


        // Act
        await handler.Handle(command, default);

        // Assert
        _appUserRepositoryMock.Verify(
            f => f.Remove(It.Is<AppUser>(a => a.Id == userId)),
            Times.Once);
    }
    
    [Fact]
    public async Task Handle_Should_NotCallUnitOfWork_WhenUserNotFound()
    {
        // Arrange
        _appUserRepositoryMock.Setup(f =>
                f.GetByIdAsync(
                    It.IsAny<long>(),
                    It.IsAny<CancellationToken>()))
            .ReturnsAsync((AppUser)null);

        var command = new DeleteUserCommand()
        {
            UserId = 123
        };

        var handler = new DeleteUserCommandHandler(
            _appUserRepositoryMock.Object,
            _unitOfWorkMock.Object);

        // Act
        try
        {
            handler.Handle(command, default);
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