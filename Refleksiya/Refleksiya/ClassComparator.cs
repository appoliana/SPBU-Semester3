using System;
using System.Collections.Generic;
using System.Reflection;

namespace compclass
{
    /// <summary>
    /// Класс, который решает поставленную задачу.
    /// </summary>
    public class ClassComparator
    {
        /// <summary>
        /// Конструктор, в котором инициализируются списки.
        /// </summary>
        public ClassComparator()
        {
            firstMethods = new List<string>();
            secondMethods = new List<string>();
            firstFields = new List<string>();
            secondFields = new List<string>();
        }

        /// <summary>
        /// Метод, который берет классы на сравнение.
        /// </summary>
        /// <param name="firstClass"></param>
        /// <param name="secondClass"></param>
        public void GetClasses(Type firstClass, Type secondClass)
        {
            firstCl = firstClass;
            secondCl = secondClass;
        }

        /// <summary>
        /// Метод, который все методы класса записывает в список.
        /// </summary>
        private void GetMethods()
        {
            foreach (var method in firstCl.GetMethods())
            {
                if (method is MethodInfo)
                    firstMethods.Add(method.ToString());
            }

            foreach (var method in secondCl.GetMethods())
            {
                if (method is MethodInfo)
                    secondMethods.Add(method.ToString());
            }
        }

        /// <summary>
        /// Метод, который все поля классов записывает в списки.
        /// </summary>
        private void GetFields()
        {
            foreach (var field in firstCl.GetFields())
            {
                if (field is FieldInfo)
                    firstFields.Add(field.ToString());
            }

            foreach (var field in secondCl.GetFields())
            {
                if (field is FieldInfo)
                    secondFields.Add(field.ToString());
            }
        }

        /// <summary>
        /// Метод, который печатает разные поля и методы.
        /// </summary>
        public void PrintDiffMethodsAndFields()
        {
            Console.WriteLine("Different Fields:");
            PrintDiffFields();
            Console.WriteLine("Different Methods:");
            PrintDiffMethods();
        }

        /// <summary>
        /// Метод для выявления различных методов и полей в классах.
        /// </summary>
        private void PrintDiffMethods()
        {
            GetMethods();
            foreach (var m in firstMethods)
            {
                if (!secondMethods.Contains(m))
                    Console.WriteLine(m);
            }

            foreach (var m in secondMethods)
            {
                if (!firstMethods.Contains(m))
                    Console.WriteLine(m);
            }
        }

        /// <summary>
        /// Метод для печати различных полей сравнивымаемых классов.
        /// </summary>
        private void PrintDiffFields()
        {
            GetFields();
            foreach (var f in firstFields)
            {
                if (!secondFields.Contains(f))
                    Console.WriteLine(f);
            }

            foreach (var f in secondFields)
            {
                if (!firstFields.Contains(f))
                    Console.WriteLine(f);
            }
        }

        private Type firstCl;
        private List<string> firstMethods;
        private List<string> firstFields;

        private Type secondCl;
        private List<string> secondMethods;
        private List<string> secondFields;
    }
}
