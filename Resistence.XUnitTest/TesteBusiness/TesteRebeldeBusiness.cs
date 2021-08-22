using Moq;
using Resistence_Business;
using Resistence_Entity;
using Resistence_Entity.Interfaces;
using Xunit;

namespace Resistence_XUnitTest.TesteBusiness
{
    public class TesteRebeldeBusiness : TesteBase
    {
        private readonly RebeldeBusiness _rebeldeBusiness;
        private readonly Mock<IRebeldeRepository> _rebeldeRepository;

        public TesteRebeldeBusiness()
        {
            _rebeldeRepository = new Mock<IRebeldeRepository>();
            _rebeldeBusiness = new RebeldeBusiness(_rebeldeRepository.Object);
        }

        #region Casos de sucesso

        [Fact]
        public void TestarAdicaoRebelde()
        {
            _rebeldeRepository.Setup(x => x.AdicionarRebelde(It.IsAny<Rebelde>())).Returns(1);
            int idRebelde = _rebeldeBusiness.AdicionarRebelde(new Rebelde());
            Assert.True(idRebelde > 0);
        }

        [Fact]
        public void TestarBuscaRebelde()
        {
            _rebeldeRepository.Setup(x => x.BuscarRebelde(It.IsAny<int>())).Returns(new Rebelde());
            Rebelde rebelde = _rebeldeBusiness.BuscarRebelde(1);
            Assert.NotNull(rebelde);
        }

        [Fact]
        public void TestarBuscaTodosRebelde()
        {
            _rebeldeRepository.Setup(x => x.BuscarRebelde(It.IsAny<int>())).Returns(new Rebelde());
            _rebeldeRepository.Setup(x => x.AtualizarDadosRebelde(It.IsAny<Rebelde>())).Returns(true);
            bool retorno = _rebeldeBusiness.ReportarTraidor(1);
            Assert.True(retorno);
        }


        #endregion

    }
}