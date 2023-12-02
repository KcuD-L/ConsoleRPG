using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Mathm
{
    public struct Matrix2
    {
        public static int[,] matrix = new int[0,0];

        public Matrix2(int row, int column)
        {
            matrix = new int[row, column];
        }

        public static Matrix2 operator +(Matrix2 left, Matrix2 right)
        {
            if (left.GetLength(0) == right.GetLength(0))
            {
                matrix.GetLength(0);
            }
        }
        public static int GetLength(int dimention) => GetLength(dimention);
    }
}
