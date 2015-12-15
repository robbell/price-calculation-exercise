using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;

namespace PriceCalculation.Tests
{
    [TestFixture]
    public class BasketTest
    {
        private Basket basket;

        [SetUp]
        public void SetUp()
        {
            basket = new Basket(Enumerable.Empty<IOffer>());
        }

        [Test]
        public void ProvidesTotalCostForAddedProducts()
        {
            basket.AddProduct(Product.Butter);
            basket.AddProduct(Product.Milk);
            basket.AddProduct(Product.Bread);

            Assert.That(basket.GetTotal(), Is.EqualTo(2.95m));
        }

        [Test]
        public void BasketAppliesSuppliedOffers()
        {
            var firstOffer = Mock.Of<IOffer>(o => o.GetDiscount(It.IsAny<IEnumerable<Product>>()) == 0.05m);
            var secondOffer = Mock.Of<IOffer>(o => o.GetDiscount(It.IsAny<IEnumerable<Product>>()) == 0.20m);

            basket = new Basket(new List<IOffer> { firstOffer, secondOffer });

            basket.AddProduct(Product.Bread);

            Assert.That(basket.GetTotal(), Is.EqualTo(0.75m));
        }

        [Test, Ignore("Refactoring offers to seperate classes")]
        public void BreadIsHalfPriceWhenTwoButtersArePurchased()
        {
            basket.AddProduct(Product.Butter);
            basket.AddProduct(Product.Butter);
            basket.AddProduct(Product.Bread);

            Assert.That(basket.GetTotal(), Is.EqualTo(2.10m));
        }

        [Test, Ignore("Refactoring offers to seperate classes")]
        public void BreadOfferDoesNotApplyToExtraBread()
        {
            basket.AddProduct(Product.Butter);
            basket.AddProduct(Product.Butter);
            basket.AddProduct(Product.Bread);
            basket.AddProduct(Product.Bread);

            Assert.That(basket.GetTotal(), Is.EqualTo(3.10m));
        }

        [Test, Ignore("Refactoring offers to seperate classes")]
        public void BreadOfferCanBeAppliedMultipleTimes()
        {
            basket.AddProduct(Product.Butter);
            basket.AddProduct(Product.Butter);
            basket.AddProduct(Product.Bread);

            basket.AddProduct(Product.Butter);
            basket.AddProduct(Product.Butter);
            basket.AddProduct(Product.Bread);

            Assert.That(basket.GetTotal(), Is.EqualTo(4.20m));
        }

        [Test, Ignore("Refactoring offers to seperate classes")]
        public void FourthMilkIsFreeWhenThreeMilksArePurchased()
        {
            basket.AddProduct(Product.Milk);
            basket.AddProduct(Product.Milk);
            basket.AddProduct(Product.Milk);
            basket.AddProduct(Product.Milk);

            Assert.That(basket.GetTotal(), Is.EqualTo(3.45m));
        }

        [Test, Ignore("Refactoring offers to seperate classes")]
        public void MilkOfferDoesNotApplyToExtraMilk()
        {
            basket.AddProduct(Product.Milk);
            basket.AddProduct(Product.Milk);
            basket.AddProduct(Product.Milk);
            basket.AddProduct(Product.Milk);
            basket.AddProduct(Product.Milk);

            Assert.That(basket.GetTotal(), Is.EqualTo(4.60m));
        }

        [Test, Ignore("Refactoring offers to seperate classes")]
        public void MilkOfferIsAppliedMultipleTimes()
        {
            basket.AddProduct(Product.Milk);
            basket.AddProduct(Product.Milk);
            basket.AddProduct(Product.Milk);
            basket.AddProduct(Product.Milk);

            basket.AddProduct(Product.Milk);
            basket.AddProduct(Product.Milk);
            basket.AddProduct(Product.Milk);
            basket.AddProduct(Product.Milk);

            Assert.That(basket.GetTotal(), Is.EqualTo(6.90m));
        }
    }

    public interface IOffer
    {
        decimal GetDiscount(IEnumerable<Product> products);
    }
}
