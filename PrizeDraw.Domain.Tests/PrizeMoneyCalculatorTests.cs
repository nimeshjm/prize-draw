using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;

namespace PrizeDraw.Domain.Tests
{
    [TestFixture]
    public class PrizeMoneyCalculatorTests
    {
        Mock<IOrderRepository> orderRepository;

        [SetUp]
        public void Setup()
        {
            orderRepository = new Mock<IOrderRepository>();
        }

        [Test]
        public void CalculateTotalPrizeMoney_NoCampaignReturnsNoPrizeMoney()
        {
            orderRepository.Setup(o => o.GetOrderValues()).Returns(CampaignZeroDays);
            var sut = new PrizeMoneyCalculator(orderRepository.Object);

            var actual = sut.CalculateTotalPrizeMoney();

            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void CalculateTotalPrizeMoney_CampaignSingleDayWithTwoOrders()
        {
            orderRepository.Setup(o => o.GetOrderValues()).Returns(CampaignTwoOrders);
            var sut = new PrizeMoneyCalculator(orderRepository.Object);

            var actual = sut.CalculateTotalPrizeMoney();

            Assert.That(actual, Is.EqualTo(2));
        }

        [Test]
        public void CalculateTotalPrizeMoney_CampaignMultipleDaysWithMultipleOrders()
        {
            orderRepository.Setup(o => o.GetOrderValues()).Returns(CampaignMultipleDaysMultipleOrders);
            var sut = new PrizeMoneyCalculator(orderRepository.Object);

            var actual = sut.CalculateTotalPrizeMoney();

            Assert.That(actual, Is.EqualTo(19));
        }


        private static IEnumerable<IEnumerable<int>> CampaignZeroDays()
        {
            return Enumerable.Empty<IEnumerable<int>>();
        }

        private static IEnumerable<IEnumerable<int>> CampaignTwoOrders()
        {
            return new[] { new[] { 3, 1 } };
        }

        private static IEnumerable<IEnumerable<int>> CampaignMultipleDaysMultipleOrders()
        {
            return new[]
                       {
                           new[] { 1, 2, 3 },
                           new[] { 1, 1 },
                           new[] { 10, 5, 5, 1 },
                           Enumerable.Empty<int>(),
                           new[] { 2 }
                       };
        }
    }
}
