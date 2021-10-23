using TariffComparison.Business.Models;

namespace TariffComparison.Business.Services
{
    public interface IProductService
    {
        IList<ProductModel> GetAllProducts(double consumptionInKWh);
    }
}
