using Resistence_Entity;
using Resistence_Entity.Interfaces;
using System.Collections.Generic;

namespace Resistence_Business
{
    public class RebeldeBusiness(IRebeldeRepository rebeldeRepository) : IRebeldeBusiness
    {
        private readonly IRebeldeRepository _rebeldeRepository = rebeldeRepository;

        public int AdicionarRebelde(Rebelde rebelde)
        {
            return _rebeldeRepository.AdicionarRebelde(rebelde);
        }

        public Rebelde BuscarRebelde(int idRebelde)
        {
            return _rebeldeRepository.BuscarRebelde(idRebelde);
        }

        public IList<Rebelde> BuscarTodosRebelde()
        {
            return _rebeldeRepository.BuscarTodosRebelde();
        }

        public bool ReportarTraidor(int idRebelde)
        {
            Rebelde rebelde = _rebeldeRepository.BuscarRebelde(idRebelde);
            if (rebelde == null)
            {
                return false;
            }

            rebelde.QtdeReportadaTraidor++;
            return _rebeldeRepository.AtualizarDadosRebelde(rebelde);
        }

        public bool ValidarRebedeTraidor(int idRebelde)
        {
            return _rebeldeRepository.BuscarRebelde(idRebelde).QtdeReportadaTraidor >= 3;
        }
    }
}
