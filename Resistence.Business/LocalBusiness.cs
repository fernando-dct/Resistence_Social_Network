using Resistence_Entity;
using Resistence_Entity.Interfaces;

namespace Resistence_Business
{
    public class LocalBusiness(ILocalRepository localRepository) : ILocalBusiness
    {
        private readonly ILocalRepository _localRepository = localRepository;

        public bool AtualizarLocal(Local localAtualizado)
        {

            Local local = _localRepository.BuscarLocal(localAtualizado.IdRebelde);
            if (local == null)
            {
                return false;
            }

            local.Latitude = localAtualizado.Latitude;
            local.Longitude = localAtualizado.Longitude;
            local.Nome = localAtualizado.Nome;

            return _localRepository.AtualizarLocal(local);
        }

        public Local BuscarLocal(int idRebelde)
        {
            return _localRepository.BuscarLocal(idRebelde);
        }
    }
}
