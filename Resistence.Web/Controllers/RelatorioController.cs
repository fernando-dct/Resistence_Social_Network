using Microsoft.AspNetCore.Mvc;
using Resistence_Entity.Interfaces;
using Resistence_Web.DTO;

namespace Resistence_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : Controller
    {
        private readonly IRelatorioBusiness _relatorioBusiness;

        public RelatorioController(IRelatorioBusiness relatorioBusiness)
        {
            _relatorioBusiness = relatorioBusiness;
        }

        [HttpGet]
        [Route("buscarPorcentagemRebeldes")]
        public IActionResult buscarPorcentagemRebeldes()
        {
            RelatorioDTO relatorio = new RelatorioDTO();
            relatorio.Quantidade = _relatorioBusiness.buscarPorcentagemRebeldes();
            return Ok(relatorio);
        }

        [HttpGet]
        [Route("buscarPontosPerdidosTraidores")]
        public IActionResult buscarPontosPerdidosTraidores()
        {
            RelatorioDTO relatorio = new RelatorioDTO();
            relatorio.Quantidade = _relatorioBusiness.buscarPontosPerdidosTraidores();
            return Ok(relatorio);
        }

        [HttpGet]
        [Route("buscarPorcentagemTraidores")]
        public IActionResult buscarPorcentagemTraidores()
        {
            RelatorioDTO relatorio = new RelatorioDTO();
            relatorio.Quantidade = _relatorioBusiness.buscarPorcentagemTraidores();
            return Ok(relatorio);
        }

        [HttpGet]
        [Route("buscarQuantidadeMediaRecurso")]
        public IActionResult buscarQuantidadeMediaRecurso()
        {
            return Ok(_relatorioBusiness.buscarQuantidadeMediaRecurso());
        }
    }
}
