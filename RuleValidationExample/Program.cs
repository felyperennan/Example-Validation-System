using System;
using System.Collections.Generic;
using System.Text;
using RuleValidationExample.PersonModel;
using ValidationTools;

namespace RuleValidationExample
{
    public class Program
    {

        public static void Main() {
            Person p = new Person();
            Console.Write("Enter Name > ");
            p.Name = Console.ReadLine();
            while(true) {
                Console.Write("Enter Age > ");
                if (!Int32.TryParse(Console.ReadLine(), out int age)) {
                    continue;
                }
                p.Age = age;
                break;
            }
            Console.Write("Licenced? (1: yes, 0: no) > ");
            p.IsLicencedToDrive = Console.ReadKey().KeyChar == '1';
            Console.WriteLine();
            var errors = Validator.RunFor(p);
            foreach(var a in errors) {
                Console.WriteLine($"Error: {a.ErrorMessage}");
            }

            if(!Validator.IsValid(errors)) {
                Console.WriteLine("This person is not valid!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("This person is valid. GG!");

            Console.ReadKey();
        }
    }
}
