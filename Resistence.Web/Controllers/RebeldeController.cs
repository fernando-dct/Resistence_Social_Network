using Microsoft.AspNetCore.Mvc;
using Resistence_Entity;
using Resistence_Entity.Interfaces;
using Resistence_Web.DTO;
using Resistence_Web.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Resistence_Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RebeldeController(IRebeldeBusiness rebeldeBusiness, IItemBusiness itemBusiness) : ControllerBase
    {
        private readonly IRebeldeBusiness _rebeldeBusiness = rebeldeBusiness;
        private readonly IItemBusiness _itemBusiness = itemBusiness;

        [HttpPost]
        [Route("adicionarRebelde")]
        public IActionResult AdicionarRebelde([FromBody] Rebelde rebelde)
        {
            if (rebelde == null)
            {
                return BadRequest("Dados do rebelde não informado");
            }

            if (rebelde.Local == null)
            {
                return BadRequest("Local do rebelde não informado");
            }

            if (rebelde.Inventario == null)
            {
                return BadRequest("Inventario do rebelde não informado");
            }

            string msgInventario = string.Empty;
            ValidarInventario(ref msgInventario, rebelde.Inventario);
            if (!string.IsNullOrEmpty(msgInventario))
            {
                return BadRequest(msgInventario);
            }

            int idRebelde = _rebeldeBusiness.AdicionarRebelde(rebelde);
            if (idRebelde > 0)
            {
                return Ok(new RebeldeDto { IdRebelde = idRebelde });
            }
            else
            {
                return StatusCode(500, "Falha ao adicionar um novo rebelde a resistencia.");
            }
        }

        private void ValidarInventario(ref string msgInventario, IList<Inventario> inventarios)
        {
            IList<Item> items = _itemBusiness.BuscarItens();
            var stringBuilder = new StringBuilder();

            foreach (Inventario inventario in inventarios)
            {
                inventario.Item = inventario.Item.ToLower().RemoveDiacritics();
                if (!items.Any(x => x.Nome.ToLower().RemoveDiacritics() == inventario.Item))
                {
                    stringBuilder.Append("Item ");
                    stringBuilder.Append(inventario.Item);
                    stringBuilder.Append(" inválido \n");
                }

                if (inventario.Quantidade <= 0)
                {
                    stringBuilder.Append("Quando do item ");
                    stringBuilder.Append(inventario.Item);
                    stringBuilder.Append(" inválido \n");
                }
            }

            msgInventario = stringBuilder.ToString();
        }


        [HttpGet]
        [Route("buscarRebelde")]
        public IActionResult BuscarRebelde(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Dados do rebelde não informado");
            }
            return Ok(_rebeldeBusiness.BuscarRebelde(id));
        }

        [HttpPut]
        [Route("reportarTraidor")]
        public IActionResult ReportarTraidor(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Dados do rebelde não informado");
            }

            var retorno = new PadraoRetornoBoleano
            {
                Sucesso = _rebeldeBusiness.ReportarTraidor(id)
            };
            return Ok(retorno);
        }
    }
}
