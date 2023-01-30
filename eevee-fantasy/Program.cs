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

            Eevee eevee = new Eevee();
            Party.Fill(eevee);
            Game.Init(eevee);
            //Game.GameLevel = 1;

            //MapZero mapZero = new MapZero();
            //mapZero.test();


            Map[]? maps = new Map[2] { new MapZero(), new MapOne() };
            Map currentMap = maps[Game.GameLevel];

            //currentMap.CreateMap();
            currentMap.DrawMap();
            eevee.Spawn(currentMap.X, currentMap.Y);

            while (play != false)
            {
                ConsoleKeyInfo input = Console.ReadKey(true);
                    //Console.WriteLine("test");

                if (input.KeyChar == 'z' && (currentMap.Collisions(eevee.X, eevee.Y - 1) != true))
                {
                    currentMap.DrawMap();
                    eevee.Move(input.KeyChar);
                }
                else if (input.KeyChar == 's' && (currentMap.Collisions(eevee.X, eevee.Y + 1) != true))
                {
                    currentMap.DrawMap();
                    eevee.Move(input.KeyChar);
                }
                else if (input.KeyChar == 'q' && (currentMap.Collisions(eevee.X - 1, eevee.Y) != true))
                {
                    currentMap.DrawMap();
                    eevee.Move(input.KeyChar);
                }
                else if (input.KeyChar == 'd' && (currentMap.Collisions(eevee.X + 1, eevee.Y) != true))
                {
                    currentMap.DrawMap();
                    eevee.Move(input.KeyChar);
                }

                if (currentMap.Tp(eevee.X, eevee.Y))
                {
                    currentMap = maps[Game.GameLevel];
                    currentMap.DrawMap();
                    eevee.Spawn(currentMap.X, currentMap.Y);
                }
            }

            //Battle battle = new Battle();
        }
    }
}