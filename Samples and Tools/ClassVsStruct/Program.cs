// Credit where credit is deserved.
// This program is taken directly from this MSDN article...
// http://msdn.microsoft.com/en-us/library/aa288471(VS.71).aspx
// with only minor modifications made.

using System;

namespace ClassVsStruct
{
    class TheClass
    {
        public int x;
    }

    struct TheStruct
    {
        public int x;
    }

    class Program
    {
        public static void structtaker(TheStruct s)
        {
            s.x = 5;
        }
        public static void classtaker(TheClass c)
        {
            c.x = 5;
        }
        public static void Main(string[] args)
        {
            TheStruct s = new TheStruct();
            TheClass c = new TheClass();
            s.x = 1;
            s.x = 1;
            structtaker(s);
            classtaker(c);
            Console.WriteLine("s.x = {0}", s.x);
            Console.WriteLine("c.x = {0}", c.x);
        }
    }
}