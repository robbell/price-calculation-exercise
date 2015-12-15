using System.Collections.Generic;
using System.Linq;
using PriceCalculation.Offers;

namespace PriceCalculation
{
    public class Basket
    {
        private readonly IEnumerable<IOffer> offers;
        private readonly ICollection<Product> products = new List<Product>();

        public Basket(IEnumerable<IOffer> offers)
        {
            this.offers = offers;
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public decimal GetTotal()
        {
            return products.Sum(p => p.Price) - offers.Sum(o => o.GetDiscount(products));
        }
    }
}