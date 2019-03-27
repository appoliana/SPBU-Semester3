using System;
using System.Diagnostics;
using System.Reflection;

namespace MyNUnit
{
    public class RunTestsInAssembly
    {
        /// <summary>
        /// Метод, который запускает тесты в сборке.
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public string RunTests(Assembly assembly)
        {
            var allTypes = assembly.GetTypes();
            foreach (Type type in allTypes)
            {
                foreach (MethodInfo mInfo in type.GetMethods())
                {
                    RunMethodsWithAnnotationBeforeClass(assembly, type);

                    if (Attribute.GetCustomAttributes(mInfo).GetType() == typeof(TestAttribute))
                    {
                        RunMethodsWithAnnotationBefore(assembly, type);

                        var watch = new Stopwatch();
                        watch.Start();
                        Object run = Activator.CreateInstance(type);
                        mInfo.Invoke(run, Array.Empty<Object>());
                        watch.Stop();
                        TimeSpan ts = watch.Elapsed;

                        PrintInformationAboutTests print = new PrintInformationAboutTests();
                        print.PrintInformation(ts);

                        RunMethodsWithAnnotationAfter(assembly, type);
                    }

                    RunMethodsWithAnnotationAfterClass(assembly, type);
                }
            }
            return "0";
        }

        public void RunMethodsWithAnnotationBefore(Assembly assembly, Type type)
        {
            var allTypes = assembly.GetTypes();
            foreach (MethodInfo mInfo in type.GetMethods())
            {
                if (Attribute.GetCustomAttributes(mInfo).GetType() == typeof(BeforeAttribute))
                {
                    Object run = Activator.CreateInstance(type);
                    mInfo.Invoke(run, Array.Empty<Object>());
                }
            }
        }

        public void RunMethodsWithAnnotationAfter(Assembly assembly, Type type)
        {
            var allTypes = assembly.GetTypes();
            foreach (MethodInfo mInfo in type.GetMethods())
            {
                if (Attribute.GetCustomAttributes(mInfo).GetType() == typeof(AfterAttribute))
                {
                    Object run = Activator.CreateInstance(type);
                    mInfo.Invoke(run, Array.Empty<Object>());
                }
            }
        }

        public void RunMethodsWithAnnotationBeforeClass(Assembly assembly, Type type)
        {
            var allTypes = assembly.GetTypes();
            foreach (MethodInfo mInfo in type.GetMethods())
            {
                if (Attribute.GetCustomAttributes(mInfo).GetType() == typeof(BeforeClassAttribute))
                {
                    Object run = Activator.CreateInstance(type);
                    mInfo.Invoke(run, Array.Empty<Object>());
                }
            }
        }

        public void RunMethodsWithAnnotationAfterClass(Assembly assembly, Type type)
        {
            var allTypes = assembly.GetTypes();
            foreach (MethodInfo mInfo in type.GetMethods())
            {
                if (Attribute.GetCustomAttributes(mInfo).GetType() == typeof(AfterClassAttribute))
                {
                    Object run = Activator.CreateInstance(type);
                    mInfo.Invoke(run, Array.Empty<Object>());
                }
            }
        }
    }

    public class TestAttribute : System.Attribute
    {
        public TestAttribute()
        {
        }
    }

    public class BeforeAttribute : System.Attribute
    {
        public BeforeAttribute()
        {
        }
    }

    public class AfterAttribute : System.Attribute
    {
        public AfterAttribute()
        {
        }
    }

    public class AfterClassAttribute : System.Attribute
    {
        public AfterClassAttribute()
        {
        }
    }

    public class BeforeClassAttribute : System.Attribute
    {
        public BeforeClassAttribute()
        {
        }
    }
}
