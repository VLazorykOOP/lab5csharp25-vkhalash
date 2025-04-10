namespace Lab5CSharp
{
    public class SportEquipment : Product
    {
        public string Manufacturer { get; private set; }

        public SportEquipment(string name, decimal price, string manufacturer, int targetAge)
            : base(name, price, targetAge)
        {
            Manufacturer = manufacturer ?? throw new ArgumentNullException(nameof(manufacturer));
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Sport equipment: {Name}");
            Console.WriteLine($"Price: {Price:C}");
            Console.WriteLine($"Manufacturer: {Manufacturer}");
            Console.WriteLine($"Target age: {TargetAge}+");
            Console.WriteLine();
        }

        public override bool IsMatchingType(string searchType)
        {
            return searchType.Equals("sport-equip", StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
