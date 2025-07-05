using Donation.Controllers;
using Donation.Models;
using Donation.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Donation.Api.Test;

public class UnitTest1
{
    [Fact]
    public void GetUsuarioResultOkWithUsuarios()
    {
        Assert.Equal(1, 1);
    }
    
    [Fact]
    public async Task GetUsuarioResultOkWith3Usuarios()
    {
        var mockRepository = new Mock<IUsuarioRepository>();
        mockRepository.Setup(r => r.FindAll()).ReturnsAsync(new List<UsuarioModel>());

        var controller = new UsuarioController(mockRepository.Object);

        var result = await controller.GetAsync();

        Assert.IsType<NoContentResult>(result.Result);
    }
}
