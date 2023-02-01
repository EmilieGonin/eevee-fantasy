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

        
        public int Id { get; set; }


        public char Sprite { get; set; }
        public char Enemy { get; set; }
        public ConsoleColor Color { get; set; }

        public string? Name { get; protected set; }
        public List<Skill>? Skills { get; protected set; }
        public Attribute? Attribute { get; protected set; }
        public Normal? NormalType { get; protected set; }

        public int TotalXP { get; protected set; }
        public int lvl { get; protected set; }
        public int XPToGet { get; protected set; }

        public int TotalHp { get; protected set; }
        public int TotalDef { get; protected set; }
        public int TotalAtk { get; set; }
        public int BaseHp { get; protected set; }
        public int BaseDef { get; protected set; }
        public int BaseAtk { get; set; }
        public int BattleHp { get; set; }
        public int Speed { get; protected set; }
        public bool Alive { get; set; }
        public bool Recruited { get; set; }
        public bool Beaten { get; set; }

        public Character()
        {

            Skills = new List<Skill>();
            lvl = 1;
            TotalHp = TotalDef = TotalAtk = BattleHp = 0;
            BaseHp = BaseDef = BaseAtk = 0;
            Alive = true;
            Recruited = false;
            Beaten = false;
            NormalType = new Normal();

            TotalXP = lvl * lvl * lvl;
            XPToGet = (lvl + 1) * (lvl + 1) * (lvl + 1);

        }

        public void LevelUp()
        
        {
          
            lvl += 1;
            TotalHp = (int)((2 * BaseHp * lvl) / (100) + 5 + lvl + 10);
            BattleHp = TotalHp;
            TotalDef = (int)((2 * BaseDef * lvl) / (100) + 5 + lvl + 10);
            TotalAtk = (int)((2 * BaseAtk * lvl) / (100) + 5 + lvl + 10);
            XPToGet = lvl * lvl * lvl;
            Speed += 2;
            UnlockSkills();
        }
        public void UnlockSkills()
        {
            if (Skills.Count() == 0)
            {
              
                Skills?.Add(NormalType?.NormalAttack); // tackle
                Skills?.Add(Attribute?.SpecialAttacks?[0]); // first skill 
            
            }

            if (lvl == 15)
            {
                Skills?.Add(Attribute?.SpecialAttacks?[1]);
            }

            if (lvl == 40)
            {
                Skills?.Add(Attribute?.SpecialAttacks?[2]);
            }
           

        }
        public void LooseHp(int amount)
        {
            BattleHp -= amount;
            if (BattleHp <= 0)
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
            Console.ForegroundColor = Color;
            Console.Write(Sprite);
            Console.SetCursorPosition(0, 22);
            //Console.WriteLine("test");
        }

        public void Draw()
        {
            if (!Recruited)
            {
                Console.SetCursorPosition(X, Y); //À ajouter : empêcher le curseur de sortir de la console
                Console.ForegroundColor = Color;
                Console.Write(Sprite);
                Console.SetCursorPosition(0, 22);
            }
            if (!Beaten)
            {
                Console.SetCursorPosition(X, Y); //À ajouter : empêcher le curseur de sortir de la console
                Console.ForegroundColor = Color;
                Console.Write(Enemy);
                Console.SetCursorPosition(0, 22);
            }
        }

        public void Spawn(int mapX, int mapY)
        {
            X = mapX;
            Y = mapY;
            Console.SetCursorPosition(mapX, mapY);
            Console.ForegroundColor = Color;
            Console.Write(Sprite);
            Console.SetCursorPosition(0, 22);
        }
        

    }
}
