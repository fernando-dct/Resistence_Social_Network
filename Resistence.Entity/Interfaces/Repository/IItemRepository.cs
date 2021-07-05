using System.Collections.Generic;

namespace Resistence_Entity.Interfaces
{
    public interface IItemRepository
    {
        IList<Item> buscarItens();
        Item buscarItem(string item);
    }
}
