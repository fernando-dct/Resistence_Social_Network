using System.Collections.Generic;

namespace Resistence_Entity.Interfaces
{
    public interface IItemBusiness
    {
        IList<Item> buscarItens();
        bool validarItem(string item);
        int buscarPontuacaoItem(string item);
    }
}
