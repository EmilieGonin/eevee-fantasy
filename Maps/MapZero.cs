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
        public static void DrawMapZero() //This function should work when called in main
        {
            StreamReader mapzero = new StreamReader("levelzero.txt")) 
            {           
             string lines;

               while ((lines = mapzero.ReadLine()) != null)
               {
                   Console.WriteLine(lines);
                }



           }
            


        }

    }
} 