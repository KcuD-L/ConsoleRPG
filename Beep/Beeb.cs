using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Beep
{
    static public class Beeb
    {
        static public void PlayMusic(int[,] sound)
        {
            for(int i = 0; i < sound.GetLength(0); i++)
            {
                PlayNote(sound[i,0], sound[i,1]);
            }
        }

        static public void PlayNote(int note, int duration)
        {
            Console.Beep(note, duration);
        }
    }

    static public class Notes
    {
        static public int C() => 261;
        static public int D() => 293;
        static public int E() => 329;
        static public int F() => 349;
        static public int G() => 392;
        static public int A() => 440;
        static public int B() => 493;
    }

    public class Sounds
    {
        static public int[,] example = { { Notes.C(), 1000},
                                         { Notes.E(), 500 },
                                         { Notes.D(), 200 },
                                         { Notes.G(), 1000}
                                       };
    }
}
