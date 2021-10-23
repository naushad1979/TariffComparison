using TariffComparison.DataAccess.Entities;

namespace TariffComparison.DataAccess.Repositories
{
    public interface IProductRepository
    {
        IList<Product> GetAllProducts();
    }
}
