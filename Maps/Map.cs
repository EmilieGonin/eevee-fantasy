using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    internal class MapZero
    {
        

        public static void Main() //This function should work when called in main
        {
            Encoding ascii = Encoding.ASCII;

            StreamReader mapzero = new StreamReader("Map_Basic.txt");

            
            string lines;

                while ((lines = mapzero.ReadLine()) != null)
                {
                byte[] asciiString = System.Text.Encoding.ASCII.GetBytes(lines);


                    switch (lines)
                    {
                        case "#":  // if this '#'

                            Console.ForegroundColor = ConsoleColor.Green;
                            
                            
                            break;
                    }

                    Console.WriteLine(lines);

                }



            



        }

    }
} 