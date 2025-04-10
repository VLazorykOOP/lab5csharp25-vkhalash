namespace Lab5CSharp
{
    internal class Program
    {
        private static void Main()
        {
            Console.Write("Enter option 1-4: ");
            bool isValid = int.TryParse(Console.ReadLine(), out int option) && option >= 1 && option <= 4;

            while (!isValid)
            {
                Console.Write("Please enter a valid option. Enter option 1-4: ");
                isValid = int.TryParse(Console.ReadLine(), out option) && option >= 1 && option <= 4;
            }

            switch (option)
            {
                case 1: Task1(); break;
                case 2: Task2(); break;
                case 3: Task3(); break;
                case 4: Task4(); break;
            }
        }

        private static void Task1()
        {
            static void FillArray(Person[] people)
            {
                people[0] = new Person("John", 50);
                people[1] = new Worker("Emma", 25, "Technician");
                people[2] = new Employee("Robert", 40, "Manager", "ABC Corp", 1000);
                people[3] = new Engineer("Alice", 30, "Software Engineer", "TechCorp", 3000, "Software");
                people[4] = new Engineer("Mark", 35, "Mechanical Engineer", "AutoCorp", 4000, "Mechanical");
            }

            Person[] people = new Person[5];
            FillArray(people);

            foreach (var person in people)
            {
                Console.WriteLine();
                person.Show();
            }
        }

        private static void Task2()
        {
            CreateObjects();

            Console.WriteLine("\nForcing garbage collection:");
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private static void CreateObjects()
        {
            Console.WriteLine("Creating Person objects:");
            _ = new Person();
            _ = new Person("John");
            _ = new Person("Alice", 30);

            Console.WriteLine("\nCreating Worker objects:");
            _ = new Worker();
            _ = new Worker("Software Engineer");
            _ = new Worker("Bob", 35, "Developer");

            Console.WriteLine("\nCreating Employee objects:");
            _ = new Employee();
            _ = new Employee("Google", 5000);
            _ = new Employee("Charlie", 40, "Manager", "Microsoft", 8000);

            Console.WriteLine("\nCreating Engineer objects:");
            _ = new Engineer();
            _ = new Engineer("Electrical");
            _ = new Engineer("David", 45, "Senior Engineer", "Tesla", 10000, "Mechanical");
        }

        private static void Task3()
        {
            var db = new ProductDatabase();

            try
            {
                db.AddProduct(new Toy("LEGO", 1200.50m, "LEGO Group", "Plastic", 6));
                db.AddProduct(new Toy("Plush Bear", 350.99m, "Toy World", "Plush", 0));
                db.AddProduct(new Book("Harry Potter", 420.75m, "J.K. Rowling", "A-BA-BA-GA-LA-MA-GA", 10));
                db.AddProduct(new Book("The Little Prince", 180.00m, "Antoine de Saint-Exupéry", "Old Lion Publishing", 7));
                db.AddProduct(new SportEquipment("Football", 850.25m, "Adidas", 6));
                db.AddProduct(new SportEquipment("Rollerblades", 1800.00m, "Rollerblade", 12));
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Argument exception occurred: {ex.Message}");
            }

            db.DisplayAllProducts();

            string[] searchTypes = ["Toy", "Book", "Sport-Equip"];

            foreach (string searchType in searchTypes)
            {
                Console.WriteLine($"Searching for products of type: {searchType}");
                db.SearchProductsByType(searchType);
            }
        }

        private static void Task4()
        {
            EmployeeRecordManager.TestRecordManager();
            EmployeeTupleManager.TestTupleManager();
            EmployeeRecordManager.TestRecordManager();
        }
    }
}
