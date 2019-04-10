using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDll
{
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

