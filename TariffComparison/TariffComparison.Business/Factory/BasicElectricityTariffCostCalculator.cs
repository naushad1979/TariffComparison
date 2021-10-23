using TariffComparison.DataAccess.Entities;

namespace TariffComparison.Business.Factory
{
    public class BasicElectricityTariffCostCalculator : ITariffCostCalculator
    {
        private readonly Product product;
        public BasicElectricityTariffCostCalculator(Product product)
        {
            this.product = product;
        }
        public double CalculateAnnualCosts(double consumptionInKWh)
        {
            if (consumptionInKWh < 0)
                throw new ArgumentException("Consumption should be greater than or equal to zero");

            return product.BaseCostsPerMonth * 12 + product.ConsumptionCostsPerKWh * consumptionInKWh;
        }
    }
}
