using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyNUnit
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Right a parth to assembly...");
            string parth = Console.ReadLine();
            var listOfAssemblies = new List<Assembly>();
            while (true)
            {
                listOfAssemblies.Add(Assembly.LoadFrom(parth));
                Console.WriteLine(RunTestsInAssembly.RunTests(Assembly.LoadFrom(parth)));
            }
        }
    }
}

// найти сборки, запустить тесты в сборках
// информацию вывести на экран

// получить информацию о сборке с помощью рефлексии
// найти методы, помеченные анотацией Test, Expected и Ignore
// параллельно запустить тесты

// обработать тест
// получить результат работы теста

// написать тесты на систему тестирования



// ?? что такое методы before и after
