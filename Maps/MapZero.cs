using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class Map
    {
        public static void Main()
        {
            try
            {
                StreamReader mapzero = new StreamReader("levelzero.txt"));
            
                string lines;

                while ((lines = mapzero.ReadLine()) != null)
                {
                    Console.WriteLine(lines);
                }



            }
            catch (Exception e)
            {
                Console.WriteLine("NOOOOOOO");
                Console.WriteLine(e.Message);
            }


        }

    }
}

//.. / eevee_fantasy\bin\Debug\Net7 .0\  