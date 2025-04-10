namespace Lab5CSharp
{
    public record EmployeeRecord(
        string Surname,
        string Name,
        string Patronymic,
        string Position,
        int BirthYear,
        decimal Salary)
    {
        public override string ToString()
        {
            return $"{Surname} {Name} {Patronymic}, Position: {Position}, " +
                   $"Year of Birth: {BirthYear}, Salary: {Salary:C}";
        }
    }

    public class EmployeeRecordManager
    {
        public static void TestRecordManager()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<EmployeeRecord> employees = [];
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add an employee");
                Console.WriteLine("2. Show all employees");
                Console.WriteLine("3. Remove an employee by surname");
                Console.WriteLine("4. Add an employee after a specified position");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
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
                            default:
                                Console.WriteLine("Invalid choice. Try again.");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Enter a number from 0 to 4.");
                }
            }
        }

        static EmployeeRecord InputEmployee()
        {
            Console.Write("Surname: ");
            string surname = Console.ReadLine() ?? throw new ArgumentNullException(nameof(surname), "Surname cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(surname)) throw new ArgumentException("Surname cannot be empty.");

            Console.Write("Name: ");
            string name = Console.ReadLine() ?? throw new ArgumentNullException(nameof(name), "Name cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty.");

            Console.Write("Patronymic: ");
            string patronymic = Console.ReadLine() ?? throw new ArgumentNullException(nameof(patronymic), "Patronymic cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(patronymic)) throw new ArgumentException("Patronymic cannot be empty.");

            Console.Write("Position: ");
            string position = Console.ReadLine() ?? throw new ArgumentNullException(nameof(position), "Position cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(position)) throw new ArgumentException("Position cannot be empty.");

            Console.Write("Year of birth: ");
            if (!int.TryParse(Console.ReadLine(), out int birthYear) || birthYear <= 0)
                throw new ArgumentException("Invalid birth year.");

            Console.Write("Salary: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal salary) || salary <= 0)
                throw new ArgumentException("Invalid salary.");

            return new EmployeeRecord(surname, name, patronymic, position, birthYear, salary);
        }

        static void DisplayEmployees(List<EmployeeRecord> employees)
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("The employee list is empty.");
                return;
            }

            Console.WriteLine("\nEmployee list:");
            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine($"[{i}] {employees[i]}");
            }
        }

        static void RemoveEmployeeBySurname(List<EmployeeRecord> employees)
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("The employee list is empty.");
                return;
            }

            Console.Write("Enter the surname of the employee to remove: ");
            string surname = Console.ReadLine() ?? throw new ArgumentNullException(nameof(surname), "Surname cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(surname)) throw new ArgumentException("Surname cannot be empty.");

            int initialCount = employees.Count;
            employees.RemoveAll(e => e.Surname.Equals(surname, StringComparison.OrdinalIgnoreCase));

            int removed = initialCount - employees.Count;
            if (removed > 0)
                Console.WriteLine($"Removed {removed} employee(s) with surname {surname}.");
            else
                Console.WriteLine($"No employee found with the surname {surname}.");
        }

        static void AddEmployeeAfterPosition(List<EmployeeRecord> employees)
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("The employee list is empty. Adding the first employee.");
                employees.Add(InputEmployee());
                return;
            }

            DisplayEmployees(employees);

            Console.Write("Enter the employee number after which you want to add a new one: ");
            if (!int.TryParse(Console.ReadLine(), out int position) || position < 0 || position >= employees.Count)
                throw new ArgumentException("Invalid position.");

            EmployeeRecord newEmployee = InputEmployee();
            employees.Insert(position + 1, newEmployee);
            Console.WriteLine("Employee added.");
        }
    }
}
