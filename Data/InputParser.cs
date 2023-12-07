using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Data
{
    static public class InputParser
    {
        static private int r;
        static public bool IsNumber(string txt) => Int32.TryParse(txt, out r);

        static public bool inBounds(int num, int min, int max)
        {
            if (min <= num && num <= max)
            {
                return true;
            }
            return false;
        }

        static public int? InputBounds(int min, int max)
        {
            string txt = Console.ReadLine();
            if (!IsNumber(txt))
            {
                return null;
            }
            if (inBounds(Int32.Parse(txt), min, max))
            {
                return Int32.Parse(txt);
            }
            return null;
        }

        static public void PrintLineCenter(string txt)
        {
            int W = Console.WindowWidth;
            int l = txt.Length;
            int space = (W / 2) - (l / 2);
            for (int i = 0; i < space; i++)
            {
                txt = txt.Insert(0, " ");
            }
            Console.WriteLine(txt);
        }

        static public void PrintSpace(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine();
            }
        }
    }
}
