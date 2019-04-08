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
                return "For assembly " + assembly + "was finding error " + ex.Message;
            }
            foreach (Type type in allTypes)
            {
                foreach (MethodInfo mInfo in type.GetMethods())
                {
                    //Console.WriteLine("Now we watching on method " + mInfo.Name);

                    if (FindTestAttribute(mInfo)) 
                    {
                        Console.WriteLine("We found it!");
                        string message = "";
                        string testName = mInfo.Name;
                        //RunMethodsWithAnnotationBefore(assembly, type);

                        PrintInformationAboutTests print = new PrintInformationAboutTests();

                        var attributeProperties = mInfo.GetCustomAttribute<TestMethod>();
                        /*if (attributeProperties.Ignore != 0) // если есть аргумерт Ignore
                        {
                            return print.PrintInformation(default(TimeSpan), attributeProperties.Ignore, testName);
                        }
                        */

                        var watch = new Stopwatch();
                        watch.Start();
                        try
                        {
                            Object run = Activator.CreateInstance(type);
                            mInfo.Invoke(run, Array.Empty<Object>());
                            message = "Test was sucssesed.";
                        }
                        catch (Exception)
                        {
                            /*var exceptionType = ex.InnerException.GetType();
                            if (exceptionType != attributeProperties.Expected)
                            {
                                message = "Test was stopped because of exception " + exceptionType.ToString();
                            }
                            */
                        }
                        
                        /*finally
                        {
                            watch.Stop();
                            TimeSpan ts = watch.Elapsed;
                            print.PrintInformation(ts, message, testName);
                        }
                        */
                        watch.Stop();
                        TimeSpan ts = watch.Elapsed;
                        print.PrintInformation(ts, message, testName); // здесь не надо ничего печатать
                        RunMethodsWithAnnotationAfter(assembly, type);
                    }
                    RunMethodsWithAnnotationAfterClass(assembly, type);
                }
            }
            
            return "0";
        }

        public bool FindTestAttribute(MethodInfo mInfo)
        {
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(mInfo);
            //if (attrs != null && attrs.Length > 0)
                    //Console.WriteLine("Array of attributes in method " + mInfo.Name + " is not empty. " + attrs[0]);
            foreach (System.Attribute i in attrs)
            {
                if (i is TestMethod a)
                {
                    Console.WriteLine(a);
                    return true;
                }
            }
            Console.WriteLine("We did not find it.");
            return false;
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

    public class TestMethod : System.Attribute
    {
        public TestMethod()
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
