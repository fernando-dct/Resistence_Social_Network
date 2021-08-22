namespace Resistence_Entity.Interfaces
{
    public interface IInventarioRepository
    {
        Inventario BuscarItemInventario(int idRebelde, string item, int quantidade);
    }
}
