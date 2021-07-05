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
    public class TesteInventarioController : TesteBase
    {
        private readonly InventarioController _inventarioController;
        private readonly Mock<IRebeldeBusiness> _rebeldeBusiness;
        private readonly Mock<IInventarioBusiness> _inventarioBusiness;
        private readonly Mock<IItemBusiness> _itemBusiness;
        public TesteInventarioController()
        {
            _rebeldeBusiness = new Mock<IRebeldeBusiness>();
            _inventarioBusiness = new Mock<IInventarioBusiness>();
            _itemBusiness = new Mock<IItemBusiness>();
            _inventarioController = new InventarioController(_rebeldeBusiness.Object, _inventarioBusiness.Object, _itemBusiness.Object);
        }


        [Fact]
        public void testarTrocaItens()
        {
            List<TrocaDTO> itens = new List<TrocaDTO>();

            TrocaDTO item1 = new TrocaDTO();
            item1.IdRebelde = 1;
            item1.Inventario = new List<InventarioDTO>();
            item1.Inventario.Add(new InventarioDTO { Item = "Arma", Quantidade = 1 });

            itens.Add(item1);

            TrocaDTO item2 = new TrocaDTO();
            item2.IdRebelde = 1;
            item2.Inventario = new List<InventarioDTO>();
            item2.Inventario.Add(new InventarioDTO { Item = "Arma", Quantidade = 1 });

            itens.Add(item2);

            _rebeldeBusiness.Setup(x => x.buscarRebelde(It.IsAny<int>())).Returns(new Rebelde { IdRebelde = 1 });
            _rebeldeBusiness.Setup(x => x.validarRebedeTraidor(It.IsAny<int>())).Returns(false);

            _itemBusiness.Setup(x => x.validarItem(It.IsAny<string>())).Returns(false);
            _itemBusiness.Setup(x => x.buscarPontuacaoItem(It.IsAny<string>())).Returns(1);

            _inventarioBusiness.Setup(x => x.validarItemInventarioRebelde(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>())).Returns(false);
            _inventarioBusiness.Setup(x => x.realizarTrocaItens(It.IsAny<List<Inventario>>())).Returns(true);

            ObjectResult result = (ObjectResult)_inventarioController.trocarItens(itens);
            Assert.Equal(_duzentos, result.StatusCode);
        }
    }
}
