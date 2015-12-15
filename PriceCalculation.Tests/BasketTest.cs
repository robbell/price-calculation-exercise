using NUnit.Framework;

namespace PriceCalculation.Tests
{
    [TestFixture]
    public class BasketTest
    {
        [Test]
        public void ProvidesTotalCostForAddedProducts()
        {
            var basket = new Basket();

            basket.AddProduct(Product.Butter);
            basket.AddProduct(Product.Milk);
            basket.AddProduct(Product.Bread);

            Assert.That(basket.GetTotal(), Is.EqualTo(2.95m));
        }
    }

    public class Basket
    {
        public decimal GetTotal()
        {
            return 0;
        }

        public void AddProduct(Product product)
        {
        }
    }

    public class Product
    {
        public static Product Butter = new Product();
        public static Product Milk = new Product();
        public static Product Bread = new Product();
    }
}
