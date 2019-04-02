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
            var allTypes = new Type[10000];
            try
            {
                allTypes = assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException ex)
            {
                return "Для сборки " + assembly + "выявлена ошибка " + ex.Message;
            }
            foreach (Type type in allTypes)
            {
                foreach (MethodInfo mInfo in type.GetMethods())
                {
                    Console.WriteLine("Now we see on method " + mInfo.Name);
                    RunMethodsWithAnnotationBeforeClass(assembly, type);

                    if (Attribute.GetCustomAttributes(mInfo).GetType() == typeof(TestAttribute))
                    {
                        string message = "";
                        string testName = mInfo.Name;
                        RunMethodsWithAnnotationBefore(assembly, type);

                        PrintInformationAboutTests print = new PrintInformationAboutTests();

                        var attributeProperties = mInfo.GetCustomAttribute<TestAttribute>();
                        if (attributeProperties.Ignore != 0) // если есть аргумерт Ignore
                        {
                            return print.PrintInformation(default(TimeSpan), attributeProperties.Ignore, testName);
                        }

                        var watch = new Stopwatch();
                        watch.Start();
                        try
                        {
                            Object run = Activator.CreateInstance(type);
                            
                            mInfo.Invoke(run, Array.Empty<Object>());
                        }
                        catch (Exception ex)
                        {
                            var exceptionType = ex.InnerException.GetType();
                            if (exceptionType != attributeProperties.Expected)
                            {
                                message = "Test was stopped because of exception " + exceptionType.ToString();
                            }
                        }
                        finally
                        {
                            watch.Stop();
                            TimeSpan ts = watch.Elapsed;
                            print.PrintInformation(ts, message, testName);
                        }
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
