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
        public void TestarBuscaItens()
        {
            _itemRepository.Setup(x => x.BuscarItens()).Returns(_items);
            IList<Item> retorno = _itemBusiness.BuscarItens();
            Assert.NotNull(retorno);
        }

        [Fact]
        public void TestarBuscaPontuacaoItem()
        {
            _itemRepository.Setup(x => x.BuscarItem(It.IsAny<string>())).Returns(new Item { Nome = "arma", Pontuacao = 4});
            int retorno = _itemBusiness.BuscarPontuacaoItem("arma");
            Assert.True(retorno > 0);
        }
    }
}
