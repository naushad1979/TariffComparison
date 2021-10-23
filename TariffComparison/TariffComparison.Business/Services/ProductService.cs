using TariffComparison.Business.Factory;
using TariffComparison.Business.Models;
using TariffComparison.Business.Services;
using TariffComparison.DataAccess.Repositories;

namespace TariffComparison.Business.Services
{    
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IList<ProductModel> GetAllProducts(double consumptionInKWh)
        {
            List<ProductModel> finalProducts = new List<ProductModel>();
            var sourceProducts  = productRepository.GetAllProducts();

            foreach (var sourceProduct in sourceProducts)
            {
                ITariffCostCalculator tariffCostCalculator = TariffCostCalculatorFactory.GetTariffCostCalculatorInstance
                    ((TariffCostCalculatorType)sourceProduct.TariffCostCalculatorType, sourceProduct);

               double annualCost = tariffCostCalculator.CalculateAnnualCosts(consumptionInKWh);
                ProductModel finalProduct = new ProductModel();
                finalProduct.Name = sourceProduct.Name;
                finalProduct.AnnualCosts = annualCost;

                finalProducts.Add(finalProduct);
            }
            return finalProducts;
        }
    }
}
