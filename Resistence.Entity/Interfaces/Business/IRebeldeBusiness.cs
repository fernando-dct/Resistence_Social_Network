
namespace Resistence_Entity.Interfaces
{
    public interface IRebeldeBusiness
    {
        int adicionarRebelde(Rebelde rebelde);
        Rebelde buscarRebelde(int idRebelde);
        bool reportarTraidor(int idRebelde);
        bool validarRebedeTraidor(int idRebelde);
    }
}
