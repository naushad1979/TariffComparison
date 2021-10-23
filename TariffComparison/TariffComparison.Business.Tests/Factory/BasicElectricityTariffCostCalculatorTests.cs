using Moq;
using NUnit.Framework;
using System;
using TariffComparison.DataAccess.Entities;

namespace TariffComparison.Business.Factory.Tests
{
    public class BasicElectricityTariffCostCalculatorTests
    {
        private Product product = null;
        [SetUp]
        public void Setup()
        {
            product = new Product
            {
                Name = "basic electricity tariff",
                BaseCostsPerMonth = 5,
                ConsumptionCostsPerKWh = 0.22,
                TariffCostCalculatorType = 1
            };
        }

        [Test]
        public void CalculateAnnualCostsWith3500KWhReturns830()
        {
            ITariffCostCalculator tariffCostCalculator = new BasicElectricityTariffCostCalculator(product);
            double actualAnualCost = tariffCostCalculator.CalculateAnnualCosts(3500);
            Assert.AreEqual(830, actualAnualCost);
        }
        [Test]
        public void CalculateAnnualCostsWith4500KWhReturns1050()
        {
            ITariffCostCalculator tariffCostCalculator = new BasicElectricityTariffCostCalculator(product);
            double actualAnualCost = tariffCostCalculator.CalculateAnnualCosts(4500);
            Assert.AreEqual(1050, actualAnualCost);
        }
        [Test]
        public void CalculateAnnualCostsWith6000KWhReturns1380()
        {
            ITariffCostCalculator tariffCostCalculator = new BasicElectricityTariffCostCalculator(product);
            double actualAnualCost = tariffCostCalculator.CalculateAnnualCosts(6000);
            Assert.AreEqual(1380, actualAnualCost);
        }
        [Test]
        public void CalculateAnnualCostsReturnsBaseCosts()
        {
            ITariffCostCalculator tariffCostCalculator = new BasicElectricityTariffCostCalculator(product);
            double actualAnualCost = tariffCostCalculator.CalculateAnnualCosts(0);
            Assert.AreEqual(60, actualAnualCost);
        }

        [Test]
        public void CalculateCostsWithNegativeConsumptionThrows()
        {
            ITariffCostCalculator tariffCostCalculator = new BasicElectricityTariffCostCalculator(product);
            Assert.Throws<ArgumentException>(() => tariffCostCalculator.CalculateAnnualCosts(-1));
        }
    }
}