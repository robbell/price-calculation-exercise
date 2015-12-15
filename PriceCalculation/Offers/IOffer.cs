using System.Collections.Generic;

namespace PriceCalculation.Offers
{
    public interface IOffer
    {
        decimal GetDiscount(IEnumerable<Product> products);
    }
}