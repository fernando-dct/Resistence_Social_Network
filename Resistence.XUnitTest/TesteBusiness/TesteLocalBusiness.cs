using Moq;
using Resistence_Business;
using Resistence_Entity;
using Resistence_Entity.Interfaces;
using Xunit;

namespace Resistence_XUnitTest.TesteBusiness
{
    public class TesteLocalBusiness : TesteBase
    {
        private readonly LocalBusiness _localBusiness;
        private readonly Mock<ILocalRepository> _localRepository;

        public TesteLocalBusiness()
        {
            _localRepository = new Mock<ILocalRepository>();
            _localBusiness = new LocalBusiness(_localRepository.Object);
            _localRepository.Setup(x => x.BuscarLocal(It.IsAny<int>())).Returns(new Local());

        }

        [Fact]
        public void TestarAtualizacaoLocal()
        {
            _localRepository.Setup(x => x.AtualizarLocal(It.IsAny<Local>())).Returns(true);
            bool retorno = _localBusiness.AtualizarLocal(new Local());
            Assert.True(retorno);
        }

        [Fact]
        public void TestarBuscaLocal()
        {
            Local retorno = _localBusiness.BuscarLocal(1);
            Assert.NotNull(retorno);
        }
    }
}
