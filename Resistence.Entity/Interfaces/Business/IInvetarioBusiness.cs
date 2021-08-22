using System.Collections.Generic;

namespace Resistence_Entity.Interfaces
{
    public interface IInventarioBusiness
    {
        public bool ValidarItemInventarioRebelde(int idRebelde, string item, int quantidade);
        public bool RealizarTrocaItens(List<Inventario> inventarios);
    }
}
