using System;

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonModel person = new PersonModel();

            //Console.WriteLine("What is your first name?: ");
            //person.FirstName = Console.ReadLine();
            person.FirstName = "What is your first name?: ".RequestString();

            person.LastName = "What is your last name?: ".RequestString();

            //person.Age = "What is your age?: ".RequestInt();
            person.Age = "What is your age?: ".RequestInt(0, 120);

            Console.ReadLine();
        }
    }
}
