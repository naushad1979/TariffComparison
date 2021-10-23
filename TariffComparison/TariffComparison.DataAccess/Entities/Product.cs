namespace TariffComparison.DataAccess.Entities
{
    public class Product
    {
        public string Name { get; set; }

        public double BaseCostsPerMonth { get; set; }

        public double ConsumptionCostsPerKWh { get; set; }
        public double AnnualBaseCostsLimitInKWh { get; set; }

        public double AnnualBaseCosts { get; set; } 
        public int TariffCostCalculatorType { get; set; }
    }
}
