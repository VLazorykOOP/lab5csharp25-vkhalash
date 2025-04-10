namespace Lab5CSharp
{
    internal class Engineer : Employee
    {
        private string discipline;

        public Engineer() : base()
        {
            discipline = "Discipline Name";
            Console.WriteLine("Engineer default constructor called");
        }

        public Engineer(string discipline)
        {
            this.discipline = discipline;
            Console.WriteLine("Engineer parameterized constructor called");
        }

        public Engineer(string name, int age, string jobTitle, string company, decimal salary, string discipline)
            : base(name, age, jobTitle, company, salary)
        {
            this.discipline = discipline;
            Console.WriteLine("Engineer full constructor called");
        }

        ~Engineer()
        {
            Console.WriteLine("Engineer destructor called");
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Engineer: discipline: {discipline}");
        }
    }
}
