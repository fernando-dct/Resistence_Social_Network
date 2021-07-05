using Microsoft.AspNetCore.Mvc;
using Moq;
using Resistence_Entity;
using Resistence_Entity.Interfaces;
using Resistence_Web.Controllers;
using Xunit;

namespace Resistence_XUnitTest.TestControllers
{
    public class TesteLocalController : TesteBase
    {
        private readonly LocalController _localController;
        private readonly Mock<ILocalBusiness> _localBussiness;
        public TesteLocalController()
        {
            _localBussiness = new Mock<ILocalBusiness>();
            _localController = new LocalController(_localBussiness.Object);
        }

        [Fact]
        public void testarAtualizacaoLocal()
        {
            _localBussiness.Setup(x => x.atualizarLocal(It.IsAny<Local>())).Returns(true);
            ObjectResult result = (ObjectResult)_localController.atualizarLocal(new Local());
            Assert.Equal(_duzentos, result.StatusCode);
        }

        [Fact]
        public void testarBuscaLocall()
        {
            _localBussiness.Setup(x => x.buscarLocal(It.IsAny<int>())).Returns(new Local());
            ObjectResult result = (ObjectResult)_localController.buscarLocal(1);
            Assert.Equal(_duzentos, result.StatusCode);
        }

    }
}
