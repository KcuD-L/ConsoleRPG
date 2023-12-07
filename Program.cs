using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRPG.Mathm;
using ConsoleRPG.Data;

namespace ConsoleRPG
{
    static class Program
    {
        static void Main(string[] args)
        {
            int? r = InputParser.InputBounds(0, 100);
            if (r != null)
            {
                Console.WriteLine("zaebis'");
            }
            else
            {
                Console.WriteLine("Huita");
            }
            Console.ReadKey();
        }
    }
}
