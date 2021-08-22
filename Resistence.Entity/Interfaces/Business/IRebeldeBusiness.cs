
namespace Resistence_Entity.Interfaces
{
    public interface IRebeldeBusiness
    {
        int AdicionarRebelde(Rebelde rebelde);
        Rebelde BuscarRebelde(int idRebelde);
        bool ReportarTraidor(int idRebelde);
        bool ValidarRebedeTraidor(int idRebelde);
    }
}
