using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ConsoleRPG.Mathm;

namespace ConsoleRPG
{
    public class WorldGenerator
    {
        private Bitmap image;
        private int[,] world;

        private int width = 0, height = 0;
        Random rnd = new Random();
        enum TerrainType
        {
            water = 0,
            sand = 1,
            grass = 2,
            mountain = 3
        }

        public WorldGenerator(int x)
        {
            x *= 100;
            this.world = new int[x, x];
            image = new Bitmap(x, x);
            width = x;
            height = x;
            Console.WriteLine("Generate");
            Ellipse();
            Console.WriteLine("Saves");
            SaveWorld();

        }

        private void SaveWorld()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (world[x, y] == 0)
                    {
                        image.SetPixel(x, y, Color.White);
                    }
                    else
                    {
                        image.SetPixel(x, y, Color.HotPink);
                    }
                }
            }
            image.Save("C:/Users/Duck/Documents/img.png");
            Console.Write("Done blyat'!");
        }

        private void Ellipse()
        {
            float C = width/10 + width / 8;
            float r = (width/1.1f);

            Vector2 F1 = new Vector2((float)(-C + width / 2), height / 2);
            Vector2 F2 = new Vector2((float)(C + width / 2), height / 2);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (Vector2.Distance(F1, new Vector2(x, y)) + Vector2.Distance(F2, new Vector2(x, y)) <= r)
                    {
                        world[x, y] = 1;
                    }
                    else
                    {
                        world[x, y] = 0;
                    }
                }
            }
        }
    }
}