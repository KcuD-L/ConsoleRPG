using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRPG.Mathm;
using ConsoleRPG.Data;
using System.Runtime.InteropServices;

namespace ConsoleRPG
{
    static class Program
    {
        static void Main(string[] args) 
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            var consoleWnd = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            Imports.SetWindowPos(consoleWnd, 0, 0, 0, 0, 0, Imports.SWP_NOSIZE | Imports.SWP_NOZORDER);

            InputParser.PrintLineCenter("~~~ Console RPG ~~~");
            InputParser.PrintSpace(10);


            WorldOptions();
        }

        static void WorldOptions()
        {
            Console.WriteLine("  Выберите размер мира (от 5 до 100)");
            int? r = InputParser.InputBounds(5, 100);
            if (r != null)
            {
                WorldGenerator world = new WorldGenerator((int)r);
            }
            else
            {
                Console.Clear();
                InputParser.PrintLineCenter("Введённые данные не верны");
                WorldOptions();
            }
            Console.ReadKey();
        }
    }
    static class Imports
    {
        public static IntPtr HWND_BOTTOM = (IntPtr)1;
        public static IntPtr HWND_TOP = (IntPtr)0;

        public static uint SWP_NOSIZE = 1;
        public static uint SWP_NOZORDER = 4;

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, uint wFlags);
    }
}
