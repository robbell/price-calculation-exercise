using NUnit.Framework;
using PriceCalculation.Offers;

namespace PriceCalculation.Tests.Offers
{
    [TestFixture]
    public class BreadOfferTest
    {
        private IOffer offer;

        [SetUp]
        public void SetUp()
        {
            offer = new BreadOffer();
        }

        [Test]
        public void BreadIsHalfPriceWhenTwoButtersArePurchased()
        {
            var products = new[] { Product.Butter, Product.Butter, Product.Bread };

            Assert.That(offer.GetDiscount(products), Is.EqualTo(0.50m));
        }

        [Test]
        public void BreadOfferDoesNotApplyToExtraBread()
        {
            var products = new[] { Product.Butter, Product.Butter, Product.Bread, Product.Bread };

            Assert.That(offer.GetDiscount(products), Is.EqualTo(0.50m));
        }

        [Test]
        public void BreadOfferCanBeAppliedMultipleTimes()
        {
            var products = new[]
            {
                Product.Butter, Product.Butter, Product.Bread,
                Product.Butter, Product.Butter, Product.Bread
            };

            Assert.That(offer.GetDiscount(products), Is.EqualTo(1.00m));
        }
    }
}