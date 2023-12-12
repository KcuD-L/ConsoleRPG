using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ConsoleRPG.Mathm;

namespace ConsoleRPG
{
    enum TerrainType
    {
        water = 0,
        sand = 1,
        grass = 2,
        mountain = 3,
        town = 4
    }

    public class WorldGenerator
    {
        private Bitmap image;
        private TerrainType[,] world;

        private int width = 0, height = 0;
        Random rnd = new Random();
        

        public WorldGenerator(int x)
        {
            x *= 100;
            this.world = new TerrainType[x, x];
            image = new Bitmap(x, x);
            width = x;
            height = x;
            Console.WriteLine("Generate");
            Ellipse();
            Console.WriteLine("Beach");
            FindBeach();
            Console.WriteLine("Mountain");
            Mountaingen();
            Console.WriteLine("Set Towns");
            Towngen();
            Console.WriteLine("Saves");
            SaveWorld();
            Console.WriteLine("Done");
        }

        private void SaveWorld()
        {
            int pers = 0;
            for (int x = 0; x < width; x++)
            {
                int per = Percent(x, height);
                if (pers != per && per % 10 == 0)
                {
                    Console.WriteLine(per + "%");
                    pers = per;
                }
                for (int y = 0; y < height; y++)
                {
                    switch(world[x,y])
                    {
                        case TerrainType.water: 
                            image.SetPixel(x, y, Color.Blue);
                            break;
                        case TerrainType.sand:
                            image.SetPixel(x, y, Color.Yellow);
                            break;
                        case TerrainType.grass:
                            image.SetPixel(x, y, Color.Green);
                            break;
                        case TerrainType.mountain:
                            image.SetPixel(x, y, Color.Gray);
                            break;
                        case TerrainType.town:
                            image.SetPixel(x, y, Color.Indigo);
                            break;
                    }
                }
            }
            image.Save("C:/Users/Duck/Documents/img.png");
        }

        private void Ellipse()
        {
            
            float C = width/10 + width / 8;
            float r = (width/1.1f);

            Vector2 F1 = new Vector2((float)(-C + width / 2), height / 2);
            Vector2 F2 = new Vector2((float)(C + width / 2), height / 2);
            int pers = 0;
            for (int x = 0; x < width; x++)
            {
                int per = Percent(x, height);
                if (pers != per && per % 10 == 0)
                {
                    Console.WriteLine(per + "%");
                    pers = per;
                }
                for (int y = 0; y < height; y++)
                {
                    if (Vector2.Distance(F1, new Vector2(x, y)) + Vector2.Distance(F2, new Vector2(x, y)) <= r)
                    {
                        world[x, y] = TerrainType.grass;
                    }
                    else
                    {
                        world[x, y] = TerrainType.water;
                    }
                }
            }
        }

        private void FindBeach()
        {
            for (int x = 0; x < width; x++)
            {
                int per = Percent(x, height);
                for (int y = 0; y < height; y++)
                {
                    if (world[x, y] == TerrainType.grass)
                    {
                        if (world[x - 1, y] == TerrainType.water || world[x + 1, y] == TerrainType.water || world[x, y - 1] == TerrainType.water || world[x, y + 1] == TerrainType.water)
                        {
                            world[x, y] = TerrainType.sand;
                        }
                    }
                }
            }
        }

        private void Mountaingen()
        {
            int x, y;
            for (int i = 0; i < width/2; i++)
            {
                x = rnd.Next(4, height-4);
                y = rnd.Next(4, height-4);
                for (int t = -3; t < 4; t++)
                {
                    for (int j = -3; j < 4; j++)
                    {
                        int xx = x + t;
                        int yy = y + j;
                        if (world[CheckBounds(xx), CheckBounds(yy)] == TerrainType.grass)
                        {
                            world[CheckBounds(xx), CheckBounds(yy)] = TerrainType.mountain;
                        }
                    }
                }
                
            }
        }

        private void Towngen()
        {
            int num = (height / 100) * (height / 100)*2;
            int x, y;
            for(int i = 0; i < num; i++)
            {
                x = rnd.Next(1, height);
                y = rnd.Next(1, height);
                if (world[x, y] != TerrainType.grass)
                {
                    i--;
                }
                else
                {
                    world[x, y] = TerrainType.town;
                }
            }
        }

        private int CheckBounds(int num)
        {
            if (num > height-1)
            {
                num = 0;
            }
            if (num < 0)
            {
                num = height;
            }
            return num;
        }

        private int Percent(int iteration, int all)
        {
            int pp = 0;
            pp = 100 * iteration / all;
            return pp;
        }
    }    
}