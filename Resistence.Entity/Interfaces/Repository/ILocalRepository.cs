
namespace Resistence_Entity.Interfaces
{
    public interface ILocalRepository
    {
        Local buscarLocal(int idRebelde);
        public bool atualizarLocal(Local local);
    }
}
