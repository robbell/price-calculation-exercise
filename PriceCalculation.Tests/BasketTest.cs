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
            basket = new Basket();
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
        public void BreadIsHalfPriceWhenTwoButtersArePurchased()
        {
            basket.AddProduct(Product.Butter);
            basket.AddProduct(Product.Butter);
            basket.AddProduct(Product.Bread);

            Assert.That(basket.GetTotal(), Is.EqualTo(2.10m));
        }

        [Test]
        public void BreadOfferDoesNotApplyToExtraBread()
        {
            basket.AddProduct(Product.Butter);
            basket.AddProduct(Product.Butter);
            basket.AddProduct(Product.Bread);
            basket.AddProduct(Product.Bread);

            Assert.That(basket.GetTotal(), Is.EqualTo(3.10m));
        }

        [Test]
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

        [Test]
        public void FourthMilkIsFreeWhenThreeMilksArePurchased()
        {
            basket.AddProduct(Product.Milk);
            basket.AddProduct(Product.Milk);
            basket.AddProduct(Product.Milk);
            basket.AddProduct(Product.Milk);

            Assert.That(basket.GetTotal(), Is.EqualTo(3.45m));
        }

        [Test]
        public void MilkOfferDoesNotApplyToExtraMilk()
        {
            basket.AddProduct(Product.Milk);
            basket.AddProduct(Product.Milk);
            basket.AddProduct(Product.Milk);
            basket.AddProduct(Product.Milk);
            basket.AddProduct(Product.Milk);

            Assert.That(basket.GetTotal(), Is.EqualTo(4.60m));
        }

        [Test]
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
}
