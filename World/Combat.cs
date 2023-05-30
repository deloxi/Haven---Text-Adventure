using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haven___Text_Adventure
{
    public  class Combat
    {
        public Player combatPlayer;
        public Monster combatMonster;
        public Game combatGame;
        public int combatYPos = 5;

        public Combat(Player player, Monster monster, Game game)
        {
            combatPlayer = player;
            combatMonster = monster;
            combatGame = game;
        }

        public void CombatStart()
        {
            // if encounter = final boss
            if(combatMonster.Name == "Cursed Dragon")
            {
                if (combatPlayer.EquippedItems.ContainsKey(ItemType.Quest2))
                {
                    combatMonster.HP = 100;
                    combatMonster.DEF = 7;
                    combatMonster.ATK = 11;
                    Console.SetCursorPosition(combatGame.mainXOffSet, combatGame.mainYOffSet+2);
                    Console.Write($"A pulse originates from the Mysterious Orb you picked up");
                    Console.SetCursorPosition(combatGame.mainXOffSet, combatGame.mainYOffSet + 3);
                    Console.Write("The dragon shrieks and seems weakened. . .");
                }
            }
            combatGame.ActionScreenPos();
                Console.Write("[Enter] for Attack [Escape] for well... escaping");
            while(combatPlayer.IsAlive() && combatMonster.IsAlive())
            {
                

                ConsoleKey playerInput = Console.ReadKey().Key;

                switch (playerInput)
                {
                    case ConsoleKey.Enter:
                        combatGame.MainScreenPos();
                        Console.WriteLine();
                        PlayerTurn(combatYPos);
                        combatYPos += 3;
                        MonsterTurn(combatYPos);
                        combatYPos -= 3;
                        break;
                    case ConsoleKey.Escape:
                        combatMonster.HP = combatMonster.MaxHealth;
                        Console.WriteLine("x");
                        Console.Clear();
                        return;
                    default:
                        Console.SetCursorPosition(0, 0);
                        Console.Write("Invalid action, try again!");
                        break;
                        
                }

                //Console.ReadKey();
                
            }
            ResolveCombat();
        }

        public void ResolveCombat()
        {
            if (combatPlayer.IsAlive())
            {
                combatYPos += 6;
                Console.SetCursorPosition(5, combatYPos);
                Console.Write(combatPlayer.Name + " won the fight!");
                combatMonster.HasBeenKilled = true;
                combatMonster.TimesBeenKilled++;
                combatMonster.HP = combatMonster.MaxHealth;
                combatPlayer.EXP = combatPlayer.EXP + combatMonster.EXP;
                Console.SetCursorPosition(5, combatYPos+1);
                Console.Write("Press any key to continue");
                combatGame.ActionScreenPos();
                string actionText = "[Any key]                                                                ";
                combatGame.DrawWrappedText(actionText, combatGame.actionTextWidth, combatGame.actionXOffSet, combatGame.actionYOffSet);
                Console.ReadKey();
                Console.WriteLine("x");
                Console.Clear();
                combatYPos = 3;
                combatGame.DrawUI();
                combatGame.StatusScreenPos();
                Console.SetCursorPosition(5, combatYPos);
                Console.Write(combatPlayer.Name + " received " + combatMonster.EXP + " experience");
                combatYPos++;

                if (combatPlayer.LevelUp(combatYPos))
                {
                    combatYPos += 4;
                }
                combatGame.ActionScreenPos();
                actionText = "[y] [n / escape]";
                combatGame.DrawWrappedText(actionText, combatGame.actionTextWidth, combatGame.actionXOffSet, combatGame.actionYOffSet);
                combatPlayer.EquipItem(combatMonster.ObtainLoot(combatYPos), combatYPos);
                Console.Clear();
            }
            else
            {
                combatYPos += 6;
                Console.SetCursorPosition(5, combatYPos);
                Console.Write(combatPlayer.Name + " Lost the fight and died");
                Console.ReadKey();
                Console.WriteLine("x");
                Console.Clear();
                combatGame.MainScreenPos();
            }
        }

        private void MonsterTurn(int yPos)
        {
            
                combatMonster.PerformAttack(combatPlayer, yPos);
            
        }
        private void PlayerTurn(int yPos)
        {
            combatPlayer.PerformAttack(combatMonster, yPos);
        }


    }
}
