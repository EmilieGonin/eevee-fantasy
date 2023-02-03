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
        public int XpGain { get; protected set; }

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
            if (lvl <= 99)
            { 
            lvl += 1;
            TotalHp = (int)((2 * BaseHp * lvl) / (100) + 5 + lvl + 10);
            BattleHp = TotalHp;
            TotalDef = (int)((2 * BaseDef * lvl) / (100) + 5 + lvl + 10);
            TotalAtk = (int)((2 * BaseAtk * lvl) / (100) + 5 + lvl + 10);
            XPToGet = lvl * lvl * lvl;
            Speed += 2;
            UnlockSkills();
            if (TotalXP > XPToGet && lvl != 100)
            {
                LevelUp();
            }
        }
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

        public void giveAttribute(int attribute)
        {
            switch (attribute)
            {
                case 1:
                    //Console.WriteLine("My enemy is normal");
                    Attribute = new Normal();
                    break;
                case 2:
                    //Console.WriteLine("My enemy is Fire");
                    Attribute = new Fire();
                    break;
                case 3:
                    //Console.WriteLine("My enemy is Water");
                    Attribute = new Water();
                    break;
                case 4:
                    //Console.WriteLine("My enemy is Thunder");
                    Attribute = new Thunder();
                    break;
                case 5:
                    //Console.WriteLine("My enemy is Plant");
                    Attribute = new Plant();
                    break;
                case 6:
                    //Console.WriteLine("My enemy is Ice");
                    Attribute = new Ice();
                    break;
                default:
                    break;
            }
        }

        public void LooseHp(int amount)
        {
            BattleHp -= amount;
            if (BattleHp <= 0)
            {
                if (Name != null)
                {
                    new Dialogue(Name + " fainted...");

                }
                else
                {
                    new Dialogue("Enemy fainted...");
                }
                BattleHp = 0;
                Alive = false;
               
            }
        
        
        }

        public void Move(char input)
        {
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
        
        public void WinXp(int amount)
        {
            TotalXP += amount;
            if(TotalXP > XPToGet) { 
                LevelUp();
              
            }
            
        }
    }
}