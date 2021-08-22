using Microsoft.AspNetCore.Mvc;
using Resistence_Entity;
using Resistence_Entity.Interfaces;
using Resistence_Web.DTO;

namespace Resistence_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalController : ControllerBase
    {
        private readonly ILocalBusiness _localBusiness;
        public LocalController(ILocalBusiness localBusiness)
        {
            _localBusiness = localBusiness;
        }

        [HttpPut]
        [Route("atualizarLocal")]
        public IActionResult AtualizarLocal([FromBody] Local local)
        {
            if (local == null)
            {
                return BadRequest("Dados do local não informado");
            }

            PadraoRetornoBoleano retorno = new PadraoRetornoBoleano { Sucesso = _localBusiness.AtualizarLocal(local) };
            return Ok(retorno);
        }

        [HttpGet]
        [Route("buscarLocal")]
        public IActionResult BuscarLocal(int idRebelde)
        {
            if (idRebelde <= 0)
            {
                return BadRequest("Dados do rebelde não informado");
            }

            return Ok(_localBusiness.BuscarLocal(idRebelde));
        }
    }
}
