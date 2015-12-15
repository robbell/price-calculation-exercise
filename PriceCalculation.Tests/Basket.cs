using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceCalculation.Tests
{
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
}