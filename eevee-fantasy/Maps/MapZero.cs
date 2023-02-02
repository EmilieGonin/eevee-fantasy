using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace eevee_fantasy
{
    internal class MapZero : Map
	{
        public MapZero()
        {
            X = 34;
            Y = 18;
            levelCap = 5;

            Histories = new string[]
            {
                ("Welcome to EeveeFantasy!"),
                ("This is a story driven game where you can level up your Pokemons,"),
                ("battle bosses, and other Pokemons in tall grass."),
                ("In order to move Eevee you will have to use the keys: Z,Q,S,D"),
                ("In order to save your progress press the N key"),
                ("In order to open your inventory and Party, press I and P respectively."),
                ("Without further ado, let the story begin!"),
                ("MWUAHAAHAHHAHA!!!!!!"),
                ("Eevee! I have your friends!"),
                ("If you dare try to save them, then head up the mountain"),
                ("MWUAHAHAHAHA!!!..."),
                ("Oh no! What will I do!"),
                ("Hey you! can you please help me save my friends from this monster!"),
                ("If so, let's go up the mountain, I see a cave openning... it must be there")
            }; 

            MapLink = "Map_Basic.txt";
            CreateMap();
        }
    }
}