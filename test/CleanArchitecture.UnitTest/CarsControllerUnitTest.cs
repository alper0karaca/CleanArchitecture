using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Presentation.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CleanArchitecture.UnitTest;

public class CarsControllerUnitTest
{
    [Fact]
    public async void Create_ReturnsOkResult_WhenRequestIsValid()
    {
        /* 3 parçadan oluşur
         * 1. Arrange: Tanımlamları yaptığımız parça
         *
         * 2. Act : Eylem parçası -> işlemi yap sonucu bir değişkene at
         * 3. Assert : Act'te elde ettiğimiz sonucu burada kontrol ederiz
         */
        
        // 1. Arrange
        var meditorMock = new Mock<IMediator>();
        CreateCarCommand createCarCommand = new CreateCarCommand(
            "Toyota","Corolla", 200);
        MessageResponse response = new MessageResponse("Araç başarıyla kayıt edildi");
        CancellationToken cancellationToken = new CancellationToken();

        meditorMock.Setup(m => m.Send(createCarCommand, cancellationToken))
            .ReturnsAsync(response);

        CarsController carsController = new CarsController(meditorMock.Object);

        // 2. Act
        var result = await carsController.Create(createCarCommand, cancellationToken);

        // Assert 
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<MessageResponse>(okResult.Value);
        
        Assert.Equal(response, returnValue);
        meditorMock.Verify(m => m.Send(createCarCommand, cancellationToken),
            Times.Once);
    }
}