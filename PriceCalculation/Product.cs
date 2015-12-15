namespace PriceCalculation
{
    public class Product
    {
        public static Product Butter = new Product { Price = 0.80m };
        public static Product Milk = new Product { Price = 1.15m };
        public static Product Bread = new Product { Price = 1.00m };

        public decimal Price { get; set; }
    }
}