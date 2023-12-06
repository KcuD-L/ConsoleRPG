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
        private int[,] world, dworld;

        private int width = 0, height = 0;
        Random rnd = new Random();
        enum TerrainType
        {
            water = 0,
            sand = 1,
            grass = 2,
            mountain = 3
        }

        public WorldGenerator(int x, int y)
        {
            this.world = new int[x, y];
            this.dworld = new int[x, y];
            image = new Bitmap(x, y);
            width = x;
            height = y;
            Gen();
            
        }

        private void Gen()
        {
            ZeroStage();
            for (int i = 1; i < 1; i++)
            {
                if (i % 1000 == 0)
                {
                    Console.WriteLine(i);
                }
               /* AutomataTerrainStage();*/
            }
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
                        image.SetPixel(x, y, Color.Black);
                    }
                }
            }
            image.Save("C:/Users/Duck/Documents/img.png");
            Console.Write("Done blyat'!");
        }

        private void ZeroStage()
        {
            double C = (width * (width / height));
            int r = (height / 2 + (width / 2) - width / 50) * (width/height);
            Vector2 F1 = new Vector2 ((float)(-C + width / 2), height / 2);
            Vector2 F2 = new Vector2 ((float)(C + width / 2), height / 2);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    world[x, y] = 0;
                }
            }
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    /*world[x, y] = rnd.Next(0, 2);*/
                    if (Vector2.Distance(F1, new Vector2(x,y)) + Vector2.Distance(F2, new Vector2(x, y)) <= r)
                    {
                        world[x, y] = 1;
                    }

                }
            }
        }

        private void AutomataTerrainStage()
        {
            for (int x = 1; x < width; x++)
            {
                for (int y = height-1; y > 0; y--)
                {
                    if (world[x, y] == 1)
                    {
                        switch (Sum8(x, y) - 1)
                        {
                            case 3: dworld[x, y] = 1; break;
                            case 4: dworld[x, y] = 1; break;
                            case 5: dworld[x, y] = 1; break;
                            case 6: dworld[x, y] = 1; break;
                            case 7: dworld[x, y] = 1; break;
                            case 8: dworld[x, y] = 1; break;
                            default: dworld[x, y] = 1; break;

                        }
                    }
                    else
                    {
                        switch (8 - Sum8(x, y))
                        {
                            case 3: dworld[x, y] = 1; break;
                            case 4: dworld[x, y] = 1; break;
                            case 5: dworld[x, y] = 1; break;
                            case 6: dworld[x, y] = 1; break;
                            case 7: dworld[x, y] = 1; break;
                            case 8: dworld[x, y] = 1; break;
                            default: dworld[x, y] = 1; break;
                        }
                    }
                }
            }
            world = dworld;
        }
        private int Sum8(int x, int y)
        {
            int xx = x;
            int yy = y;
            int s = 0;
            for (int i = -1; i <=1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    xx = x + i;
                    yy = y + j;
                    if (xx == width)
                    {
                        xx = 0;
                    }
                    if (xx < 0)
                    {
                        xx = width;
                    }
                    if (yy == height)
                    {
                        yy = 0;
                    }
                    if (yy < 0)
                    {
                        yy = height;
                    }
                }
            }
            s += world[xx, yy];
            return s;
        }
    }
}