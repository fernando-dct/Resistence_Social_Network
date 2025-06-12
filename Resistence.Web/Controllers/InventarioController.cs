using Microsoft.AspNetCore.Mvc;
using Resistence_Entity;
using Resistence_Entity.Interfaces;
using Resistence_Web.DTO;
using Resistence_Web.Extensions;
using System.Collections.Generic;

namespace Resistence_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController(IRebeldeBusiness rebeldeBusiness, IInventarioBusiness inventarioBusiness, IItemBusiness itemBusiness) : ControllerBase
    {
        private readonly IRebeldeBusiness _rebeldeBusiness = rebeldeBusiness;
        private readonly IInventarioBusiness _inventarioBusiness = inventarioBusiness;
        private readonly IItemBusiness _itemBusiness = itemBusiness;

        [HttpPut]
        [Route("trocarItens")]
        public IActionResult TrocarItens([FromBody] List<TrocaDto> troca)
        {
            if (troca == null)
            {
                return BadRequest("Entrada de dados inválidos.");
            }

            if (troca.Count != 2)
            {
                return BadRequest("É necessário dois rebeldes para realizar uma troca.");
            }

            var inventarios = new List<Inventario>();

            foreach (TrocaDto item in troca)
            {
                if (_rebeldeBusiness.BuscarRebelde(item.IdRebelde) == null)
                {
                    return BadRequest($"Rebelde com id {item.IdRebelde} inválido.");
                }

                if (_rebeldeBusiness.ValidarRebedeTraidor(item.IdRebelde))
                {
                    return BadRequest($"O rebelde com id  {item.IdRebelde} foi reportado como traido, dessa forma não é possivel realizar a troca.");
                }

                if (item.Inventario == null)
                {
                    return BadRequest($"Os itens para troca do rebelde com id {item.IdRebelde} não foi informado.");
                }

                foreach (InventarioDto inventario in item.Inventario)
                {
                    inventario.Item = inventario.Item.ToLower().RemoveDiacritics();
                    if (_itemBusiness.ValidarItem(inventario.Item))
                    {
                        return BadRequest($"O item { inventario.Item } para troca do rebelde com id {item.IdRebelde} é invalido.");
                    }

                    item.PontuacaoTotalInformada += _itemBusiness.BuscarPontuacaoItem(inventario.Item) * inventario.Quantidade;

                    if (_inventarioBusiness.ValidarItemInventarioRebelde(item.IdRebelde, inventario.Item, inventario.Quantidade))
                    {
                        return BadRequest($"O item { inventario.Item } não existe ou a quantidade é inválida no inventario do rebelde { item.IdRebelde }.");
                    }

                    inventarios.Add(CriarNovoItemInventario(item.IdRebelde, inventario.Item, inventario.Quantidade));
                }
            }

            if (troca[0].PontuacaoTotalInformada != troca[1].PontuacaoTotalInformada)
            {
                return BadRequest($"A somatoria da pontuação dos itens informados devem ser equavalentes para efetuar a troca.");
            }

            var retorno = new PadraoRetornoBoleano { Sucesso = _inventarioBusiness.RealizarTrocaItens(inventarios) };

            return Ok(retorno);
        }

        private static Inventario CriarNovoItemInventario(int idRebelde, string item, int quantidade)
        {
            var itemRebelde = new Inventario
            {
                IdRebelde = idRebelde,
                Item = item,
                Quantidade = quantidade
            };

            return itemRebelde;
        }
    }
}
