namespace Lab5CSharp
{
    public abstract class Product
    {
        public string Name { get; protected set; }
        public decimal Price { get; protected set; }
        public int TargetAge { get; protected set; }

        protected Product(string name, decimal price, int targetAge)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
            TargetAge = targetAge;
        }

        public abstract void DisplayInfo();

        public abstract bool IsMatchingType(string searchType);
    }
}
