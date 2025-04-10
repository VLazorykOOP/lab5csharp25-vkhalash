namespace Lab5CSharp
{
    public class Person
    {
        private string name;
        private int age;

        public int Age { get { return age; } }

        public Person()
        {
            name = "John Doe";
            age = 0;
            Console.WriteLine("Person default constructor called");
        }

        public Person(string name)
        {
            this.name = name;
            age = 0;
            Console.WriteLine("Person parameterized constructor called");
        }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
            Console.WriteLine("Person full constructor called");
        }

        ~Person()
        {
            Console.WriteLine("Person destructor called");
        }

        public virtual void Show()
        {
            Console.WriteLine($"Person: Name: {name}, Age: {age}");
        }
    }
}
