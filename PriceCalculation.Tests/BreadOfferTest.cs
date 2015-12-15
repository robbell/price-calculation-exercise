using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PriceCalculation.Tests;

namespace PriceCalculation.Tests
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

public class BreadOffer : IOffer
{
    private const int noOfButterRequiredForOffer = 2;

    public decimal GetDiscount(IEnumerable<Product> products)
    {
        var noOfButter = products.Count(p => p == Product.Butter);
        var noOfBread = products.Count(p => p == Product.Bread);

        var noOfTimesOfferCanApply = noOfButter / noOfButterRequiredForOffer;
        var noOfTimesToApplyOffer = Math.Min(noOfBread, noOfTimesOfferCanApply);

        return noOfTimesToApplyOffer * (Product.Bread.Price / 2);
    }
}
