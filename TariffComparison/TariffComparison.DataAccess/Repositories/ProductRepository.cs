
using TariffComparison.DataAccess.Entities;

namespace TariffComparison.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        //Mock implementation which can be replaced with actual database call
        public IList<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            var productA = 
            new Product
            {
                Name = "basic electricity tariff",
                BaseCostsPerMonth = 5,
                ConsumptionCostsPerKWh = 0.22,
                TariffCostCalculatorType = 1
            };

            var productB= new Product
            {
                Name = "Packaged tariff",
                AnnualBaseCosts = 800,
                AnnualBaseCostsLimitInKWh = 4000,
                ConsumptionCostsPerKWh = 0.30,
                TariffCostCalculatorType = 2
            };

            products.Add(productA);
            products.Add(productB);

            return products;
        }
    }
}
