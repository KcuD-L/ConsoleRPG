using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRPG.Mathm;

namespace ConsoleRPG
{
    static class Program
    {
        static void Main(string[] args)
        {
            WorldGenerator world = new WorldGenerator(1000, 1000);
            Console.ReadKey();
        }
    }
}
