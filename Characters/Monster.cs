using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haven___Text_Adventure
{
    public class Monster : Character
    {
        public List<Item> LootDrops { get; set; }
        public bool HasBeenKilled { get; set; }
        public int TimesBeenKilled { get; set; }
        public Monster(string name, int health, int attack, int defense, int level, int experience, List<Item> lootDrops)
        {
            Name = name;
            HP = health;
            ATK = attack;
            DEF = defense;
            LVL = level;
            EXP = experience;
            MaxHealth = health;
            LootDrops = lootDrops;
            HasBeenKilled = false;
            TimesBeenKilled = 0;
        }

        public void PerformAttack(Character target, int yPos)
        {

            if (this.IsAlive())
            {
                int damage = ATK - target.DEF;
                if (damage < 0)
                {
                    damage = 0;
                }
                target.HP -= damage;
                if(target.HP < 0)
                {
                    target.HP = 0;
                }
                Console.SetCursorPosition(5, yPos);
                Console.Write(Name + " dealt " + damage + " damage to " + target.Name);
                Console.SetCursorPosition(5, yPos + 1);
                Console.Write(target.Name + " has [" + target.HP + "] health left");
            }
            else
            {
                Console.SetCursorPosition(5, yPos);
                Console.Write(Name + " fell under the blow of " + target.Name);
                Console.SetCursorPosition(5, yPos + 1);
                Console.Write(target.Name + " begins looting the corpse");
            }
            
        }

        public Item ObtainLoot(int yPos)
        {
            Random random = new Random();

            
            double twoInTen = random.NextDouble();

            if(this.Name == "Cursed Dragon")
            {
                if (twoInTen <= 1) //TODO: REMEMBER TO CHANGE BACK LOOT DROP LATER
                {
                    int drop = random.Next(LootDrops.Count);
                    Console.SetCursorPosition(5, yPos);
                    Console.Write("You came across an ominous " + LootDrops[drop].Name);
                    return LootDrops[drop];
                }
                else
                {
                    return null;
                }
            }
            else
            {
                if (twoInTen <= 0.7) //TODO: REMEMBER TO CHANGE BACK LOOT DROP LATER
                {
                    int drop = random.Next(LootDrops.Count);
                    Console.SetCursorPosition(5, yPos);
                    Console.WriteLine("There was loot!! Monster dropped: " + LootDrops[drop].Name);
                    return LootDrops[drop];
                }
                else
                {
                    //Console.Clear();
                    Console.SetCursorPosition(5, yPos);
                    Console.Write("There was no loot."); //TODO: Fix Available actions when there's no loot, add here
                    Console.SetCursorPosition(5, yPos + 2);
                    Console.Write("Press any key to continue");
                    Console.SetCursorPosition(5, 35);
                    Console.Write("[Any key]");
                    //Console.Write(random.Next(LootDrops.Count));
                    Console.ReadKey();
                    Console.WriteLine("x");
                    Console.Clear();
                    return null;
                }
            }
            
        }



    }
}
