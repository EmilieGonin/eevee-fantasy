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
            bool play = true;
            MapZero mapZero = new MapZero(); 
            //mapZero.test();
            mapZero.CreateMap();
            mapZero.DrawMap();

            Party myParty = new Party();
            Eevee eevee = new Eevee();
            myParty.AddMember(eevee);
            eevee.Spawn(mapZero.X, mapZero.Y);

            while (play != false)
            {
                //Console.WriteLine("test");
                ConsoleKeyInfo input = Console.ReadKey(true);
                if (input.KeyChar == 'z')
                {
                    mapZero.DrawMap();
                    eevee.Move(input.KeyChar);
                }
                else if (input.KeyChar == 's')
                {
                    mapZero.DrawMap();
                    eevee.Move(input.KeyChar);
                }
                else if (input.KeyChar == 'q')
                {
                    mapZero.DrawMap();
                    eevee.Move(input.KeyChar);
                }
                else if (input.KeyChar == 'd')
                {
                    mapZero.DrawMap();
                    eevee.Move(input.KeyChar);
                }
            }
            
            //Battle battle = new Battle(myParty);

            Game.Init();
        }
    }
}