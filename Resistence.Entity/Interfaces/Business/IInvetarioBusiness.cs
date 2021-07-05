using System.Collections.Generic;

namespace Resistence_Entity.Interfaces
{
    public interface IInventarioBusiness
    {
        public bool validarItemInventarioRebelde(int idRebelde, string item, int quantidade);
        public bool realizarTrocaItens(List<Inventario> inventarios);
    }
}
