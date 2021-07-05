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
        public void testarAdicaoRebelde()
        {
            Rebelde rebelde = new Rebelde();
            rebelde.Inventario = new List<Inventario>();
            rebelde.Inventario.Add(new Inventario { Quantidade = 10, Item = "arma" });
            rebelde.Local = new Local { Nome = "Teste Local 1", Latitude = 1.1m, Longitude = 1.1m };

            List<Item> items = new List<Item>();
            items.Add(new Item { Nome = "arma", Pontuacao = 4 });

            _rebeldeBusiness.Setup(x => x.adicionarRebelde(It.IsAny<Rebelde>())).Returns(1);
            _itemBusiness.Setup(x => x.buscarItens()).Returns(items);

            ObjectResult retorno = (ObjectResult)_rebeldeController.adicionarRebelde(rebelde);
            Assert.Equal(retorno.StatusCode, _duzentos);
        }

        [Fact]
        public void testarReporteTraicao()
        {
            _rebeldeBusiness.Setup(x => x.reportarTraidor(It.IsAny<int>())).Returns(true);
            ObjectResult retorno = (ObjectResult)_rebeldeController.buscarRebelde(1);
            Assert.Equal(retorno.StatusCode, _duzentos);
        }

        [Fact]
        public void testarBuscaRebelde()
        {
            _rebeldeBusiness.Setup(x => x.buscarRebelde(It.IsAny<int>())).Returns(new Rebelde() { IdRebelde = 1 });
            ObjectResult retorno = (ObjectResult)_rebeldeController.buscarRebelde(1);
            Assert.Equal(retorno.StatusCode, _duzentos);
        }

        #endregion

        #region Casos de falha

        [Fact]
        public void testarAdicaoRebeldeSemInventario()
        {
            Rebelde rebelde = new Rebelde();
            ObjectResult retorno = (ObjectResult)_rebeldeController.adicionarRebelde(rebelde);
            Assert.Equal(retorno.StatusCode, _quatrocentos);
        }

        [Fact]
        public void testarAdicaoRebeldeSemLocal()
        {
            Rebelde rebelde = new Rebelde();
            rebelde.Inventario = new List<Inventario>();
            rebelde.Inventario.Add(new Inventario { Quantidade = 10, Item = "arma" });
            ObjectResult retorno = (ObjectResult)_rebeldeController.adicionarRebelde(rebelde);
            Assert.Equal(retorno.StatusCode, _quatrocentos);
        }

        #endregion
    }
}
