using System.Collections.Generic;

namespace Resistence_Entity.Interfaces
{
    public interface IItemRepository
    {
        IList<Item> BuscarItens();
        Item BuscarItem(string item);
    }
}
