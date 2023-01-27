using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eevee_fantasy
{
    public class Character
    {

        protected int X { get; set; }
        protected int Y { get; set; }
        
        public string? Name { get; protected set; }
        public Skill[]? Skills { get; }
        public Attribute? Attribute { get; }


        public int TotalXP { get; protected set; }
        public int XPToGet { get; protected set; }

        public int TotalHp { get; protected set; }
        public int TotalDef { get; protected set; }
        public int TotalMagicDef { get; protected set; }
        public int TotalAtk { get; set; }
        public int BattleHp { get; set; }
        public int Speed { get; protected set; }
        public bool Alive { get; protected set; }

        public Character()
        {
            TotalHp = TotalDef = TotalAtk = BattleHp = 0;
            Alive = true;
        }

        public void unlockSkill()
        {
            //
        }

        public void LooseHp(int amount)
        {
            BattleHp -= amount;
            if (BattleHp < 0)
            {
                Alive = false;
                BattleHp = 0;
            }
        }

        public void Move(char input)
        {
            //Console.WriteLine("test");

            //Console.WriteLine("test");
            Console.SetCursorPosition(X, Y);

            switch (input)
            {
                case 'z':
                    Y -= 1;
                    break;
                case 'q':
                    X -= 1;
                    break;
                case 's':
                    Y += 1;
                    break;
                case 'd':
                    X += 1;
                    break;

            }

            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write('E');
            Console.SetCursorPosition(0, 22);
            //Console.WriteLine("test");

        }
        public void Spawn(int mapX, int mapY)
        {
            X = mapX;
            Y = mapY;
            Console.SetCursorPosition(mapX, mapY);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write('E');
            Console.SetCursorPosition(0, 22);

        }

    }
}
