using System;

namespace Testing
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(150, 100)]
        [TestCase(5, 16)]
        [TestCase(80, 91)]
        public void LevelEqual(int lvl, int expected)
        {
            Eevee eevee = new Eevee();
            Character flareon = new Character();

            for (int i = 0; i < lvl; i++)
            {
                eevee.LevelUp();
            }

            Assert.IsTrue(eevee.lvl == expected);

        }

      /*  [Test]
        [TestCase(3, 50, false)]
        [TestCase(1, 10, true)]
        [TestCase(1, 100, false)]
        public void IsDead(int skill, int lvlEnemy, bool expected)
        {
            Eevee eevee2 = new Eevee();
            BasicEnemy enemy = new BasicEnemy(lvlEnemy, 6);

            enemy.Attribute.SpecialAttacks[skill].Use(eevee2, enemy);
            for (int i = 0; i < 90; i++)
            {
                eevee2.LevelUp();
            }

            Assert.IsTrue(eevee2.Alive == expected);

        }*/
    }
}