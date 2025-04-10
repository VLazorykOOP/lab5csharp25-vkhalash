namespace Lab5CSharp
{
    public class EmployeeTupleManager
    {
        public static void TestTupleManager()
        {
            List<(string Surname, string Name, string Patronymic, string Position, int BirthYear, decimal Salary)> employees = new List<(string, string, string, string, int, decimal)>();
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
        }

        static (string, string, string, string, int, decimal) InputEmployee()
        {
            Console.Write("Surname: ");
            string surname = Console.ReadLine() ?? throw new ArgumentNullException("Surname cannot be null or empty.");

            Console.Write("Name: ");
            string name = Console.ReadLine() ?? throw new ArgumentNullException("Name cannot be null or empty.");

            Console.Write("Patronymic: ");
            string patronymic = Console.ReadLine() ?? throw new ArgumentNullException("Patronymic cannot be null or empty.");

            Console.Write("Position: ");
            string position = Console.ReadLine() ?? throw new ArgumentNullException("Position cannot be null or empty.");

            int birthYear;
            do
            {
                Console.Write("Year of birth: ");
            } while (!int.TryParse(Console.ReadLine(), out birthYear) || birthYear <= 0);

            decimal salary;
            do
            {
                Console.Write("Salary: ");
            } while (!decimal.TryParse(Console.ReadLine(), out salary) || salary <= 0);

            return (surname, name, patronymic, position, birthYear, salary);
        }

        static void DisplayEmployees(List<(string Surname, string Name, string Patronymic, string Position, int BirthYear, decimal Salary)> employees)
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("The employee list is empty.");
                return;
            }

            Console.WriteLine("\nEmployee list:");
            for (int i = 0; i < employees.Count; i++)
            {
                var (Surname, Name, Patronymic, Position, BirthYear, Salary) = employees[i];
                Console.WriteLine($"[{i}] {Surname} {Name} {Patronymic}, " +
                                 $"Position: {Position}, Year of Birth: {BirthYear}, " +
                                 $"Salary: {Salary:C}");
            }
        }

        static void RemoveEmployeeBySurname(List<(string Surname, string Name, string Patronymic, string Position, int BirthYear, decimal Salary)> employees)
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("The employee list is empty.");
                return;
            }

            Console.Write("Enter the surname of the employee to remove: ");
            string surname = Console.ReadLine() ?? string.Empty;

            int initialCount = employees.Count;
            employees.RemoveAll(e => e.Surname.Equals(surname, StringComparison.OrdinalIgnoreCase));

            int removed = initialCount - employees.Count;
            if (removed > 0)
                Console.WriteLine($"Removed {removed} employee(s) with surname {surname}.");
            else
                Console.WriteLine($"No employee found with the surname {surname}.");
        }

        static void AddEmployeeAfterPosition(List<(string Surname, string Name, string Patronymic, string Position, int BirthYear, decimal Salary)> employees)
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("The employee list is empty. Adding the first employee.");
                employees.Add(InputEmployee());
                return;
            }

            DisplayEmployees(employees);

            int position;
            do
            {
                Console.Write("Enter the employee number after which you want to add a new one: ");
            } while (!int.TryParse(Console.ReadLine(), out position) || position < 0 || position >= employees.Count);

            var newEmployee = InputEmployee();
            employees.Insert(position + 1, newEmployee);
            Console.WriteLine("Employee added.");
        }
    }
}
