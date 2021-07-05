using Moq;
using Resistence_Business;
using Resistence_Entity;
using Resistence_Entity.Interfaces;
using System.Collections.Generic;
using Xunit;

namespace Resistence_XUnitTest.TesteBusiness
{
    public class TesteItemBusiness : TesteBase
    {
        private readonly Mock<IItemRepository> _itemRepository;
        private readonly ItemBusiness _itemBusiness;
        public TesteItemBusiness()
        {
            _itemRepository = new Mock<IItemRepository>();
            _itemBusiness = new ItemBusiness(_itemRepository.Object);
        }

        [Fact]
        public void testarBuscaItens()
        {
            _itemRepository.Setup(x => x.buscarItens()).Returns(_items);
            IList<Item> retorno = _itemBusiness.buscarItens();
            Assert.NotNull(retorno);
        }

        [Fact]
        public void testarBuscaPontuacaoItem()
        {
            _itemRepository.Setup(x => x.buscarItem(It.IsAny<string>())).Returns(new Item { Nome = "arma", Pontuacao = 4});
            int retorno = _itemBusiness.buscarPontuacaoItem("arma");
            Assert.True(retorno > 0);
        }
    }
}
