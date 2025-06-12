
using System.Collections.Generic;

namespace Resistence_Entity.Interfaces
{
    public interface IRebeldeBusiness
    {
        int AdicionarRebelde(Rebelde rebelde);
        Rebelde BuscarRebelde(int idRebelde);
        IList<Rebelde> BuscarTodosRebelde();
        bool ReportarTraidor(int idRebelde);
        bool ValidarRebedeTraidor(int idRebelde);
    }
}
