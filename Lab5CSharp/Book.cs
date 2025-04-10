namespace Lab5CSharp
{
    public class Book : Product
    {
        public string Author { get; private set; }
        public string Publisher { get; private set; }

        public Book(string name, decimal price, string author, string publisher, int targetAge)
            : base(name, price, targetAge)  // Call the base constructor
        {
            Author = author ?? throw new ArgumentNullException(nameof(author));
            Publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Book: {Name}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Price: {Price:C}");
            Console.WriteLine($"Publisher: {Publisher}");
            Console.WriteLine($"Target age: {TargetAge}+");
            Console.WriteLine();
        }

        public override bool IsMatchingType(string searchType)
        {
            return searchType.Equals("book", StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
