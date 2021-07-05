namespace Resistence_Entity.Interfaces
{
    public interface IInventarioRepository
    {
        Inventario buscarItemInventario(int idRebelde, string item, int quantidade);
    }
}
