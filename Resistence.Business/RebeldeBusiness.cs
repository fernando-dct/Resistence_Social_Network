using Resistence_Entity;
using Resistence_Entity.Interfaces;

namespace Resistence_Business
{
    public class RebeldeBusiness : IRebeldeBusiness
    {
        private readonly IRebeldeRepository _rebeldeRepository;

        public RebeldeBusiness(IRebeldeRepository rebeldeRepository)
        {
            _rebeldeRepository = rebeldeRepository;
        }

        public int adicionarRebelde(Rebelde rebelde)
        {
            return _rebeldeRepository.adicionarRebelde(rebelde);
        }

        public Rebelde buscarRebelde(int idRebelde)
        {
            return _rebeldeRepository.buscarRebelde(idRebelde);
        }

        public bool reportarTraidor(int idRebelde)
        {
            Rebelde rebelde = _rebeldeRepository.buscarRebelde(idRebelde);
            if (rebelde == null)
            {
                return false;
            }

            rebelde.QtdeReportadaTraidor++;
            return _rebeldeRepository.atualizarDadosRebelde(rebelde);
        }

        public bool validarRebedeTraidor(int idRebelde)
        {
            return _rebeldeRepository.buscarRebelde(idRebelde).QtdeReportadaTraidor >= 3;
        }
    }
}
