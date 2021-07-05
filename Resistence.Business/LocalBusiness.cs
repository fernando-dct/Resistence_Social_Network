using Resistence_Entity;
using Resistence_Entity.Interfaces;

namespace Resistence_Business
{
    public class LocalBusiness : ILocalBusiness
    {
        private readonly ILocalRepository _localRepository;
        public LocalBusiness(ILocalRepository localRepository)
        {
            _localRepository = localRepository;
        }

        public bool atualizarLocal(Local localAtualizado)
        {

            Local local = _localRepository.buscarLocal(localAtualizado.IdRebelde);
            if (local == null)
            {
                return false;
            }

            local.Latitude = localAtualizado.Latitude;
            local.Longitude = localAtualizado.Longitude;
            local.Nome = localAtualizado.Nome;

            return _localRepository.atualizarLocal(local);
        }

        public Local buscarLocal(int idRebelde)
        {
            return _localRepository.buscarLocal(idRebelde);
        }
    }
}
