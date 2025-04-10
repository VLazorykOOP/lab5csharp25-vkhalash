namespace Lab5CSharp
{
    public class Toy : Product
    {
        public string Manufacturer { get; private set; }
        public string Material { get; private set; }

        public Toy(string name, decimal price, string manufacturer, string material, int targetAge)
            : base(name, price, targetAge)
        {
            Manufacturer = manufacturer ?? throw new ArgumentNullException(nameof(manufacturer));
            Material = material ?? throw new ArgumentNullException(nameof(material));
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Toy: {Name}");
            Console.WriteLine($"Price: {Price:C}");
            Console.WriteLine($"Manufacturer: {Manufacturer}");
            Console.WriteLine($"Material: {Material}");
            Console.WriteLine($"Target age: {TargetAge}+");
            Console.WriteLine();
        }

        public override bool IsMatchingType(string searchType)
        {
            return searchType.Equals("toy", StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
