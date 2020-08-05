using System.Threading.Tasks;
using Xunit;
using Moq;
using API.Controllers.Radios;
using API.Controllers.Radios.Models;
using API.Services;
using API.Data.Models;
using Microsoft.AspNetCore.Mvc;
namespace API.Tests.Controllers
{
    public class RadiosControllerTests
    {
        [Fact]
        public async Task CreateRadio_AlreadyExist_400()
        {
            var mockRadioService = new Mock<IRadioService>();
            var radioInput = new RadioInputModel();
            var radioId = 1;
            SetUpFind(mockRadioService, radioId, new Radio());

            var controller = new API.Controllers.Radios.RadiosController(mockRadioService.Object);

            var res = await controller.CreateRadio(radioId, radioInput);

            Assert.IsType<BadRequestResult>(res);
        }

        [Fact]
        public async Task GetRadioLocations_RadioDoesNotExist_400()
        {
            var mockRadioService = new Mock<IRadioService>();
            var radioId = 1;
            SetUpFind(mockRadioService, radioId, null);
            var controller = new API.Controllers.Radios.RadiosController(mockRadioService.Object);

            var res = await controller.GetRadioLocation(radioId);

            Assert.IsType<BadRequestResult>(res.Result);
        }

        [Fact]
        public async Task GetRadioLocations_RadioHasNoLocation_404()
        {
            var mockRadioService = new Mock<IRadioService>();
            var radioId = 1;
            SetUpFind(mockRadioService, radioId, new Radio());
            var controller = new API.Controllers.Radios.RadiosController(mockRadioService.Object);

            var res = await controller.GetRadioLocation(radioId);

            Assert.IsType<NotFoundResult>(res.Result);
        }

        [Fact]
        public async Task AddRadioLocation_LocationNotInRadioArea_403()
        {
            var mockRadioService = new Mock<IRadioService>();
            var locationInput = new LocationInputModel { Location = "Random Location" };
            var radioId = 1;
            SetUpFind(mockRadioService, radioId, new Radio() { AllowedLocations = new System.Collections.Generic.List<string>()});

            var controller = new API.Controllers.Radios.RadiosController(mockRadioService.Object);

            var res = await controller.CreateRadioLocation(radioId, locationInput);

            Assert.IsType<StatusCodeResult>(res);
            var objectResponse = res as StatusCodeResult; 
            Assert.Equal(403, objectResponse.StatusCode);
        }

        private void SetUpFind(Mock<IRadioService> mock, int radioId, Radio radio)
        {
            mock.Setup(x => x.FindById(radioId)).Returns(Task.FromResult(radio));
        }
    }
}
