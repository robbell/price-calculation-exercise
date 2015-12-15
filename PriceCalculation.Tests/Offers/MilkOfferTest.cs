using NUnit.Framework;
using PriceCalculation.Offers;

namespace PriceCalculation.Tests.Offers
{
    [TestFixture]
    public class MilkOfferTest
    {
        private IOffer offer;

        [SetUp]
        public void SetUp()
        {
            offer = new MilkOffer();
        }

        [Test]
        public void FourthMilkIsFreeWhenThreeMilksArePurchased()
        {
            var products = new[] { Product.Milk, Product.Milk, Product.Milk, Product.Milk };

            Assert.That(offer.GetDiscount(products), Is.EqualTo(1.15m));
        }

        [Test]
        public void MilkOfferDoesNotApplyToExtraMilk()
        {
            var products = new[]
            {
                Product.Milk, Product.Milk, Product.Milk, Product.Milk,
                Product.Milk
            };

            Assert.That(offer.GetDiscount(products), Is.EqualTo(1.15m));
        }

        [Test]
        public void MilkOfferIsAppliedMultipleTimes()
        {
            var products = new[]
            {
                Product.Milk, Product.Milk, Product.Milk, Product.Milk,
                Product.Milk, Product.Milk, Product.Milk, Product.Milk
            };

            Assert.That(offer.GetDiscount(products), Is.EqualTo(2.30m));
        }
    }
}
