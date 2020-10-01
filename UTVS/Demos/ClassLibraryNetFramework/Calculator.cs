using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly:InternalsVisibleTo("ClassLibraryNetFramework.UnitTests")]

namespace ClassLibraryNetFramework
{
    public class Calculator
    {
        public int Add(int a, int b) {
            return a + b;
        }

        public int Divide(int a, int b) {
            return a / b;
        }
    }
}
