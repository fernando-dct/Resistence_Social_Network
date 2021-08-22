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
        public void TestarBuscaPontosPerdidosTraidores()
        {
            List<Rebelde> rebeldes = new List<Rebelde>
            {
                new Rebelde
                {
                    QtdeReportadaTraidor = 3,
                    Inventario = new List<Inventario>
                    {
                        new Inventario { Quantidade = 10, Item = "arma"}
                    }
                }
            };

            _itemRepository.Setup(x => x.BuscarItens()).Returns(_items);
            _rebeldeRepository.Setup(x => x.BuscarTodosRebelde()).Returns(rebeldes);

            int retorno = _relatorioBusiness.BuscarPontosPerdidosTraidores();
            Assert.True(retorno > 0);
        }

        [Fact]
        public void TestarBuscaPorcentagemRebeldes()
        {
            List<Rebelde> rebeldes = new List<Rebelde>
            {
                new Rebelde
                {
                    QtdeReportadaTraidor = 0
                }
            };

            _rebeldeRepository.Setup(x => x.BuscarTodosRebelde()).Returns(rebeldes);

            decimal retorno = _relatorioBusiness.BuscarPorcentagemRebeldes();
            Assert.True(retorno > 0);
        }

        [Fact]
        public void TestarBuscaPorcentagemTraidores()
        {
            List<Rebelde> rebeldes = new List<Rebelde>
            {
                new Rebelde
                {
                    QtdeReportadaTraidor = 3
                }
            };
            _rebeldeRepository.Setup(x => x.BuscarTodosRebelde()).Returns(rebeldes);

            decimal retorno = _relatorioBusiness.BuscarPorcentagemTraidores();
            Assert.True(retorno > 0);
        }


        [Fact]
        public void TestarBuscaQuantidadeMediaRecurso()
        {
            List<Rebelde> rebeldes = new List<Rebelde>
            {
                new Rebelde
                {
                    QtdeReportadaTraidor = 0,
                    Inventario = new List<Inventario>
                    {
                        new Inventario { Quantidade = 10, Item = "arma"}
                    }
                }
            };

            _itemRepository.Setup(x => x.BuscarItens()).Returns(_items);
            _rebeldeRepository.Setup(x => x.BuscarTodosRebelde()).Returns(rebeldes);

            IList<RelatorioMedia> retorno = _relatorioBusiness.BuscarQuantidadeMediaRecurso();
            Assert.NotNull(retorno);
        }
    }
}
