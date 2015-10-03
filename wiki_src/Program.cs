using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace simpleex
{
    class Program
    {
        [DllImport("SimpleDLL.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "sum")]
        public static extern int sum(int a, int b);

        static void Main()
        {
            int a = 5;
            int b = 10;
            var c = sum(a, b);
        }
    }
}
