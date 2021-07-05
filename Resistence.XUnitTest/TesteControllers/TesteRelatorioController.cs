using Microsoft.AspNetCore.Mvc;
using Moq;
using Resistence_Entity;
using Resistence_Entity.Interfaces;
using Resistence_Web.Controllers;
using Resistence_Web.DTO;
using System.Collections.Generic;
using Xunit;
namespace Resistence_XUnitTest.TestControllers
{
    public class TesteRelatorioController : TesteBase
    {
        private readonly Mock<IRelatorioBusiness> _relatorioBusiness;
        private readonly RelatorioController _relatorioController;
        public TesteRelatorioController()
        {
            _relatorioBusiness = new Mock<IRelatorioBusiness>();
            _relatorioController = new RelatorioController(_relatorioBusiness.Object);
        }


        [Fact]
        public void testarBuscaPontosPerdidosTraidores()
        {
            _relatorioBusiness.Setup(x => x.buscarPontosPerdidosTraidores()).Returns(1);
            ObjectResult result = (ObjectResult)_relatorioController.buscarPontosPerdidosTraidores();
            Assert.Equal(1, ((RelatorioDTO)result.Value).Quantidade);
            Assert.Equal(_duzentos, result.StatusCode);
        }

        [Fact]
        public void testarBuscaPorcentagemRebeldes()
        {
            _relatorioBusiness.Setup(x => x.buscarPorcentagemRebeldes()).Returns(1);
            ObjectResult result = (ObjectResult)_relatorioController.buscarPorcentagemRebeldes();
            Assert.Equal(1, ((RelatorioDTO)result.Value).Quantidade);
            Assert.Equal(_duzentos, result.StatusCode);
        }

        [Fact]
        public void testarBuscaPorcentagemTraidores()
        {
            _relatorioBusiness.Setup(x => x.buscarPorcentagemTraidores()).Returns(1);
            ObjectResult result = (ObjectResult)_relatorioController.buscarPorcentagemTraidores();
            Assert.Equal(1, ((RelatorioDTO)result.Value).Quantidade);
            Assert.Equal(_duzentos, result.StatusCode);
        }

        [Fact]
        public void testarBuscaQuantidadeMediaRecurso()
        {
            _relatorioBusiness.Setup(x => x.buscarQuantidadeMediaRecurso()).Returns(new List<RelatorioMedia>());
            ObjectResult result = (ObjectResult)_relatorioController.buscarQuantidadeMediaRecurso();
            Assert.Equal(_duzentos, result.StatusCode);
        }
    }
}
