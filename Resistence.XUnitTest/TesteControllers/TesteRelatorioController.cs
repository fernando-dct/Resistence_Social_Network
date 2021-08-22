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
        public void TestarBuscaPontosPerdidosTraidores()
        {
            _relatorioBusiness.Setup(x => x.BuscarPontosPerdidosTraidores()).Returns(1);
            ObjectResult result = (ObjectResult)_relatorioController.BuscarPontosPerdidosTraidores();
            Assert.Equal(1, ((RelatorioDto)result.Value).Quantidade);
            Assert.Equal(_duzentos, result.StatusCode);
        }

        [Fact]
        public void TestarBuscaPorcentagemRebeldes()
        {
            _relatorioBusiness.Setup(x => x.BuscarPorcentagemRebeldes()).Returns(1);
            ObjectResult result = (ObjectResult)_relatorioController.BuscarPorcentagemRebeldes();
            Assert.Equal(1, ((RelatorioDto)result.Value).Quantidade);
            Assert.Equal(_duzentos, result.StatusCode);
        }

        [Fact]
        public void TestarBuscaPorcentagemTraidores()
        {
            _relatorioBusiness.Setup(x => x.BuscarPorcentagemTraidores()).Returns(1);
            ObjectResult result = (ObjectResult)_relatorioController.BuscarPorcentagemTraidores();
            Assert.Equal(1, ((RelatorioDto)result.Value).Quantidade);
            Assert.Equal(_duzentos, result.StatusCode);
        }

        [Fact]
        public void TestarBuscaQuantidadeMediaRecurso()
        {
            _relatorioBusiness.Setup(x => x.BuscarQuantidadeMediaRecurso()).Returns(new List<RelatorioMedia>());
            ObjectResult result = (ObjectResult)_relatorioController.BuscarQuantidadeMediaRecurso();
            Assert.Equal(_duzentos, result.StatusCode);
        }
    }
}
