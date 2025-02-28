using MongoDB.Bson;

namespace OrderFlow.Application.Tests.Handlers;

public class CreateOrderCommandHandlerTests
{
    private readonly IFixture _fixture;

    public CreateOrderCommandHandlerTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        _fixture.Register(() => ObjectId.GenerateNewId());
    }

    [Fact]
    public async Task Handle_ValidCommand_ReturnsSuccessResponse()
    {
        // Arrange
        var command = _fixture.Create<CreateOrderCommand>();
        var order = _fixture.Create<Order>();

        var validatorMock = _fixture.Freeze<Mock<IValidator<CreateOrderCommand>>>();
        validatorMock
            .Setup(v => v.ValidateAsync(command, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ValidationResult());

        var mapperMock = _fixture.Freeze<Mock<IMapper>>();
        mapperMock
            .Setup(m => m.Map<Order>(command))
            .Returns(order);

        var repositoryMock = _fixture.Freeze<Mock<IOrderRepository>>();
        repositoryMock
            .Setup(r => r.SaveAsync(order))
            .Returns(Task.CompletedTask);

        var mediatorMock = _fixture.Freeze<Mock<IMediator>>();

        var handler = _fixture.Create<CreateOrderCommandHandler>();

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(order.Id.ToString(), result.OrderId);

        repositoryMock.Verify(r => r.SaveAsync(order), Times.Once);
        mediatorMock.Verify(m => m.Publish(It.IsAny<IDomainEvent>(), It.IsAny<CancellationToken>()), Times.Exactly(order.DomainEvents.Count));
    }

    [Fact]
    public async Task Handle_InvalidCommand_ReturnsFailureResponse()
    {
        // Arrange
        var command = _fixture.Create<CreateOrderCommand>();
        var validationErrors = _fixture.CreateMany<ValidationFailure>().ToList();

        var validatorMock = _fixture.Freeze<Mock<IValidator<CreateOrderCommand>>>();
        validatorMock
            .Setup(v => v.ValidateAsync(command, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ValidationResult(validationErrors));

        var handler = _fixture.Create<CreateOrderCommandHandler>();

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(validationErrors.Select(e => e.ErrorMessage), result.Errors);
    }

    [Fact]
    public async Task Handle_ApplicationException_ReturnsFailureResponse()
    {
        // Arrange
        var command = _fixture.Create<CreateOrderCommand>();
        var exceptionMessage = "Application error";

        var validatorMock = _fixture.Freeze<Mock<IValidator<CreateOrderCommand>>>();
        validatorMock
            .Setup(v => v.ValidateAsync(command, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ValidationResult());

        var mapperMock = _fixture.Freeze<Mock<IMapper>>();
        mapperMock
            .Setup(m => m.Map<Order>(command))
            .Throws(new ApplicationException(exceptionMessage));

        var handler = _fixture.Create<CreateOrderCommandHandler>();

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(exceptionMessage, result.Errors.Single());
    }

    [Fact]
    public async Task Handle_DomainException_ThrowsDomainException()
    {
        // Arrange
        var command = _fixture.Create<CreateOrderCommand>();
        var exceptionMessage = "Domain error";

        var validatorMock = _fixture.Freeze<Mock<IValidator<CreateOrderCommand>>>();
        validatorMock
            .Setup(v => v.ValidateAsync(command, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ValidationResult());

        var mapperMock = _fixture.Freeze<Mock<IMapper>>();
        mapperMock
            .Setup(m => m.Map<Order>(command))
            .Throws(new DomainException(exceptionMessage));

        var handler = _fixture.Create<CreateOrderCommandHandler>();

        // Act & Assert
        await Assert.ThrowsAsync<DomainException>(() => handler.Handle(command, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_GenericException_ThrowsException()
    {
        // Arrange
        var command = _fixture.Create<CreateOrderCommand>();
        var exceptionMessage = "Generic error";

        var validatorMock = _fixture.Freeze<Mock<IValidator<CreateOrderCommand>>>();
        validatorMock
            .Setup(v => v.ValidateAsync(command, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ValidationResult());

        var mapperMock = _fixture.Freeze<Mock<IMapper>>();
        mapperMock
            .Setup(m => m.Map<Order>(command))
            .Throws(new Exception(exceptionMessage));

        var handler = _fixture.Create<CreateOrderCommandHandler>();

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => handler.Handle(command, CancellationToken.None));
    }
}