using Resistence_Entity;
using Resistence_Entity.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Resistence_Business
{
    public class InventarioBusiness : IInventarioBusiness
    {
        private readonly IInventarioRepository _invetarioRepository;
        private readonly IRebeldeRepository _rebeldeRepository;

        public InventarioBusiness(IInventarioRepository invetarioRepository, IRebeldeRepository rebeldeRepository)
        {
            _invetarioRepository = invetarioRepository;
            _rebeldeRepository = rebeldeRepository;
        }

        public bool RealizarTrocaItens(List<Inventario> inventarios)
        {
            List<Rebelde> rebeldes = new List<Rebelde>();

            Rebelde rebelde1 = _rebeldeRepository.BuscarRebelde(inventarios[0].IdRebelde);
            Rebelde rebelde2 = _rebeldeRepository.BuscarRebelde(inventarios[1].IdRebelde);

            foreach (Inventario inventarioRebelde in inventarios.Where(x => x.IdRebelde == inventarios[0].IdRebelde))
            {
                RealiazarTroca(ref rebelde1, ref rebelde2, inventarioRebelde);
            }

            foreach (Inventario inventarioRebelde in inventarios.Where(x => x.IdRebelde == inventarios[1].IdRebelde))
            {
                RealiazarTroca(ref rebelde2, ref rebelde1, inventarioRebelde);
            }

            rebeldes.Add(rebelde1);
            rebeldes.Add(rebelde2);

            return _rebeldeRepository.AtualizarDadosRebelde(rebeldes);

        }

        private void RealiazarTroca(ref Rebelde rebeldeSaida, ref Rebelde rebeldeEntrada, Inventario inventarioRebelde)
        {
            Inventario itemRebelde1 = rebeldeSaida.Inventario.FirstOrDefault(x => x.Item == inventarioRebelde.Item);
            if (itemRebelde1.Quantidade == inventarioRebelde.Quantidade)
            {
                rebeldeSaida.Inventario.Remove(itemRebelde1);
            }
            else
            {
                itemRebelde1.Quantidade -= inventarioRebelde.Quantidade;
            }

            Inventario itemRebelde2 = rebeldeEntrada.Inventario.FirstOrDefault(x => x.Item == inventarioRebelde.Item);
            if (itemRebelde2 == null)
            {
                itemRebelde2 = new Inventario
                {
                    IdRebelde = rebeldeEntrada.IdRebelde,
                    Item = inventarioRebelde.Item,
                    Quantidade = inventarioRebelde.Quantidade
                };
                rebeldeEntrada.Inventario.Add(itemRebelde2);
            }
            else
            {
                itemRebelde2.Quantidade += inventarioRebelde.Quantidade;
            }
        }

        public bool ValidarItemInventarioRebelde(int idRebelde, string item, int quantidade)
        {
            return _invetarioRepository.BuscarItemInventario(idRebelde, item, quantidade) == null;
        }
    }
}
