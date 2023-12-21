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
        town = 4,
        forest = 5,
        road = 6
    }

    public class WorldGenerator
    {
        List<Vector2> towns = new List<Vector2>();
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
            Ellipse(); FindBeach(); Mountaingen(); Forestgen(); Towngen(); Roadgen();
            Console.WriteLine();
            SaveWorld();
            Console.WriteLine();
            Console.WriteLine("Done");
        }

        private void SaveWorld()
        {
            Console.Write("Saves  ");
            int pers = 0;
            for (int x = 0; x < width; x++)
            {
                int per = Percent(x, height);
                if (pers != per && per % 10 == 0)
                {
                    Console.Write(per + "%  ");
                    pers = per;
                }
                for (int y = 0; y < height; y++)
                {
                    switch (world[x, y])
                    {
                        case TerrainType.water:
                            image.SetPixel(x, y, Color.Blue);
                            break;
                        case TerrainType.sand:
                            image.SetPixel(x, y, Color.Yellow);
                            break;
                        case TerrainType.grass:
                            image.SetPixel(x, y, Color.LimeGreen);
                            break;
                        case TerrainType.mountain:
                            image.SetPixel(x, y, Color.Gray);
                            break;
                        case TerrainType.town:
                            image.SetPixel(x, y, Color.Indigo);
                            break;
                        case TerrainType.forest:
                            image.SetPixel(x, y, Color.DarkGreen);
                            break;
                        case TerrainType.road:
                            image.SetPixel(x, y, Color.Cyan);
                            break;
                    }
                }
            }
            image.Save("C:/Users/Duck/Documents/img.png");
        }

        private void Ellipse()
        {
            Console.Write("Generate  ");
            float C = width / 10 + width / 8;
            float r = (width / 1.1f);

            Vector2 F1 = new Vector2((float)(-C + width / 2), height / 2);
            Vector2 F2 = new Vector2((float)(C + width / 2), height / 2);
            int pers = 0;
            for (int x = 0; x < width; x++)
            {
                int per = Percent(x, height);
                if (pers != per && per % 10 == 0)
                {
                    Console.Write(per + "%  ");
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
            for (int i = 0; i < width / 2; i++)
            {
                x = rnd.Next(4, height - 4);
                y = rnd.Next(4, height - 4);
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

        private void Forestgen()
        {
            int x, y;
            for (int i = 0; i < width / 2; i++)
            {
                x = rnd.Next(5, height - 5);
                y = rnd.Next(5, height - 5);
                for (int t = -4; t < 4; t++)
                {
                    for (int j = -4; j < 5; j++)
                    {
                        int xx = x + t;
                        int yy = y + j;
                        if (world[CheckBounds(xx), CheckBounds(yy)] == TerrainType.grass)
                        {
                            world[CheckBounds(xx), CheckBounds(yy)] = TerrainType.forest;
                        }
                    }
                }

            }
        }

        private void Towngen()
        {
            int num = (height / 100) * (height / 100) * 2;
            int x, y;
            for (int i = 0; i < num; i++)
            {
                x = rnd.Next(1, height);
                y = rnd.Next(1, height);
                float d = 1000;
                List<Vector2> n = Neibors(200, new Vector2(x, y), TerrainType.town);
                if (n.Count <= 0)
                {}
                else
                {
                    d = Vector2.AverageDistance(new Vector2(x, y), n);
                }
                if (world[x, y] == TerrainType.grass && d >= 80)
                {
                    world[x, y] = TerrainType.town;
                    towns.Add(new Vector2(x, y));
                }
            }
        }

        private void Roadgen()
        {
            Dictionary<Vector2, List<Vector2>> done = new Dictionary<Vector2, List<Vector2>>();
            List<Vector2> tmp = new List<Vector2>();
            tmp.Add(new Vector2(0, 0));
            for (int i = 0; i < towns.Count; i++)
            {
                Vector2 a = towns[i];
                List<List<Vector2>> values = new List<List<Vector2>>(done.Values);
                List<Vector2> val = new List<Vector2>();
                for (int k = 0; k < values.Count; k++)
                {
                    for(int v = 0; v < values[k].Count; v++)
                    {
                        val.Add(values[k][v]);
                    }
                }
                if (!val.Contains(a))
                {
                    List<Vector2> n = Neibors(100, a, TerrainType.town);
                    done.Add(a, tmp);
                    for (int j = 0; j < n.Count; j++)
                    {
                        Vector2 b = n[j];
                        if (!done[towns[i]].Contains(b))
                        {
                            done[towns[i]].Add(b);
                            Vector2 step = Vector2.Normalize(Vector2.Lenght(a, b));
                            while ((int)a.x != (int)b.x && (int)a.y != (int)b.y)
                            {
                                step = Vector2.Normalize(Vector2.Lenght(a, b));
                                a += step;
                                world[(int)a.x, (int)a.y] = TerrainType.road;
                            }
                        }
                    }
                }
            }
            Redraw(towns, TerrainType.town);
        }

        private int CheckBounds(int num)
        {
            if (num >= height)
            {
                num = height - 1;
            }
            if (num < 0)
            {
                num = 0;
            }
            return num;
        }

        private int Percent(int iteration, int all)
        {
            int pp = 0;
            pp = 100 * iteration / all;
            return pp;
        }

        private void Redraw(Vector2[] pos, TerrainType type)
        {
            for (int i = 0; i < pos.Length; i++)
            {
                world[(int)pos[i].x, (int)pos[i].y] = type;
            }
        }

        private void Redraw(List<Vector2> pos, TerrainType type)
        {
            for (int i = 0; i < pos.Count; i++)
            {
                world[(int)pos[i].x, (int)pos[i].y] = type;
            }
        }

        private List<Vector2> Neibors(int distance, Vector2 point, TerrainType type)
        {
            Vector2 a = new Vector2(0, 0);
            List<Vector2> n = new List<Vector2>();
            for (int x = -distance / 2; x < distance / 2; x++)
            {
                for (int y = -distance / 2; y < distance / 2; y++)
                {
                    a = point + new Vector2(x, y);
                    a.x = CheckBounds((int)a.x);
                    a.y = CheckBounds((int)a.y);
                    if (world[(int)a.x, (int)a.y] == type)
                    {
                        n.Add(a);
                    }
                }
            }
            return n;
        }
    }
}