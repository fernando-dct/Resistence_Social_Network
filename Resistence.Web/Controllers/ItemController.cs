using Microsoft.AspNetCore.Mvc;
using Resistence_Entity.Interfaces;

namespace Resistence_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController(IItemBusiness itemBusiness) : ControllerBase
    {
        private readonly IItemBusiness _itemBusiness = itemBusiness;

        [HttpGet]
        [Route("buscarItens")]
        public IActionResult BuscarItens()
        {
            return Ok(_itemBusiness.BuscarItens());
        }
    }
}
