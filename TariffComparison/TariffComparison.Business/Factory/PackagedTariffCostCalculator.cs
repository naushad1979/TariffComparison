
using TariffComparison.Business.Factory;
using TariffComparison.DataAccess.Entities;

namespace TariffComparison.Business.Factory
{
    public class PackagedTariffCostCalculator : ITariffCostCalculator
    {
        private readonly Product product;
        public PackagedTariffCostCalculator(Product product)
        {
            this.product = product;
        }

        public double CalculateAnnualCosts(double consumptionInKWh)
        {
            if (consumptionInKWh < 0)
                throw new ArgumentException("Consumption should be greater than or equal to zero");

            double baseCosts = product.AnnualBaseCosts / 12 * 12;

            if (consumptionInKWh / 12 <= product.AnnualBaseCostsLimitInKWh / 12)
                return baseCosts;

            double baseCostsLimit = product.AnnualBaseCostsLimitInKWh / 12 * 12;
            return baseCosts + ((consumptionInKWh - baseCostsLimit) * product.ConsumptionCostsPerKWh);
        }
    }
}
