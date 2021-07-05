using Moq;
using Resistence_Business;
using Resistence_Entity;
using Resistence_Entity.Interfaces;
using System.Collections.Generic;
using Xunit;


namespace Resistence_XUnitTest.TesteBusiness
{
    public class TesteRelatorioBusiness : TesteBase
    {
        private readonly RelatorioBusiness _relatorioBusiness;
        private readonly Mock<IRebeldeRepository> _rebeldeRepository;
        private readonly Mock<IItemRepository> _itemRepository;

        public TesteRelatorioBusiness()
        {
            _rebeldeRepository = new Mock<IRebeldeRepository>();
            _itemRepository = new Mock<IItemRepository>();
            _relatorioBusiness = new RelatorioBusiness(_rebeldeRepository.Object, _itemRepository.Object);
        }


        [Fact]
        public void testarBuscaPontosPerdidosTraidores()
        {
            List<Rebelde> rebeldes = new List<Rebelde>();
            Rebelde rebelde = new Rebelde();
            rebelde.QtdeReportadaTraidor = 3;
            rebelde.Inventario = new List<Inventario>();
            rebelde.Inventario.Add(new Inventario { Quantidade = 10, Item = "arma"});

            rebeldes.Add(rebelde);

            _itemRepository.Setup(x => x.buscarItens()).Returns(_items);
            _rebeldeRepository.Setup(x => x.buscarTodosRebelde()).Returns(rebeldes);

            int retorno = _relatorioBusiness.buscarPontosPerdidosTraidores();
            Assert.True(retorno > 0);
        }

        [Fact]
        public void testarBuscaPorcentagemRebeldes()
        {
            List<Rebelde> rebeldes = new List<Rebelde>();
            Rebelde rebelde = new Rebelde();
            rebelde.QtdeReportadaTraidor = 0;
            rebeldes.Add(rebelde);
            _rebeldeRepository.Setup(x => x.buscarTodosRebelde()).Returns(rebeldes);

            decimal retorno = _relatorioBusiness.buscarPorcentagemRebeldes();
            Assert.True(retorno > 0);
        }

        [Fact]
        public void testarBuscaPorcentagemTraidores()
        {
            List<Rebelde> rebeldes = new List<Rebelde>();
            Rebelde rebelde = new Rebelde();
            rebelde.QtdeReportadaTraidor = 3;

            rebeldes.Add(rebelde);
            _rebeldeRepository.Setup(x => x.buscarTodosRebelde()).Returns(rebeldes);

            decimal retorno = _relatorioBusiness.buscarPorcentagemTraidores();
            Assert.True(retorno > 0);
        }


        [Fact]
        public void testarBuscaQuantidadeMediaRecurso()
        {
            List<Rebelde> rebeldes = new List<Rebelde>();
            Rebelde rebelde = new Rebelde();
            rebelde.QtdeReportadaTraidor = 0;
            rebelde.Inventario = new List<Inventario>();
            rebelde.Inventario.Add(new Inventario { Quantidade = 10, Item = "arma" });
            rebeldes.Add(rebelde);

            _itemRepository.Setup(x => x.buscarItens()).Returns(_items);
            _rebeldeRepository.Setup(x => x.buscarTodosRebelde()).Returns(rebeldes);

            IList<RelatorioMedia> retorno = _relatorioBusiness.buscarQuantidadeMediaRecurso();
            Assert.NotNull(retorno);
        }
    }
}
