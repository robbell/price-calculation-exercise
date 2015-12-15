using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceCalculation.Offers
{
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
}