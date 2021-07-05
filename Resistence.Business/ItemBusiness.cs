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

        public IList<Item> buscarItens()
        {
            return _itemRepository.buscarItens();
        }

        public bool validarItem(string item)
        {
            return _itemRepository.buscarItem(item) == null;
        }

        public int buscarPontuacaoItem(string item)
        {
            return _itemRepository.buscarItem(item).Pontuacao;
        }
    }
}
