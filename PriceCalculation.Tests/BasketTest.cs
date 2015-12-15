using System.Collections.Generic;
using System.Linq;
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
        private readonly ICollection<Product> products = new List<Product>();

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public decimal GetTotal()
        {
            return products.Sum(p => p.Price);
        }
    }

    public class Product
    {
        public static Product Butter = new Product { Price = 0.80m };
        public static Product Milk = new Product { Price = 1.15m };
        public static Product Bread = new Product { Price = 1.00m };

        public decimal Price { get; set; }
    }
}
