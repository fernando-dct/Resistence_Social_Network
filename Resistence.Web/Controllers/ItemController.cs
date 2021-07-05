using Microsoft.AspNetCore.Mvc;
using Resistence_Entity.Interfaces;

namespace Resistence_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemBusiness _itemBusiness;
        public ItemController(IItemBusiness itemBusiness)
        {

            _itemBusiness = itemBusiness;
        }

        [HttpGet]
        [Route("buscarItens")]
        public IActionResult buscarItens()
        {
            return Ok(_itemBusiness.buscarItens());
        }
    }
}
