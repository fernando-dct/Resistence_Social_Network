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
            _localRepository.Setup(x => x.buscarLocal(It.IsAny<int>())).Returns(new Local());

        }

        [Fact]
        public void testarAtualizacaoLocal()
        {
            _localRepository.Setup(x => x.atualizarLocal(It.IsAny<Local>())).Returns(true);
            bool retorno = _localBusiness.atualizarLocal(new Local());
            Assert.True(retorno);
        }

        [Fact]
        public void testarBuscaLocal()
        {
            Local retorno = _localBusiness.buscarLocal(1);
            Assert.NotNull(retorno);
        }
    }
}
