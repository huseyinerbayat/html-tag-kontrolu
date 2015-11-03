using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13253020HW1
{
    class Test
    {
        static void Main(string[] args)
        {
            Html html = new Html();
            html.IsTrue(@"C:\testData.html");
        }
    }
}
