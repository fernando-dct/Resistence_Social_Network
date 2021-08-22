using Microsoft.AspNetCore.Mvc;
using Moq;
using Resistence_Entity;
using Resistence_Entity.Interfaces;
using Resistence_Web.Controllers;
using System.Collections.Generic;
using Xunit;

namespace Resistence_XUnitTest.TestControllers
{
    public class TesteRebeldeController : TesteBase
    {
        private readonly Mock<IRebeldeBusiness> _rebeldeBusiness;
        private readonly Mock<IItemBusiness> _itemBusiness;
        private readonly RebeldeController _rebeldeController;

        public TesteRebeldeController()
        {
            _rebeldeBusiness = new Mock<IRebeldeBusiness>();
            _itemBusiness = new Mock<IItemBusiness>();
            _rebeldeController = new RebeldeController(_rebeldeBusiness.Object, _itemBusiness.Object);
        }


        #region Casos de sucesso

        [Fact]
        public void TestarAdicaoRebelde()
        {
            Rebelde rebelde = new Rebelde 
            {
                Inventario = new List<Inventario> 
                {
                    new Inventario { Quantidade = 10, Item = "arma" }
                },
                Local = new Local { Nome = "Teste Local 1", Latitude = 1.1m, Longitude = 1.1m }
            };

            List<Item> items = new List<Item>
            {
                new Item { Nome = "arma", Pontuacao = 4 }
            };

            _rebeldeBusiness.Setup(x => x.AdicionarRebelde(It.IsAny<Rebelde>())).Returns(1);
            _itemBusiness.Setup(x => x.BuscarItens()).Returns(items);

            ObjectResult retorno = (ObjectResult)_rebeldeController.AdicionarRebelde(rebelde);
            Assert.Equal(retorno.StatusCode, _duzentos);
        }

        [Fact]
        public void TestarReporteTraicao()
        {
            _rebeldeBusiness.Setup(x => x.ReportarTraidor(It.IsAny<int>())).Returns(true);
            ObjectResult retorno = (ObjectResult)_rebeldeController.BuscarRebelde(1);
            Assert.Equal(retorno.StatusCode, _duzentos);
        }

        [Fact]
        public void TestarBuscaRebelde()
        {
            _rebeldeBusiness.Setup(x => x.BuscarRebelde(It.IsAny<int>())).Returns(new Rebelde() { IdRebelde = 1 });
            ObjectResult retorno = (ObjectResult)_rebeldeController.BuscarRebelde(1);
            Assert.Equal(retorno.StatusCode, _duzentos);
        }

        #endregion

        #region Casos de falha

        [Fact]
        public void TestarAdicaoRebeldeSemInventario()
        {
            Rebelde rebelde = new Rebelde();
            ObjectResult retorno = (ObjectResult)_rebeldeController.AdicionarRebelde(rebelde);
            Assert.Equal(retorno.StatusCode, _quatrocentos);
        }

        [Fact]
        public void TestarAdicaoRebeldeSemLocal()
        {
            Rebelde rebelde = new Rebelde
            {
                Inventario = new List<Inventario>
                {
                    new Inventario { Quantidade = 10, Item = "arma" }
                }
            };
            ObjectResult retorno = (ObjectResult)_rebeldeController.AdicionarRebelde(rebelde);
            Assert.Equal(retorno.StatusCode, _quatrocentos);
        }

        #endregion
    }
}
