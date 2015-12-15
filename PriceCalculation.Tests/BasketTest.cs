using System.Collections.Generic;
using System.Linq;
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
    }

    public class Basket
    {
        private readonly ICollection<Product> products = new List<Product>();
        private static int noOfButterRequiredForOffer = 2;
        private static int noOfBreadRequiredForOffer = 1;

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public decimal GetTotal()
        {
            var discount = GetBreadOfferDiscount();

            return products.Sum(p => p.Price) - discount;
        }

        private decimal GetBreadOfferDiscount()
        {
            var discount = 0m;

            if (products.Count(p => p == Product.Butter) == noOfButterRequiredForOffer
                && products.Count(p => p == Product.Bread) == noOfBreadRequiredForOffer)
            {
                discount += Product.Bread.Price / 2;
            }

            return discount;
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
