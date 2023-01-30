using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eevee_fantasy;
using static System.Net.Mime.MediaTypeNames;

namespace eevee_fantasy
{
    public class Program
    {
        public static void Main()
        {
            Console.CursorVisible = false;
            bool play = true;
            MapZero mapZero = new MapZero(); 
            //mapZero.test();
            mapZero.CreateMap();
            mapZero.DrawMap();

            Eevee eevee = new Eevee();
            Party.Fill(eevee);
            Game.Init(eevee);

            eevee.Spawn(mapZero.X, mapZero.Y);

            while (play != false)
            {
                //Console.WriteLine("test");
                ConsoleKeyInfo input = Console.ReadKey(true);
                if (input.KeyChar == 'z' && (mapZero.Collisions(eevee.X, eevee.Y-1) != true))
                {
                    mapZero.DrawMap();
                    eevee.Move(input.KeyChar);
                }
                else if (input.KeyChar == 's' && (mapZero.Collisions(eevee.X, eevee.Y+1) != true))
                {
                    mapZero.DrawMap();
                    eevee.Move(input.KeyChar);
                }
                else if (input.KeyChar == 'q' && (mapZero.Collisions(eevee.X-1, eevee.Y) != true))
                {
                    mapZero.DrawMap();
                    eevee.Move(input.KeyChar);
                }
                else if (input.KeyChar == 'd' && (mapZero.Collisions(eevee.X+1, eevee.Y) != true))
                {
                    mapZero.DrawMap();
                    eevee.Move(input.KeyChar);
                }
            }

            //Battle battle = new Battle();
        }
    }
}