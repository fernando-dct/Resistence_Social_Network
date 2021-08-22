using System.Collections.Generic;

namespace Resistence_Entity.Interfaces
{
    public interface IRebeldeRepository
    {
        int AdicionarRebelde(Rebelde rebelde);
        Rebelde BuscarRebelde(int id);
        IList<Rebelde> BuscarTodosRebelde();
        bool AtualizarDadosRebelde(Rebelde rebelde);
        bool AtualizarDadosRebelde(List<Rebelde> rebeldes);
    }

}
