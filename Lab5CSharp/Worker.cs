namespace Lab5CSharp
{
    public class Worker : Person
    {
        private string jobTitle;

        public Worker() : base()
        {
            jobTitle = "Job Title";
            Console.WriteLine("Worker default constructor called");
        }

        public Worker(string jobTitle)
        {
            this.jobTitle = jobTitle;
            Console.WriteLine("Worker parameterized constructor called");
        }

        public Worker(string name, int age, string jobTitle) : base(name, age)
        {
            this.jobTitle = jobTitle;
            Console.WriteLine("Worker full constructor called");
        }

        ~Worker()
        {
            Console.WriteLine("Worker destructor called");
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Worker: job title: {jobTitle}");
        }
    }
}
