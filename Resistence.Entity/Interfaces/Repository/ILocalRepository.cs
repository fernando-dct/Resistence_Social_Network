
namespace Resistence_Entity.Interfaces
{
    public interface ILocalRepository
    {
        Local BuscarLocal(int idRebelde);
        public bool AtualizarLocal(Local local);
    }
}
