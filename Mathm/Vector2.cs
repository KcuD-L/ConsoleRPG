using System;

namespace ConsoleRPG.Mathm
{
    public struct Vector2
    {
        public float x;
        public float y;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        #region simple operation
        public static Vector2 operator +(Vector2 left, Vector2 right) => new Vector2(left.x + right.x, left.y + right.y);

        public static Vector2 operator -(Vector2 left, Vector2 right) => new Vector2(left.x - right.x, left.y - right.y);

        public static Vector2 operator *(Vector2 left, Vector2 right) => new Vector2(left.x * right.x, left.y * right.y);
        public static Vector2 operator *(Vector2 a, double b) => new Vector2((float)(a.x * b), (float)(a.y * b));

        public static Vector2 operator /(Vector2 left, Vector2 right) => new Vector2((float)(left.x / right.x), (float)(left.y / right.y));
        public static Vector2 operator /(Vector2 left, double right) => new Vector2((float)(left.x / right), (float)(left.y / right));

        public static Vector2 Mult(Vector2 a, float b) => new Vector2(a.x * b, a.y * b);

        #endregion

        #region complex operation
        public static float Corner(Vector2 a, Vector2 b) => (float)(Round((((a * b).x + (a * b).y) / (Lenght(a) * Lenght(b))) * 180) / Math.PI);

        public static Vector2 Normal(Vector2 a) => new Vector2(Round((float)(a.x * Math.Cos(Math.PI / 2) - a.y * Math.Sin(Math.PI / 2))),
                                                                  Round((float)(a.y * Math.Cos(Math.PI / 2) + a.x * Math.Sin(Math.PI / 2))));

        public static Vector2 Normalize(Vector2 a) => new Vector2(Round(a.x / Lenght(a)),
                                                                  Round(a.y / Lenght(a)));

        public static float Lenght(Vector2 a) => (float)Math.Pow(Math.Pow(a.x, 2) + Math.Pow(a.y, 2), 0.5f);

        public static float ScalarMult(Vector2 a, Vector2 b, float corner) => (float)((a.x * b.x + a.y * b.y) * Math.Cos(corner));

        public static Vector2 Lenght(Vector2 a, Vector2 b) => new Vector2(b.x - a.x, b.y - a.y);

        public static Vector2 MidNormalShort(Vector2 a) => Normalize(Normal(a)) + a* 0.5f;
        public static Vector2 MidNormal(Vector2 a) => Normal(a) + a * 0.5f;

        private static float Round(float r) => (float)(Math.Round(r * 1000) / 1000);
        #endregion
    }
}