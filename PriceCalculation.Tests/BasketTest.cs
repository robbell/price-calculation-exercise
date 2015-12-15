using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using PriceCalculation.Offers;

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
    }
}
