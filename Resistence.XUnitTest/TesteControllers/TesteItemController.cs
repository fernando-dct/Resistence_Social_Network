
using Microsoft.AspNetCore.Mvc;
using Moq;
using Resistence_Entity;
using Resistence_Entity.Interfaces;
using Resistence_Web.Controllers;
using System.Collections.Generic;
using Xunit;

namespace Resistence_XUnitTest.TestControllers
{
    public class TesteItemController : TesteBase
    {
        private readonly ItemController _itemController;
        private readonly Mock<IItemBusiness> _itemBusiness;

        public TesteItemController()
        {
            _itemBusiness = new Mock<IItemBusiness>();
            _itemController = new ItemController(_itemBusiness.Object);
        }

        [Fact]
        public void testerBuscaItens()
        {
            _itemBusiness.Setup(x => x.buscarItens()).Returns(new List<Item>());
            ObjectResult result = (ObjectResult)_itemController.buscarItens();
            Assert.Equal(_duzentos, result.StatusCode);
        }

    }
}