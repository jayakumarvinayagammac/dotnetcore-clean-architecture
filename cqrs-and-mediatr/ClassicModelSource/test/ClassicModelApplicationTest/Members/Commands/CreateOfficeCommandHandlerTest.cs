using AutoMapper;
using ClassicModelApplication.Commands;
using ClassicModelApplication.DataTransferObjects;
using ClassicModelApplication.Handlers;
using ClassicModelDomain.DataEntities;
using ClassicModelDomain.DomainEntities;
using ClassicModelDomain.InfrastructureRepositories;
using FluentAssertions;
using Moq;

namespace ClassicModelApplicationTest.Members.Commands;

public class CreateOfficeCommandHandlerTest
{
    private readonly Mock<IOfficeRepository> _officeRepository;
    private readonly Mock<IMapper> _mapper;
    public CreateOfficeCommandHandlerTest()
    {
        _officeRepository = new();
        _mapper = new();
    }
    [Fact]
    public void Test()
    {
        string actual = "ABCDEFGHI";
        actual.Should().StartWith("AB").And.EndWith("HI").And.Contain("EF").And.HaveLength(9);
    }

    [Fact]
    public async Task Handle_Should_ReturnSuccessResult_WhenRequestHasValid()
    {
        // Arrange
        OfficeDTO Office = new OfficeDTO("", "", "", "", "", "", "", "", "");
        var command = new CreateOfficeCommand(Office);
        _officeRepository.Setup(
            x=> x.CreatetOfficeAsync(It.IsAny<OfficeModel>())
        ).ReturnsAsync("10");

        var commandHandler = new CreateOfficeCommandHandler(_officeRepository.Object, _mapper.Object);
        // Act
        OfficeCreationResult result = await commandHandler.Handle(command, default);
        // Assert
        result.OfficeCode.Should()
            .NotBeEmpty()
            .And
            .Be("10");
    }
}