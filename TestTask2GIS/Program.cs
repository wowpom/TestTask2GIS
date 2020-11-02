using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask2GIS
{
    class Program
    {
        static void Main(string[] args)
        {
            var mycollection = new MyCollection<int, string, string>();

            mycollection.Add(1, "Петя", "Значение1");
            mycollection.Add(1, "Иван", "Значение2");
            mycollection.Add(2, "Петя", "Значение3");
            mycollection.Add(3, "Иван", "Значение4");
            Debug.Assert(mycollection.Count == 4);

            mycollection.Remove(1, "Иван");

            Debug.Assert(mycollection.Count == 3);
        }
    }
}
