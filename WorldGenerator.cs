using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    public class WorldGenerator
    {
        int height;
        int weight;
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
            this.height = heiht;
            this.weight = weight;
            Stage1();
        }

        private void Stage1()
        {
           
            for (int x = 0; x < weight; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Console.Write(0);
                }
            }
        }
        private void Stage2()
        {
        }
    }
}
