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
        public void TestarTrocaItens()
        {
            List<TrocaDto> itens = new List<TrocaDto> 
            {
                new TrocaDto
                {
                    IdRebelde = 1,
                    Inventario = new List<InventarioDto>
                    {
                        new InventarioDto { Item = "Arma", Quantidade = 1 }
                    }
                },
                new TrocaDto 
                {
                    IdRebelde = 1,
                    Inventario = new List<InventarioDto>
                    {
                        new InventarioDto { Item = "Arma", Quantidade = 1 }
                    }
                }

            };

            _rebeldeBusiness.Setup(x => x.BuscarRebelde(It.IsAny<int>())).Returns(new Rebelde { IdRebelde = 1 });
            _rebeldeBusiness.Setup(x => x.ValidarRebedeTraidor(It.IsAny<int>())).Returns(false);

            _itemBusiness.Setup(x => x.ValidarItem(It.IsAny<string>())).Returns(false);
            _itemBusiness.Setup(x => x.BuscarPontuacaoItem(It.IsAny<string>())).Returns(1);

            _inventarioBusiness.Setup(x => x.ValidarItemInventarioRebelde(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>())).Returns(false);
            _inventarioBusiness.Setup(x => x.RealizarTrocaItens(It.IsAny<List<Inventario>>())).Returns(true);

            ObjectResult result = (ObjectResult)_inventarioController.TrocarItens(itens);
            Assert.Equal(_duzentos, result.StatusCode);
        }
    }
}
