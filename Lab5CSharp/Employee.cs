namespace Lab5CSharp
{
    public class Employee : Worker
    {
        private string company;
        private decimal salary;

        public Employee() : base()
        {
            company = "Company Name";
            salary = 0;
            Console.WriteLine("Employee default constructor called");
        }

        public Employee(string company, decimal salary)
        {
            this.company = company;
            this.salary = salary;
            Console.WriteLine("Employee parameterized constructor called");
        }

        public Employee(string name, int age, string jobTitle, string company, decimal salary)
            : base(name, age, jobTitle)
        {
            this.company = company;
            this.salary = salary;
            Console.WriteLine("Employee full constructor called");
        }

        ~Employee()
        {
            Console.WriteLine("Employee destructor called");
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Employee: company: {company}, salary: {salary}");
        }
    }
}
