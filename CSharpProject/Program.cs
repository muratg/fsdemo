using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDemo
{
    public class Test
    {
        public Test(int x, int y)
        {
            X = x;
            Y = y;
            Name = "";
        }
        public Test(string x)
            : this(0, 0)
        {
            this.Name = x;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public string Name { get; set; }
        public int Mul()
        {
            return this.X * this.Y;
        }
        public int MulSquares()
        {
            return this.X * this.X + this.Y * this.Y;
        }

        public override string ToString()
        {
            return string.Format("({2} {0},{1})", X, Y, Name);
        }

    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var x = Tuple.Create(1, 3.14, "hello");
            var pi = x.Item2;
            Console.WriteLine("{0}", pi);
            var a = new Test(3, 4);
            Console.WriteLine("{0}", a);

            var a1 = 3.4 * (float) a.X;
            var a2 = a.Y * 1000;

        }
    }

}
