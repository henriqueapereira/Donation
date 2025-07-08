using Donation.Controllers;
using Donation.Models;
using Donation.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Donation.Api.Test;


public class UsuarioControllerTest
{
    [Fact]
    public async Task GetUsuarioResultOkWithUsuarios()
    {
        var usuarios = new List<UsuarioModel>() {
                new UsuarioModel()
            };
        var mockRepository = new Mock<IUsuarioRepository>();
        mockRepository.Setup(r => r.FindAll()).ReturnsAsync(usuarios);

        var controller = new UsuarioController(mockRepository.Object);

        var result = await controller.GetAsync();

        var resultType = Assert.IsType<OkObjectResult>(result.Result);
        var resultValue = Assert.IsType<List<UsuarioModel>>(resultType.Value);

        Assert.Single(resultValue);
        Assert.Equal(1, resultValue.Count);
    }

    [Fact]
    public async Task GetUsuarioResultOkWith3Usuarios()
    {
        var usuarios = new List<UsuarioModel>() {
                new UsuarioModel(),
                new UsuarioModel(),
                new UsuarioModel()
            };
        var mockRepository = new Mock<IUsuarioRepository>();
        mockRepository.Setup(r => r.FindAll()).ReturnsAsync(usuarios);

        var controller = new UsuarioController(mockRepository.Object);

        var result = await controller.GetAsync();

        var resultType = Assert.IsType<OkObjectResult>(result.Result);
        var resultValue = Assert.IsType<List<UsuarioModel>>(resultType.Value);

        Assert.Equal(3, resultValue.Count);
    }

    [Fact]
    public async Task GetUsuarioResultNoContent()
    {
        var mockRepository = new Mock<IUsuarioRepository>();
        mockRepository.Setup(r => r.FindAll()).ReturnsAsync(new List<UsuarioModel>());

        var controller = new UsuarioController(mockRepository.Object);

        var result = await controller.GetAsync();

        Assert.IsType<NoContentResult>(result.Result);

    }

}

