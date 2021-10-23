namespace TariffComparison.Business.Factory
{
    public interface ITariffCostCalculator
    {
        double CalculateAnnualCosts(double consumptionInKWh);
    }
}