using System;
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

    public class Basket
    {
        private readonly ICollection<Product> products = new List<Product>();
        private static int noOfButterRequiredForOffer = 2;
        private static int noOfMilkRequiredForOffer = 4;

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public decimal GetTotal()
        {
            var discount = GetBreadOfferDiscount();

            discount += GetMilkOfferDiscount();

            return products.Sum(p => p.Price) - discount;
        }

        private decimal GetMilkOfferDiscount()
        {
            var noOfMilk = products.Count(p => p == Product.Milk);

            var noOfTimesToApplyOffer = noOfMilk / noOfMilkRequiredForOffer;

            return noOfTimesToApplyOffer * Product.Milk.Price;
        }

        private decimal GetBreadOfferDiscount()
        {
            var noOfButter = products.Count(p => p == Product.Butter);
            var noOfBread = products.Count(p => p == Product.Bread);

            var noOfTimesOfferCanApply = noOfButter / noOfButterRequiredForOffer;
            var noOfTimesToApplyOffer = Math.Min(noOfBread, noOfTimesOfferCanApply);

            return noOfTimesToApplyOffer * (Product.Bread.Price / 2);
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
