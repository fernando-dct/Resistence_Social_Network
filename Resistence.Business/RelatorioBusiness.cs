using Resistence_Business.Utilitarios;
using Resistence_Entity;
using Resistence_Entity.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Resistence_Business
{
    public class RelatorioBusiness : IRelatorioBusiness
    {
        private readonly IRebeldeRepository _rebeldeRepository;
        private readonly IItemRepository _itemRepository;
        public RelatorioBusiness(IRebeldeRepository rebeldeRepository, IItemRepository itemRepository)
        {
            _rebeldeRepository = rebeldeRepository;
            _itemRepository = itemRepository;
        }

        public int BuscarPontosPerdidosTraidores()
        {
            int quantidadePontosPerdidos = 0;

            IList<Item> itens = _itemRepository.BuscarItens();
            IList<Rebelde> rebeldes = _rebeldeRepository.BuscarTodosRebelde().Where(x => x.QtdeReportadaTraidor >= 3).ToList();
            foreach (Rebelde rebelde in rebeldes)
            {
                foreach (Inventario item in rebelde.Inventario)
                {
                    quantidadePontosPerdidos += item.Quantidade * itens.FirstOrDefault(x => x.Nome == item.Item).Pontuacao;
                }
            }

            return quantidadePontosPerdidos;
        }

        public decimal BuscarPorcentagemRebeldes()
        {
            int quantidadeRebeldesTotal = 0;
            int quantidadeRebeldesTraidores = 0;
            BuscarQuantidadeRebeldes(ref quantidadeRebeldesTotal, ref quantidadeRebeldesTraidores);
            return UtilitariosMatemeticos.CalcularPorcentagem((quantidadeRebeldesTotal - quantidadeRebeldesTraidores), quantidadeRebeldesTotal);

        }

        public decimal BuscarPorcentagemTraidores()
        {
            int quantidadeRebeldesTotal = 0;
            int quantidadeTraidores = 0;
            BuscarQuantidadeRebeldes(ref quantidadeRebeldesTotal, ref quantidadeTraidores);
            return UtilitariosMatemeticos.CalcularPorcentagem(quantidadeTraidores, quantidadeRebeldesTotal);
        }

        private void BuscarQuantidadeRebeldes(ref int quantidadeRebeldesTotal, ref int quantidadeRebeldesTraidores)
        {
            IList<Rebelde> rebeldes = _rebeldeRepository.BuscarTodosRebelde();
            quantidadeRebeldesTotal = rebeldes.Count;
            quantidadeRebeldesTraidores = rebeldes.Count(x => x.QtdeReportadaTraidor >= 3);
        }

        public IList<RelatorioMedia> BuscarQuantidadeMediaRecurso()
        {
            IList<Item> itens = _itemRepository.BuscarItens();
            IList<Rebelde> rebeldes = _rebeldeRepository.BuscarTodosRebelde().Where(x => x.QtdeReportadaTraidor < 3).ToList();
            IList<RelatorioMedia> relatorio = new List<RelatorioMedia>();

            foreach (Item item in itens)
            {
                relatorio.Add(new RelatorioMedia { Item = item.Nome, Media = 0 });
            }

            int quantidadeTotalRebeldes = rebeldes.Count;
            foreach (Rebelde rebelde in rebeldes)
            {
                foreach (Item item in itens)
                {
                    relatorio.FirstOrDefault(x => x.Item == item.Nome).Media += rebelde.Inventario.Where(x => x.Item == item.Nome).Sum(y => y.Quantidade);
                }
            }

            foreach (RelatorioMedia relatorioMedia in relatorio)
            {
                if (relatorioMedia.Media > 0)
                {
                    relatorioMedia.Media /= quantidadeTotalRebeldes;
                }
            }

            return relatorio;
        }
    }
}
