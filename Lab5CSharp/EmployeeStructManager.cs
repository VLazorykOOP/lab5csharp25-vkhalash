namespace Lab5CSharp
{
    public struct EmployeeStruct
    {
        public string Surname;
        public string Name;
        public string Patronymic;
        public string Position;
        public int BirthYear;
        public decimal Salary;

        public override readonly string ToString()
        {
            return $"{Surname} {Name} {Patronymic}, Position: {Position}, " +
                   $"Year of Birth: {BirthYear}, Salary: {Salary:C}";
        }
    }

    public class EmployeeStructManager
    {
        public static void TestStructManager()
        {
            List<EmployeeStruct> employees = [];
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Show all Employees");
                Console.WriteLine("3. Remove Employee by Surname");
                Console.WriteLine("4. Add Employee after Specific Index");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 0 || choice > 4)
                {
                    Console.WriteLine("Invalid input. Please enter a number from 0 to 4.");
                    continue;
                }

                try
                {
                    switch (choice)
                    {
                        case 1:
                            employees.Add(InputEmployee());
                            break;
                        case 2:
                            DisplayEmployees(employees);
                            break;
                        case 3:
                            RemoveEmployeeBySurname(employees);
                            break;
                        case 4:
                            AddEmployeeAfterPosition(employees);
                            break;
                        case 0:
                            exit = true;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        public static EmployeeStruct InputEmployee()
        {
            EmployeeStruct employee = new();

            Console.Write("Enter Surname: ");
            employee.Surname = Console.ReadLine() ?? throw new ArgumentNullException("Surname cannot be null or empty.");

            Console.Write("Enter Name: ");
            employee.Name = Console.ReadLine() ?? throw new ArgumentNullException("Name cannot be null or empty.");

            Console.Write("Enter Patronymic: ");
            employee.Patronymic = Console.ReadLine() ?? throw new ArgumentNullException("Patronymic cannot be null or empty.");

            Console.Write("Enter Position: ");
            employee.Position = Console.ReadLine() ?? throw new ArgumentNullException("Position cannot be null or empty.");

            Console.Write("Enter Year of Birth: ");
            if (!int.TryParse(Console.ReadLine(), out employee.BirthYear) || employee.BirthYear <= 1900)
                throw new ArgumentException("Invalid year of birth. Must be greater than 1900.");

            Console.Write("Enter Salary: ");
            if (!decimal.TryParse(Console.ReadLine(), out employee.Salary) || employee.Salary <= 0)
                throw new ArgumentException("Invalid salary. Must be greater than zero.");

            return employee;
        }

        public static void DisplayEmployees(List<EmployeeStruct> employees)
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("Employee list is empty.");
                return;
            }

            Console.WriteLine("\nEmployee List:");
            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine($"[{i}] {employees[i]}");
            }
        }

        public static void RemoveEmployeeBySurname(List<EmployeeStruct> employees)
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("Employee list is empty.");
                return;
            }

            Console.Write("Enter surname of the employee to remove: ");
            string surname = Console.ReadLine() ?? throw new ArgumentNullException("Surname cannot be null or empty.");

            int initialCount = employees.Count;
            employees.RemoveAll(e => e.Surname.Equals(surname, StringComparison.OrdinalIgnoreCase));

            int removed = initialCount - employees.Count;
            Console.WriteLine(removed > 0
                ? $"Removed {removed} employee(s) with surname {surname}."
                : $"No employee found with surname {surname}.");
        }

        public static void AddEmployeeAfterPosition(List<EmployeeStruct> employees)
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("Employee list is empty. Adding first employee.");
                employees.Add(InputEmployee());
                return;
            }

            DisplayEmployees(employees);

            Console.Write("Enter index to insert after: ");
            if (!int.TryParse(Console.ReadLine(), out int position) || position < 0 || position >= employees.Count)
                throw new ArgumentException("Invalid index. Please enter a valid position.");

            EmployeeStruct newEmployee = InputEmployee();
            employees.Insert(position + 1, newEmployee);
            Console.WriteLine("Employee added successfully.");
        }
    }
}
