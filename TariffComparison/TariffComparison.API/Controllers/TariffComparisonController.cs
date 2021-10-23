using Microsoft.AspNetCore.Mvc;
using TariffComparison.Business.Models;
using TariffComparison.Business.Services;

namespace TariffComparison.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TariffComparisonController : ControllerBase
    {     
        private readonly ILogger<TariffComparisonController> logger;
        private readonly IProductService productService;
        public TariffComparisonController(ILogger<TariffComparisonController> logger, 
            IProductService productService)
        {
            this.logger = logger;
            this.productService = productService;
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public ActionResult<IEnumerable<ProductModel>> GetAllProducts(double consumption)
        {
            if (consumption < 0)
                return BadRequest("Annual consumption should be greater than or equal to zero");
            
            var response = productService.GetAllProducts(consumption);
            return Ok(response);
        }
    }
}