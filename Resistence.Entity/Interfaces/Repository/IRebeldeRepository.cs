using System.Collections.Generic;

namespace Resistence_Entity.Interfaces
{
    public interface IRebeldeRepository
    {
        int adicionarRebelde(Rebelde rebelde);
        Rebelde buscarRebelde(int id);
        IList<Rebelde> buscarTodosRebelde();
        bool atualizarDadosRebelde(Rebelde rebelde);
        bool atualizarDadosRebelde(List<Rebelde> rebeldes);
    }

}
