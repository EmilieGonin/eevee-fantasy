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

        public int X { get; set; }
        public int Y { get; set; }
        
        public string? Name { get; protected set; }
        public Skill[]? Skills { get; protected set; }
        public Attribute? Attribute { get; protected set; }
        public Attribute? NormalType { get; protected set; }


        public int TotalXP { get; protected set; }
        public int lvl { get; protected set; }
        public int XPToGet { get; protected set; }

        public int TotalHp { get; protected set; }
        public int TotalDef { get; protected set; }
        public int TotalMagicDef { get; protected set; }
        public int TotalAtk { get; set; }
        public int BattleHp { get; set; }
        public int Speed { get; protected set; }
        public bool Alive { get; protected set; }
        public bool Recruited { get; set; }

        public Character()
        {
            TotalHp = TotalDef = TotalAtk = BattleHp = 0;
            Alive = true;
            Recruited = false;
            NormalType = new Normal();
        }

        public void LevelUp()
        {
            lvl += 1;
            TotalHp += 100 / 25 * TotalHp;
            TotalDef += 100 / 10 * TotalDef;
            TotalAtk += 100 / 20 * TotalAtk;
            XPToGet = lvl * lvl * lvl;
            Speed += 2;
            UnlockSkills();
        }
        public void UnlockSkills()
        {

            if (Skills == null)
            {
                Skills?.Append(NormalType?.NormalAttack); // tackle
                Skills?.Append(Attribute?.SpecialAttacks?[0]); // first skill 
            }

            if (lvl == 15)
            {
                Skills?.Append(Attribute?.SpecialAttacks?[1]);
            }

            if (lvl == 40)
            {
                Skills?.Append(Attribute?.SpecialAttacks?[2]);
            }

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

            Console.SetCursorPosition(X, Y); //À ajouter : empêcher le curseur de sortir de la console
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
