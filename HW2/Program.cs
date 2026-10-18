using System;

namespace HW2
{
    class Person
    {
        private string name;
        private string address;
        private double salary;

        // Constructors
        public Person() { }

        public Person(string name, string address, double salary)
        {
            this.name = name;
            this.address = address;
            this.salary = salary;
        }

        // Get/Set properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        // Function inputPersonInfo
        public static Person inputPersonInfo(string name, string address, string sSalary)
        {
            if (string.IsNullOrWhiteSpace(sSalary))
            {
                throw new Exception("You must input Salary.");//Exception: Salary is required
            }

            if (!double.TryParse(sSalary, out double salaryValue))
            {
                throw new Exception("You must input digit.");//Exception: Salary must be a number
            }

            if (salaryValue <= 0)
            {
                throw new Exception("Salary is greater than zero");//Exception: Salary must be greater than zero
            }

            return new Person(name, address, salaryValue);
        }

        // Function displayPersonInfo
        public static void displayPersonInfo(Person person)
        {
            Console.WriteLine("Information of Person you have entered:");
            Console.WriteLine($"Name: {person.Name}");
            Console.WriteLine($"Address: {person.Address}");
            Console.WriteLine($"Salary: {person.Salary}");
        }

        // Function sortBySalary
        public static Person[] sortBySalary(Person[] personArray)
        {
            try
            {
                int n = personArray.Length;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (personArray[j].Salary > personArray[j + 1].Salary)
                        {
                            Person temp = personArray[j];
                            personArray[j] = personArray[j + 1];
                            personArray[j + 1] = temp;
                        }
                    }
                }
                return personArray;
            }
            catch (Exception)
            {
                throw new Exception("Can't Sort Person");
            }
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("=====Management Person programer=====");
            Person[] persons = new Person[3];

            // Function 1: Input Data for 3 persons
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Input Information of Person");

                Console.Write("Please input name: ");
                string name = Console.ReadLine();

                Console.Write("Please input address: ");
                string address = Console.ReadLine();

                double salary = 0;
                while (true)
                {
                    Console.Write("Please input salary: ");
                    string sSalary = Console.ReadLine();
                    try
                    {
                        Person p = Person.inputPersonInfo(name, address, sSalary);
                        salary = p.Salary;
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                persons[i] = new Person(name, address, salary);
            }

            // Function 2 & 3: Perform function, sort and display
            try
            {
                Person[] sortedPersons = Person.sortBySalary(persons);
                foreach (var p in sortedPersons)
                {
                    Person.displayPersonInfo(p);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}