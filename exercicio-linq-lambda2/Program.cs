using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace exercicio_linq_lambda2 {
    class Program {
        static void Main(string[] args) {

            List<Employee> list = new List<Employee>();

            string path = @"D:\c#\Curso c#\Exercicios e exemplos\exercicio-linq-lambda2\exercicio-linq-lambda2\employee.txt";

            using(StreamReader sr = File.OpenText(path)) {
                while (!sr.EndOfStream) {
                    string[] fields = sr.ReadLine().Split(",");
                    string name = fields[0];
                    string email = fields[1];
                    double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);

                    list.Add(new Employee(name, email, salary));
                }
            }

            Console.Write("Enter salary: ");
            double amount = double.Parse(Console.ReadLine());

            Console.WriteLine("Email of people whose salary is more than 2000: ");
            var emails = list.Where(x => x.Salary > amount).Select(x => x.Email);        
            foreach(string x in emails) {
                Console.WriteLine(x);
            }


            Console.Write("Sum of salary of people whose name starts with 'M': ");
            var sum = list.Where(x => x.Name[0] == 'M').Sum(x => x.Salary);
            Console.WriteLine(sum);
        
        }
    }
}
