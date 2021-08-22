using Resistence_Entity;
using Resistence_Entity.Interfaces;
using System.Collections.Generic;

namespace Resistence_Business
{
    public class ItemBusiness : IItemBusiness
    {
        private readonly IItemRepository _itemRepository;
        public ItemBusiness(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public IList<Item> BuscarItens()
        {
            return _itemRepository.BuscarItens();
        }

        public bool ValidarItem(string item)
        {
            return _itemRepository.BuscarItem(item) == null;
        }

        public int BuscarPontuacaoItem(string item)
        {
            return _itemRepository.BuscarItem(item).Pontuacao;
        }
    }
}
