﻿using Microsoft.AspNetCore.Mvc;
using Resistence_Entity;
using Resistence_Entity.Interfaces;
using Resistence_Web.DTO;
using Resistence_Web.Extensions;
using System.Collections.Generic;

namespace Resistence_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        private readonly IRebeldeBusiness _rebeldeBusiness;
        private readonly IInventarioBusiness _inventarioBusiness;
        private readonly IItemBusiness _itemBusiness;

        public InventarioController(IRebeldeBusiness rebeldeBusiness, IInventarioBusiness inventarioBusiness, IItemBusiness itemBusiness)
        {
            _rebeldeBusiness = rebeldeBusiness;
            _inventarioBusiness = inventarioBusiness;
            _itemBusiness = itemBusiness;
        }


        [HttpPut]
        [Route("trocarItens")]
        public IActionResult trocarItens([FromBody] List<TrocaDTO> troca)
        {
            if (troca == null)
            {
                return BadRequest("Entrada de dados inválidos.");
            }

            if (troca.Count != 2)
            {
                return BadRequest("É necessário dois rebeldes para realizar uma troca.");
            }

            List<Inventario> inventarios = new List<Inventario>();

            foreach (TrocaDTO item in troca)
            {
                if (_rebeldeBusiness.buscarRebelde(item.IdRebelde) == null)
                {
                    return BadRequest($"Rebelde com id {item.IdRebelde} inválido.");
                }

                if (_rebeldeBusiness.validarRebedeTraidor(item.IdRebelde))
                {
                    return BadRequest($"O rebelde com id  {item.IdRebelde} foi reportado como traido, dessa forma não é possivel realizar a troca.");
                }

                if (item.Inventario == null)
                {
                    return BadRequest($"Os itens para troca do rebelde com id {item.IdRebelde} não foi informado.");
                }

                foreach (InventarioDTO inventario in item.Inventario)
                {
                    inventario.Item = inventario.Item.ToLower().RemoveDiacritics();
                    if (_itemBusiness.validarItem(inventario.Item))
                    {
                        return BadRequest($"O item { inventario.Item } para troca do rebelde com id {item.IdRebelde} é invalido.");
                    }

                    item.PontuacaoTotalInformada += _itemBusiness.buscarPontuacaoItem(inventario.Item) * inventario.Quantidade;

                    if (_inventarioBusiness.validarItemInventarioRebelde(item.IdRebelde, inventario.Item, inventario.Quantidade))
                    {
                        return BadRequest($"O item { inventario.Item } não existe ou a quantidade é inválida no inventario do rebelde { item.IdRebelde }.");
                    }

                    inventarios.Add(criarNovoItemInventario(item.IdRebelde, inventario.Item, inventario.Quantidade));
                }
            }

            if (troca[0].PontuacaoTotalInformada != troca[1].PontuacaoTotalInformada)
            {
                return BadRequest($"A somatoria da pontuação dos itens informados devem ser equavalentes para efetuar a troca.");
            }

            PadraoRetornoBoleano retorno = new PadraoRetornoBoleano();

            retorno.Sucesso = _inventarioBusiness.realizarTrocaItens(inventarios);

            return Ok(retorno);
        }

        private Inventario criarNovoItemInventario(int idRebelde, string item, int quantidade)
        {
            Inventario itemRebelde = new Inventario();
            itemRebelde.IdRebelde = idRebelde;
            itemRebelde.Item = item;
            itemRebelde.Quantidade = quantidade;

            return itemRebelde;
        }
    }
}