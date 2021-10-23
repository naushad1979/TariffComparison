using NUnit.Framework;
using System;
using TariffComparison.DataAccess.Entities;

namespace TariffComparison.Business.Factory.Tests
{
    public class PackagedTariffTariffCostCalculatorTests
    {
        private Product product = null;
        [SetUp]
        public void Setup()
        {
            product = new Product
            {
                Name = "Packaged tariff",
                AnnualBaseCosts = 800,
                AnnualBaseCostsLimitInKWh = 4000,
                ConsumptionCostsPerKWh = 0.30,
                TariffCostCalculatorType = 2
            };
        }

        [Test]
        public void CalculateAnnualCostsWith3500KWhReturns800()
        {
            ITariffCostCalculator tariffCostCalculator = new PackagedTariffCostCalculator(product);
            double actualAnualCost = tariffCostCalculator.CalculateAnnualCosts(3500);
            Assert.AreEqual(800,actualAnualCost);             
        }
        [Test]
        public void CalculateAnnualCostsWith4500KWhReturns950()
        {
            ITariffCostCalculator tariffCostCalculator = new PackagedTariffCostCalculator(product);
            double actualAnualCost = tariffCostCalculator.CalculateAnnualCosts(4500);
            Assert.AreEqual(950, actualAnualCost);
        }
        [Test]
        public void CalculateAnnualCostsWith6000KWhReturns1400()
        {
            ITariffCostCalculator tariffCostCalculator = new PackagedTariffCostCalculator(product);
            double actualAnualCost = tariffCostCalculator.CalculateAnnualCosts(6000);
            Assert.AreEqual(1400, actualAnualCost);
        }

        [Test]
        public void CalculateAnnualCostsReturnsBaseCosts()
        {
            ITariffCostCalculator tariffCostCalculator = new PackagedTariffCostCalculator(product);
            double actualAnualCost = tariffCostCalculator.CalculateAnnualCosts(0);
            Assert.AreEqual(800, actualAnualCost);
        }

        [Test]
        public void CalculateCostsWithNegativeConsumptionThrows()
        {
            ITariffCostCalculator tariffCostCalculator = new PackagedTariffCostCalculator(product);
            Assert.Throws<ArgumentException>(() => tariffCostCalculator.CalculateAnnualCosts(-1));
        }
    }
}