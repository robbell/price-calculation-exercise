using System.Collections.Generic;
using System.Linq;

namespace PriceCalculation.Offers
{
    public class MilkOffer : IOffer
    {
        private const int noOfMilkRequiredForOffer = 4;

        public decimal GetDiscount(IEnumerable<Product> products)
        {
            var noOfMilk = products.Count(p => p == Product.Milk);

            var noOfTimesToApplyOffer = noOfMilk / noOfMilkRequiredForOffer;

            return noOfTimesToApplyOffer * Product.Milk.Price;
        }
    }
}