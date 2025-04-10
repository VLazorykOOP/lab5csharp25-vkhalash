namespace Lab5CSharp
{
    public class ProductDatabase
    {
        private List<Product> products;

        public ProductDatabase()
        {
            products = [];
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void DisplayAllProducts()
        {
            Console.WriteLine("Product list:");
            foreach (var product in products)
            {
                product.DisplayInfo();
            }
        }

        public void SearchProductsByType(string searchType)
        {
            Console.WriteLine($"Products of type '{searchType.ToUpper()}':");
            bool found = false;

            foreach (var product in products)
            {
                if (product.IsMatchingType(searchType))
                {
                    product.DisplayInfo();
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine($"Products of type '{searchType}' not found.");
            }
        }
    }
}
