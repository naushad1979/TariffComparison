using TariffComparison.DataAccess.Entities;

namespace TariffComparison.Business.Factory
{
    public class TariffCostCalculatorFactory
    {
        public static ITariffCostCalculator GetTariffCostCalculatorInstance
            (TariffCostCalculatorType tariffCostCalculatorType, 
            Product product)
        {
            switch (tariffCostCalculatorType)
            {
                case TariffCostCalculatorType.BasicElectricity:
                    return new BasicElectricityTariffCostCalculator(product);
                case TariffCostCalculatorType.Packaged:
                    return new PackagedTariffCostCalculator(product);
            }
            return null;
        }
    }
}
