using Microsoft.AspNetCore.Mvc;
using Resistence_Entity.Interfaces;
using Resistence_Web.DTO;

namespace Resistence_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController(IRelatorioBusiness relatorioBusiness) : Controller
    {
        private readonly IRelatorioBusiness _relatorioBusiness = relatorioBusiness;

        [HttpGet]
        [Route("buscarPorcentagemRebeldes")]
        public IActionResult BuscarPorcentagemRebeldes()
        {
            RelatorioDto relatorio = new RelatorioDto
            {
                Quantidade = _relatorioBusiness.BuscarPorcentagemRebeldes()
            };
            return Ok(relatorio);
        }

        [HttpGet]
        [Route("buscarPontosPerdidosTraidores")]
        public IActionResult BuscarPontosPerdidosTraidores()
        {
            RelatorioDto relatorio = new RelatorioDto
            {
                Quantidade = _relatorioBusiness.BuscarPontosPerdidosTraidores()
            };
            return Ok(relatorio);
        }

        [HttpGet]
        [Route("buscarPorcentagemTraidores")]
        public IActionResult BuscarPorcentagemTraidores()
        {
            RelatorioDto relatorio = new RelatorioDto
            {
                Quantidade = _relatorioBusiness.BuscarPorcentagemTraidores()
            };
            return Ok(relatorio);
        }

        [HttpGet]
        [Route("buscarQuantidadeMediaRecurso")]
        public IActionResult BuscarQuantidadeMediaRecurso()
        {
            return Ok(_relatorioBusiness.BuscarQuantidadeMediaRecurso());
        }
    }
}
