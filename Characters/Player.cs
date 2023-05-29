using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haven___Text_Adventure
{
    public class Player:Character
    {
        public Dictionary<Monster, int> MonsterCodex = new Dictionary<Monster, int>();
        public Dictionary<ItemType, Item> EquippedItems { get; set; }
        public Player(string name, int health, int attack, int defense)
        {
            Name = name;
            HP = health;
            ATK = attack;
            DEF = defense;
            LVL = 1;
            EXP = 0;
            MaxHealth = health;
            EquippedItems = new Dictionary<ItemType, Item>();
            MonsterCodex = new Dictionary<Monster, int>();
        }

        public void PerformAttack(Character target, int yPos)
        {
            int damage = ATK - target.DEF;
            if (damage < 0)
            {
                damage = 0;
            }
            target.HP -= damage;
            if (target.HP < 0)
            {
                target.HP = 0;
            }
            Console.SetCursorPosition(5, yPos);
            Console.Write("Player dealt " + damage + " damage to " + target.Name + "                  ");
            Console.SetCursorPosition(5, yPos+1);
            Console.Write(target.Name + " has [" + target.HP + "] health left        ");
        }

        public bool LevelUp(int yPos)
        {
            int expToLevel = 10 * LVL;
            if (EXP >= expToLevel)
            {
                LVL++;
                EXP = 0;
                MaxHealth = MaxHealth + 2;
                ATK++;
                HP = MaxHealth;

                Console.SetCursorPosition(5, yPos);
                Console.Write("Congratulations! " + Name + " reached level: " + LVL);
                Console.SetCursorPosition(5, yPos+1);
                Console.Write("Your max health increased by 2, attack increased by 1");
                Console.SetCursorPosition(5, yPos + 2);
                Console.Write("health refreshed to max: " + HP);
                return true;
            }
            return false;
        }

        public void EquipItem(Item item, int yPos)
        {
            // NEED TO MAKE A USING LIST / DICTIONARY OF ITEMS ON PLAYER FIRST DUMMY. . .
            // THEN WE CAN FIX A EQUIP WITH SWITCH CASE
            // YES
            if(item == null)
            {
                return;
            }
            else
            {
                int statChange;
                bool itemPicked = false;
                while(itemPicked == false)
                {
                    if (EquippedItems.ContainsKey(item.Type))
                    {
                        statChange = item.StatBuff - EquippedItems[item.Type].StatBuff;
                    }
                    else
                    {
                        statChange = item.StatBuff;
                    }
                    Console.SetCursorPosition(5, yPos+2);
                    if(statChange > 0)
                    {
                        Console.Write("Do you want to equip: " + item.Name + $" (stat change: +{statChange})?");
                    }
                    else
                    {
                        Console.Write("Do you want to equip: " + item.Name + $" (stat change: {statChange})?");
                    }
                    Console.SetCursorPosition(5, yPos+3);
                    Console.Write("[y]es");
                    Console.SetCursorPosition(5, yPos+4);
                    Console.Write("[n]o");
                    ConsoleKey playerInput = Console.ReadKey().Key;
                    //playerInput -= 32;

                    if (playerInput == ConsoleKey.N || playerInput == ConsoleKey.Escape) // N
                    {
                        Console.WriteLine("x");
                        Console.Clear();
                        return;
                    }
                    else if (playerInput == ConsoleKey.Y) // Y
                    {
                        Console.Clear();
                        // checking if need to unequip already equipped item
                        
                        if (EquippedItems.ContainsKey(item.Type))
                        {
                            UnEquipItem(EquippedItems[item.Type]);
                        }

                        // equipping the item
                        Console.WriteLine(" You equipped " + item.Name);
                        EquippedItems[item.Type] = item;
                        switch (item.Type)
                        {
                            case ItemType.Weapon:
                                {
                                    this.ATK += item.StatBuff;
                                    break;
                                }
                            case ItemType.Armor or ItemType.Helmet or ItemType.Pants or ItemType.Boots:
                                {
                                    this.DEF += item.StatBuff;
                                    break;
                                }
                            case ItemType.Ring or ItemType.Amulet:
                                {
                                    this.MaxHealth += item.StatBuff;
                                    break;
                                }
                        }
                        itemPicked = true;
                    }

                }
                
            }
        }
        public void UnEquipItem(Item item)
        {
            if (EquippedItems.ContainsValue(item))
            {
                Console.WriteLine("You removed " + EquippedItems[item.Type].Name);
                EquippedItems.Remove(item.Type);
            }
            switch (item.Type)
            {
                case ItemType.Weapon:
                    {
                        this.ATK -= item.StatBuff;
                        break;
                    }
                case ItemType.Armor or ItemType.Helmet or ItemType.Pants or ItemType.Boots:
                    {
                        this.DEF -= item.StatBuff;
                        break;
                    }
                case ItemType.Ring or ItemType.Amulet:
                    {
                        this.MaxHealth -= item.StatBuff;
                        break;
                    }
                default:
                    {
                        break;
                    }

                    
            }
        }

    }
}
