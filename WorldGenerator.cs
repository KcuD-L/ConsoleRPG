using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ConsoleRPG
{
    public class WorldGenerator
    {
        private Bitmap image;
        private int[,] world;
        Random rnd = new Random();
        enum TerrainType
        {
            water = 0,
            sand = 1,
            grass = 2,
            mountain = 3
        }

        public WorldGenerator(int heiht, int weight)
        {
            this.world = new int[heiht, weight];
            image = new Bitmap(heiht, weight);
            Gen();
        }

        private void Gen()
        {
            ZeroStage();
            for (int i = 0; i < 10; i++)
            {
                AutomataTerrainStage();
            }
            for (int x = 0; x < world.GetLength(0); x++)
            {
                for (int y = 0; y < world.GetLength(1); y++)
                {
                    Console.Write(world[x, y]);
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
        }

        private void ZeroStage()
        {
            for (int x = 0; x < world.GetLength(0); x++)
            {
                for (int y = 0; y < world.GetLength(1); y++)
                {
                    world[x, y] = 0;
                }
            }

            for (int x = 0; x < world.GetLength(0); x++)
            {
                for (int y = 0; y < world.GetLength(1); y++)
                {
                    world[x, y] = rnd.Next(0, 2);
                }
            }
        }

        private void AutomataTerrainStage()
        {
            for (int x = 1; x < world.GetLength(0); x++)
            {
                for (int y = 1; y < world.GetLength(1); y++)
                {
                    if (world[x, y] == 1)
                    {
                        switch (Sum(x, y) - 1)
                        {
                            case 0:
                                world[x, y] = 0;
                                break;
                            case 1:
                                world[x, y] = 0;
                                break;
                            case 2:
                                world[x, y] = 0;
                                break;
                            case 3:
                                world[x, y] = 1;
                                break;
                            case 4:
                                world[x, y] = 1;
                                break;
                            case 5:
                                world[x, y] = 0;
                                break;
                            case 6:
                                world[x, y] = 1;
                                break;
                            case 7:
                                world[x, y] = 1;
                                break;
                            case 8:
                                world[x, y] = 1;
                                break;
                        }
                    }
                    else
                    {
                        switch (9 - Sum(x, y))
                        {
                            case 0:
                                world[x, y] = 0;
                                break;
                            case 1:
                                world[x, y] = 0;
                                break;
                            case 2:
                                world[x, y] = 0;
                                break;
                            case 3:
                                world[x, y] = 1;
                                break;
                            case 4:
                                world[x, y] = 0;
                                break;
                            case 5:
                                world[x, y] = 0;
                                break;
                            case 6:
                                world[x, y] = 1;
                                break;
                            case 7:
                                world[x, y] = 1;
                                break;
                            case 8:
                                world[x, y] = 1;
                                break;
                        }
                    }
                }
            }
        }
        private int Sum(int xx, int yy)
        {
            int s = 0;
            for (int x = 0; x < 2; x++)
            {
                for (int y = 0; y < 2; y++)
                {
                    int x3 = xx + x;
                    int y3 = yy + y;
                    if (x3 >= world.GetLength(0))
                    {
                        x3 -= world.GetLength(0);
                    }
                    if (y3 >= world.GetLength(1))
                    {
                        y3 -= world.GetLength(1);
                    }
                    s += world[x3, y3];
                }
            }
            return s;
        }
    }
}