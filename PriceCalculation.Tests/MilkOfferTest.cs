using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace PriceCalculation.Tests
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

    public class MilkOffer : IOffer
    {
        private const int noOfMilkRequiredForOffer = 4;

        public decimal GetDiscount(IEnumerable<Product> products)
        {
            var noOfMilk = products.Count(p => p == Product.Milk);

            var noOfTimesToApplyOffer = noOfMilk / noOfMilkRequiredForOffer;

            return noOfTimesToApplyOffer * Product.Milk.Price;
        }
    }
}
