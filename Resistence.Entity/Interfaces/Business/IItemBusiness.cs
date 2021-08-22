using System.Collections.Generic;

namespace Resistence_Entity.Interfaces
{
    public interface IItemBusiness
    {
        IList<Item> BuscarItens();
        bool ValidarItem(string item);
        int BuscarPontuacaoItem(string item);
    }
}
