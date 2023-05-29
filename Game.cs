using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haven___Text_Adventure
{
    public class Game
    {
        // SAVING THE GAME?!?!?!
        //public Dictionary<string, Game> Games = new Dictionary<string, Game>();

        // HOW TO MAKE A MORE VARID AREA FOR MONSTERS??!
        //public Dictionary<Monster, int> MonsterMap = new Dictionary<Monster, int>();
        //public Dictionary<Monster, int> MonsterMap2 = new Dictionary<Monster, int>();

        public bool gameEnd = false;
        public List<Location> listOfLocations;
        public Location startingLocation;
        public Location currentLocation;
        public bool playerIsAlive = true;
        public List<string> statusText = new List<string>();
        public Player Hero;
        public Monster Goblin;
        public Monster CursedDragon;

        public int mainWidth = 65;
        public int mainTextWidth = 63;
        public int mainStartX = 3;
        public int mainStartY = 1;

        public int statusWidth = 25;
        public int statusTextWidth = 22;
        public int statusStartX = 71;
        public int statusStartY = 1;

        public int actionWidth = 93;
        public int actionTextWidth = 91;
        public int actionStartX = 3;
        public int actionStartY = 33;


        public int mainXOffSet = 5;
        public int mainYOffSet = 3;
        public int statusXOffSet = 73;
        public int statusYOffSet = 3;
        public int actionXOffSet = 5;
        public int actionYOffSet = 35;

        string mainText;
        //string statText;
        string actionText;

        public Game()
        {

        }

        public void SetStartColor()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        // Where all info is made and dumped for a cleaner Program.cs
        public void GenerateAllInfo()
        {
            // locations info
            listOfLocations = new List<Location>();
            Location haven = new Location("Haven", "Only safe area for this part of the west continent", true, false, 0);
            Location goblinDen = new Location("Goblin den", "A ruggard cavern area filled with filthy green goblins", true, true, 1);
            Location goblinKingTreasury = new Location("Goblin king's treasury", "A hidden treasury where a king of an old goblin army used to store valuables", false, true, 6);
            Location theDocks = new Location("The Docks", "Once upon a time a port used for merchants now run over and taken controll by ruffians and pirates", true, true, 3);
            Location doomMountain = new Location("Doom Mountain", "A large mountainous area where once you enter... you do not return", false, true, 10);

            

            listOfLocations.Add(haven);
            listOfLocations.Add(goblinDen);
            listOfLocations.Add(goblinKingTreasury);
            listOfLocations.Add(theDocks);
            listOfLocations.Add(doomMountain);
            listOfLocations.OrderBy(x => x.LevelRecommended).ToList().ForEach(x =>listOfLocations.Add(x));
            listOfLocations.RemoveRange(0, listOfLocations.Count/2);


            haven.SetNeighborLocations(goblinDen);
            haven.SetNeighborLocations(theDocks);
            goblinDen.SetNeighborLocations(goblinKingTreasury);
            doomMountain.SetNeighborLocations(theDocks);

            // player info

            Player hero = new Player("Hero", 10, 2, 1);
            Hero = hero;

            // Item info

            Item woodSword = new Item(ItemType.Weapon, "Wood Sword", 1, "a simple sword made from wood, not much better than a toy");
            Item bucket = new Item(ItemType.Helmet, "Bucket", 1, "a bucket with a few holes for vision, not optimal nor stylish but it'll work");
            Item leatherArmor = new Item(ItemType.Armor, "Leather Armor", 1, "tattered cowhide made into protection for farmers");
            Item leatherPants = new Item(ItemType.Pants, "Leather Pants", 1, "tattered cowhide made into protection for farmers");
            Item leatherBoots = new Item(ItemType.Boots, "Leather Boots", 1, "tattered cowhide made into protection for farmers");
            Item oldRing = new Item(ItemType.Ring, "Old Ring", 5, "someone's heritage long forgotten turned to rust");
            Item oldAmulet = new Item(ItemType.Amulet, "Old Amulet", 5, "someone's heritage long forgotten turned to rust");

            Item ironSword = new Item(ItemType.Weapon, "Iron Sword", 2, "a standard military sword made from simple iron, hurts if you stab someone");
            Item ironHelm = new Item(ItemType.Helmet, "Iron Helm", 2, "a standard military helm made from simple iron, blocks some pebbles perhaps?");
            Item ironArmor = new Item(ItemType.Armor, "Iron Armor", 2, "a standard military armor made from simple iron, blocks some toy arrows perhaps?");
            Item ironPants = new Item(ItemType.Pants, "Iron Pants", 2, "standard military pants made from basic iron, they're heavy... just so heavy");
            Item ironBoots = new Item(ItemType.Boots, "Iron Boots", 2, "a standard pair of military boots made from basic iron, and no they ain't shiny");
            Item fancyRing = new Item(ItemType.Ring, "Fancy Ring", 10, "some noble probably had it stolen from them");
            Item fancyAmulet = new Item(ItemType.Amulet, "Fancy Amulet", 10, "some noble probably had it stolen from them");

            Item cursedAmulet = new Item(ItemType.Amulet, "B*l*e*sed Amulet", 999, "An ancient belonging of the past hero now corrupted causing the wearer to transform into a cursed being seeking only destruction");
            Item seaChart = new Item(ItemType.Quest1, "Sea Chart", 0, "Old map describing the direction to an unknown island");
            Item mysteriousOrb = new Item(ItemType.Quest2, "Mysterious Orb", 0, "A weird orb with no function apart some weak pulsing light from within");

            // item monster drop list
            List<Item> GoblinDrops = new List<Item>
            {
                woodSword,
                leatherArmor,
                leatherPants,
                leatherBoots,
                bucket,
                oldRing,
                oldAmulet
            };
            List<Item> PirateDrops = new List<Item>
            {
                ironSword,
                ironHelm,
                ironArmor,
                ironPants,
                ironBoots,
                fancyRing,
                fancyAmulet,
                seaChart
            };
            List<Item> cursedDragonDrops = new List<Item>
            {
                cursedAmulet
            };
            List<Item> goblinPrinceDrops = new List<Item>
            {
                mysteriousOrb
            };

            // monsters info

            Monster goblin = new Monster("Goblin", 5, 3, 1, 1, 3, GoblinDrops);
            goblinDen.Monsters.Add(goblin);
            Goblin = goblin;

            Monster goblinKing = new Monster("Goblin King", 30, 11, 5, 7, 20, goblinPrinceDrops);
            goblinKingTreasury.Monsters.Add(goblinKing);

            Monster pirate = new Monster("Pirate", 15, 7, 3, 3, 10, PirateDrops);
            theDocks.Monsters.Add(pirate);

            Monster cursedDragon = new Monster("Cursed Dragon", 1000, 30, 99, 10, 100, cursedDragonDrops);
            doomMountain.Monsters.Add(cursedDragon);
            CursedDragon = cursedDragon;


            // start of game 
            //hero.EquipItem(seaChart, 0);
            //hero.EquipItem(mysteriousOrb, 0);
            startingLocation = haven;
            currentLocation = startingLocation;

            WindowSize();
            bool enterPressed = false;
            while (enterPressed == false)
            {
                DrawUI();
                MainScreenPos();

                Console.Write("You are currently in ");
                currentLocation.DifficultyColor(Hero.LVL);
                Console.Write(currentLocation.Name + ",\n");
                SetStartColor();
                Console.WriteLine("   │ " + currentLocation.Description);
                Console.WriteLine();
                Console.WriteLine("   │ adjacent locations are:");
                foreach (Location location in currentLocation.AdjacentLocations)
                {
                    Console.Write("   │ ");
                    location.DifficultyColor(Hero.LVL);
                    Console.WriteLine(location.Name);
                    SetStartColor();
                }
                Console.WriteLine();
                Console.WriteLine("   │ Press Enter to continue");

                ConsoleKey userInput = Console.ReadKey().Key;
                switch (userInput)
                {
                    case ConsoleKey.Enter:
                        enterPressed = true;
                        Console.Clear();
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("x");
                        Console.Clear();
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine("Invalid action, try again!");
                        break;
                    default:
                        Console.SetCursorPosition(0 , 0);
                        Console.WriteLine("Invalid action, try again!");
                        break;
                }
            }
            
            
        }



        // Saved & confirmed playerActions
        public void PlayerLocationAction()
        {
            // selecting location playerAction

            bool selectingArea = true;
            int playerChoice = 0;
            int LocationIndexDiff = 1;
            //bool firstEntry = true;

            while (selectingArea)
            {
                // showing current location & adjacent available locations
                /*if(firstEntry == true)
                {
                    Console.SetCursorPosition(mainXOffSet, mainYOffSet+1);
                    firstEntry = false;
                }
                else
                {
                    MainScreenPos();
                }*/
                Console.WriteLine(); // TODO: Check if you can fix the space issue
                Console.Write("     If you wanna enter ");

                currentLocation.DifficultyColor(Hero.LVL);
                Console.Write(currentLocation.Name);
                SetStartColor();
                Console.Write(" press: ");
                currentLocation.DifficultyColor(Hero.LVL);
                Console.WriteLine("[E]");
                SetStartColor();
                Console.Write("   │ If you'd like to change location for\n   │ ");
                foreach (Location location in currentLocation.AdjacentLocations)
                {
                    if (location.IsAvailable == true)
                    {
                        location.DifficultyColor(Hero.LVL);
                        playerChoice++;
                        Console.Write(location.Name + " " + "[" + playerChoice + "]" + " ");
                        SetStartColor();
                    }
                }
                Console.WriteLine();
                Console.WriteLine("   │ to return: [ESC]");
                playerChoice = 0;
                Console.WriteLine();
                StatusScreenPos();
                DrawUI();

                actionText = "[E] ";
                int i = 1;
                ActionScreenPos();
                foreach(Location location in currentLocation.AdjacentLocations)
                {
                    if (location.IsAvailable == true)
                    {
                        actionText += $"[{i}] ";
                    }
                    i++;
                }
                actionText += "[ESC]";

                DrawWrappedText(actionText, actionTextWidth, actionXOffSet, actionYOffSet);

                // user input of numerical location (1, 2, 3, 4 etc)
                int userInput = (int)(Console.ReadKey().KeyChar);
                userInput = userInput - 48;
              
                // if user enters current location
                if (userInput == 53)
                {
                    selectingArea = false;
                    Console.Clear();
                    if (currentLocation.HasEnemies == false) // should always be Haven
                    {
                        bool enterPressed = false;
                        while (enterPressed == false)
                        {
                            MainScreenPos();
                            Console.WriteLine("Welcome to the inn of Haven, have a nice rest");
                            Console.WriteLine();
                            Console.WriteLine("      OoO_Oo___OOoo____ooO_oO___");
                            Console.WriteLine("     Oo|O     ooO          oO  |");
                            Console.WriteLine("     oO|o     OOo          o   |");
                            Console.WriteLine("     oO|o     oOo              |   #######");
                            Console.WriteLine("      o|#######ooO##############|###x    x##");
                            Console.WriteLine("       |xxxxxxxOoOxxxxxxxxxxxxx|xx        xx#");
                            Console.WriteLine("       |        oo             |           x#");
                            Console.WriteLine("       |  _ _    __  __   _    |           x#");
                            Console.WriteLine("       |   |__) |__ |__  |_)   |           x#");
                            Console.WriteLine("       |   |__) |__ |__  | |   |          x#");
                            Console.WriteLine("      |                        |      x###");
                            Console.WriteLine("      |                         |   x###");
                            Console.WriteLine("      |xxxxxxxxxxxxxxxxxxxxxxxxx|xxx#");
                            Console.WriteLine("      |#########################|###");
                            Console.WriteLine("      |                         |");
                            Console.WriteLine("      |_________________________|");
                            Console.WriteLine();
                            Console.Write("     " + Hero.Name + "'s health went from " + Hero.HP);
                            Hero.HP = Hero.MaxHealth;
                            Console.WriteLine(" to " + Hero.HP);
                            Console.WriteLine();
                            Console.WriteLine("     Press enter or escape to continue");
                            StatusScreenPos();
                            ActionScreenPos();
                            actionText = "[ENTER] [ESC]";
                            DrawWrappedText(actionText, actionTextWidth, actionXOffSet, actionYOffSet);
                            DrawUI();
                            ConsoleKey userTavernInput = Console.ReadKey().Key;
                            if (userTavernInput == ConsoleKey.Enter || userTavernInput == ConsoleKey.Escape)
                            {
                                enterPressed = true;
                            }
                            else
                            {
                                Console.SetCursorPosition(0, 0);
                                Console.WriteLine("Invalid action, try again!");
                            }
                        }
                        Console.WriteLine("x");
                        Console.Clear();

                    }
                    else if (currentLocation.Name == "Doom Mountain") // END OF THE GAME RIGHT HERE
                    {
                        MainScreenPos();
                        Console.WriteLine(Hero.Name + " found the source of evil and encountered a " + currentLocation.Monsters[0].Name);
                        Console.WriteLine();
                        DrawUI();
                        StatusScreenPos();
                        Combat encounter = new Combat(Hero, currentLocation.Monsters[0], this);
                        encounter.CombatStart();
                        if (Hero.IsAlive())
                        {
                            DrawUI();
                            StatusScreenPos();

                            if (Hero.EquippedItems.ContainsKey(ItemType.Amulet) && Hero.EquippedItems[ItemType.Amulet].Name == "B*l*e*sed Amulet")
                            {
                                bool amuletReveal = false;
                                gameEnd = true;
                                int reveal = 0;
                                int xPos = 0;
                                MainScreenPos();
                                Console.Write($"You Equipped. . . B*l*e*sed Amulet. . .");
                                ActionScreenPos();
                                actionText = "[Enter]";
                                Console.Write(actionText);
                                while (amuletReveal == false)
                                {

                                    Console.ReadKey();

                                    if (reveal == 0)
                                    {
                                        xPos += 18;
                                        Console.SetCursorPosition(mainXOffSet + xPos, mainYOffSet);
                                        Console.Write("C");
                                        xPos += 2;
                                        //ActionScreenPos();
                                    }
                                    if (reveal == 1)
                                    {
                                        Console.SetCursorPosition(mainXOffSet + xPos, mainYOffSet);
                                        Console.Write("u");
                                        xPos += 2;
                                        //ActionScreenPos();
                                    }
                                    if (reveal == 2)
                                    {
                                        Console.SetCursorPosition(mainXOffSet + xPos, mainYOffSet);
                                        Console.Write("r");
                                        ActionScreenPos();
                                    }
                                    if (reveal == 3)
                                    {
                                        amuletReveal = true;
                                    }
                                    reveal++;
                                }
                                Console.Clear();
                                DrawUI();
                                StatusScreenPos();
                                MainScreenPos();
                                string endText = "As you begin transforming from the curse, you slowly lose your human shape, your voice and your mind as it all twists into a large abomination. Wings unfurl and a roar is heard . . . as a new Cursed Dragon will begin its rampage. . . The end :D";
                                DrawWrappedText(endText, mainTextWidth - 1, mainXOffSet, mainYOffSet);
                                ActionScreenPos();
                                actionText = "[Enter]";
                                Console.Write(actionText);
                                Console.ReadKey();
                            }
                            else if(CursedDragon.HasBeenKilled == true)
                            {
                                MainScreenPos();
                                string endText = "You vanquished the evil while also remaning strong, resisting the urge to equip the Amulet and made your way back to Haven. Safety increased for the common folks and you became praised as the savior for your deeds and here you lived out your life in comfort, wealth and power. . . The end :)  **You will return and be allowed to further explore or take the alternative ending**";
                                DrawWrappedText(endText, mainTextWidth - 1, mainXOffSet, mainYOffSet);
                                ActionScreenPos();
                                actionText = "[Enter]";
                                CursedDragon.HasBeenKilled = false;
                                Console.Write(actionText);
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {

                            }
                        }
                    }
                    else
                    {
                        MainScreenPos();
                        Console.WriteLine(Hero.Name + " encountered a " + currentLocation.Monsters[0].Name);
                        Console.WriteLine();
                        DrawUI();
                        StatusScreenPos();
                        Combat encounter = new Combat(Hero, currentLocation.Monsters[0], this);
                        encounter.CombatStart();
                    }
                }

                // if user wanna change location // (0 + currenlocationXXXX is incase I need buffer for entering location)
                else if (userInput > 0 && userInput <= 0 + currentLocation.AdjacentLocations.Count && currentLocation.AdjacentLocations[userInput - LocationIndexDiff].IsAvailable)
                {
                    currentLocation = currentLocation.AdjacentLocations[userInput - LocationIndexDiff];
                    Console.Clear();
                    MainScreenPos();
                    Console.Write("You have moved to: ");

                    currentLocation.DifficultyColor(Hero.LVL);
                    Console.WriteLine(currentLocation.Name + " ");
                    SetStartColor();
                    //Console.WriteLine(currentLocation.Description);
                    DrawWrappedText(currentLocation.Description, mainTextWidth, mainXOffSet, 4);
                    Console.WriteLine();
                    Console.WriteLine("     adjacent locations are:");
                    foreach (Location location in currentLocation.AdjacentLocations)
                    {
                        if (location.IsAvailable == true)
                        {
                            location.DifficultyColor(Hero.LVL);
                            Console.WriteLine("     " + location.Name);
                            SetStartColor();
                        }
                    }
                    DrawUI();
                }
                else if (userInput == -21) //if someone wants to go back to view PlayerActionList ESCAPE KEY CUTS OFF A SYMBOL ON WRITELINE NEED TO FIX OR SWAP KEY
                {
                    Console.WriteLine("x"); // failsafe for escape key
                    Console.Clear();
                    return;
                }

                // user tried an invalid option
                else
                {
                    Console.Clear();
                    DrawUI();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Invalid action, try again!");
                    MainScreenPos();
                }


            }
        }

        public void PlayerStatus() // inspecting
        {
            int posY = mainYOffSet+2;
            bool inspectingAchievements = true;
            bool goblinQuestFinished = false;

            while (inspectingAchievements)
            {
                //Console.Clear();
                //DrawUI();
                StatusScreenPos();
                ActionScreenPos();
                actionText = "[Any key]";
                Console.Write(actionText);
                Console.SetCursorPosition(mainXOffSet, posY);
                Console.Write("Monster trophies you've collected:");
                posY++;
                
                foreach(Location location in listOfLocations)
                {
                    foreach (Monster monster in location.Monsters)
                    {
                        if(monster.HasBeenKilled == true)
                        {
                            Console.SetCursorPosition(mainXOffSet, posY);
                            Console.Write($"{monster.Name} trophies: {monster.TimesBeenKilled}");
                            posY++;
                        }
                        else
                        {
                            Console.SetCursorPosition(mainXOffSet, posY);
                            Console.Write("?????");
                            posY++;
                        }
                        
                    }
                }
                posY++;
                Console.SetCursorPosition(mainXOffSet, posY);
                Console.Write("Quests:");

                if (Goblin.TimesBeenKilled >= 20)
                {
                    goblinQuestFinished = true;
                }

                if (goblinQuestFinished == false)
                {
                    
                    posY += 2;
                    Console.SetCursorPosition(mainXOffSet, posY);
                    Console.Write($"???? ???? {Goblin.TimesBeenKilled} / ??");
                    posY += 2;

                }
                else
                {
                    posY += 2;
                    Console.SetCursorPosition(mainXOffSet, posY);
                    Console.Write($"Goblin hunt completed, new location added.");
                    posY += 2;
                    listOfLocations[3].IsAvailable = true;
                }
                if (Hero.EquippedItems.ContainsKey(ItemType.Quest1))
                {
                    Console.SetCursorPosition(mainXOffSet, posY);
                    Console.Write("You came across a Sea Chart, new location added.");
                    listOfLocations[4].IsAvailable = true;
                }
                else
                {
                    Console.SetCursorPosition(mainXOffSet, posY);
                    Console.Write("Find a way across the sea to reach Doom Mountain 0 / 1");
                }



                Console.ReadKey();
                Console.WriteLine("x");
                Console.Clear();
                inspectingAchievements = false;
            }
        }

        public void MonsterCodex()
        {
            bool playerChoosing = true;
            int playerSelection = 0;
            int i = playerSelection;
            string playerSelectionVisual = "--> ";
            bool firstEntry = true;
            int infoRow = 0;

            while (playerChoosing == true)
            {
                //MainScreenPos();
                Console.WriteLine();
                foreach (Location location in listOfLocations)
                {
                    infoRow = firstEntry ? 1 : 0;
                    Console.SetCursorPosition(mainXOffSet, mainYOffSet + 2*i + infoRow);
                    if (location.IsAvailable == true && i == playerSelection)
                    {
                        Console.Write(playerSelectionVisual + location.Name);
                        Console.WriteLine(" [" + location.LevelRecommended + "]");
                        Console.WriteLine();

                    }
                    else if (location.IsAvailable == true)
                    {
                        Console.Write(location.Name);
                        Console.WriteLine(" [" + location.LevelRecommended + "]");
                        Console.WriteLine();
                    }
                    else if (location.IsAvailable == false && i == playerSelection)
                    {
                        Console.WriteLine(playerSelectionVisual + "????? [?]");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("????? [?]");
                        Console.WriteLine();
                    }
                    i++;
                }
                firstEntry = false;
                StatusScreenPos();
                ActionScreenPos();
                actionText = "[ENTER] [Up] [Down] [ESC]";
                DrawWrappedText(actionText, actionTextWidth, actionXOffSet, actionYOffSet);
                DrawUI();
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Enter:
                        if (listOfLocations[playerSelection].IsAvailable == true)
                        {
                            Console.Clear();
                            bool escapePressed = false;
                            while(escapePressed == false)
                            {
                                MainScreenPos();
                                Console.WriteLine("You're viewing information about " + listOfLocations[playerSelection].Name + ":");
                                DrawWrappedText(listOfLocations[playerSelection].Description, mainTextWidth, mainXOffSet, 4);
                                //Console.WriteLine("     " + listOfLocations[playerSelection].Description);
                                Console.WriteLine();
                                if (listOfLocations[playerSelection].Monsters.Count != 0)
                                {
                                    Console.WriteLine("     Current discovered monsters here:");
                                    Console.WriteLine();
                                    foreach (Monster monster in listOfLocations[playerSelection].Monsters)
                                    {
                                        if (monster.HasBeenKilled == true)
                                        {
                                            Console.WriteLine("     -- " + monster.Name);
                                        }
                                        else
                                        {
                                            Console.WriteLine("     ?????");
                                        }
                                    }
                                    Console.WriteLine();
                                }
                                Console.WriteLine("     Press [ESC] to go back:");
                                StatusScreenPos();
                                ActionScreenPos();
                                actionText = "[ESC]";
                                DrawWrappedText(actionText, actionTextWidth, actionXOffSet, actionYOffSet);
                                DrawUI();

                                ConsoleKey userInput = Console.ReadKey().Key;
                                if (userInput == ConsoleKey.Escape)
                                {
                                    escapePressed = true;
                                }
                                else
                                {
                                    Console.SetCursorPosition(0, 0);
                                    Console.WriteLine("Invalid action, try again!");
                                }
                            }
                            

                            Console.WriteLine("x");
                        }
                        Console.Clear();
                        break;
                    case ConsoleKey.UpArrow:
                        playerSelection--;
                        Console.Clear();
                        break;
                    case ConsoleKey.DownArrow:
                        playerSelection++;
                        Console.Clear();
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("x");
                        Console.Clear();
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid action, try again!");
                        break;

                }
                if (playerSelection < 0)
                {
                    playerSelection = 0;
                }
                else if (playerSelection > listOfLocations.Count-1)
                {
                    playerSelection = listOfLocations.Count-1;
                }
                i = 0;
                
            }
                
        }

        /*
            ActionScreenPos();
            actionText = "[T]ravel [S]tatus [C]odex";
            DrawWrappedText(actionText, actionTextWidth, actionXOffSet, actionYOffSet); 
          
         */

        public void PlayerActionsList()
        {


            MainScreenPos();
            mainText = "What action would you like to perform?\n" +
                "     Travel [T]\n" + "       \n" +
                "     Quests [Q]\n" +
                "     Codex  [C]";
            DrawWrappedText(mainText, mainTextWidth, mainXOffSet, mainYOffSet);

            StatusScreenPos();
            
            ActionScreenPos();
            actionText = "[T]ravel [Q]uests [C]odex";
            DrawWrappedText(actionText, actionTextWidth, actionXOffSet, actionYOffSet);
            
            DrawUI();
            
            /*
            Console.WriteLine("What action would you like to perform?");
            Console.WriteLine("Travel [T]");
            Console.WriteLine("Status [S]");
            Console.WriteLine("Codex  [C]");
            */

            ConsoleKey playerInput = Console.ReadKey().Key;

            switch (playerInput)
            {
                case ConsoleKey.T:
                    Console.Clear();
                    MainScreenPos();
                    Console.WriteLine("You chose to Travel");
                    DrawUI();
                    PlayerLocationAction();
                    break;
                case ConsoleKey.Q:
                    Console.Clear();
                    MainScreenPos();
                    Console.WriteLine("You chose to check your Quests");
                    DrawUI();
                    PlayerStatus();
                    break;
                case ConsoleKey.C:
                    Console.Clear();
                    MainScreenPos();
                    Console.WriteLine("You chose to browse your Codex");
                    DrawUI();
                    MonsterCodex();
                    break;
                default:
                    Console.WriteLine("x"); //failsafe for escape key
                    Console.Clear();
                    Console.WriteLine("Invalid action, try again!");
                    DrawUI();
                    break;

            }

        }

        public void GameStart() // currently being used for testing stuff only
        {
            while (Hero.HP > 0) // use case switch later with different actions??
            {
                Console.WriteLine("TESTING");
                Console.WriteLine("Hero's level is: " + Hero.LVL);
                Console.WriteLine("Hero's attack is: " + Hero.ATK);
                Console.WriteLine("Hero's defense is: " + Hero.DEF);
                Console.WriteLine("Hero's health is: " + Hero.HP);

                foreach (KeyValuePair<ItemType, Item> eqpdItems in Hero.EquippedItems)
                {
                    Console.WriteLine(eqpdItems.Key + " " + eqpdItems.Value.Name);
                }

                Console.WriteLine("TESTING");
                PlayerLocationAction();
            }
            Console.WriteLine("Game over!");
        }


        public void WindowSize() // testing stuff only
        {
            //Console.WriteLine(Console.WindowHeight);
            //Console.WriteLine(Console.WindowWidth);
            Console.SetWindowSize(100, 40);
        }

        static void DrawBox(int startX, int startY, int width, int height, string title)
        {
            // Define the box drawing characters
            char topLeftCorner = '┌';
            char topRightCorner = '┐';
            char bottomLeftCorner = '└';
            char bottomRightCorner = '┘';
            char horizontalLine = '─';
            char verticalLine = '│';

            // Save the current cursor position
            int currentLeft = Console.CursorLeft;
            int currentTop = Console.CursorTop;

            // Draw the top border of the box with the title
            Console.SetCursorPosition(startX, startY);
            Console.Write(topLeftCorner);
            for (int i = 0; i < width - 2; i++)
            {
                Console.Write(horizontalLine);
            }
            Console.Write(topRightCorner);
            Console.SetCursorPosition(startX + (width - title.Length) / 2, startY);
            Console.Write(title);

            // Draw the sides of the box
            for (int i = 0; i < height - 2; i++)
            {
                Console.SetCursorPosition(startX, Console.CursorTop + 1);
                Console.Write(verticalLine);
                Console.SetCursorPosition(startX + width - 1, Console.CursorTop);
                Console.Write(verticalLine);
            }

            // Draw the bottom border of the box
            Console.SetCursorPosition(startX, Console.CursorTop + 1);
            Console.Write(bottomLeftCorner);
            for (int i = 0; i < width - 2; i++)
            {
                Console.Write(horizontalLine);
            }
            Console.Write(bottomRightCorner);

            // Restore the cursor position
            Console.SetCursorPosition(currentLeft, currentTop);
        }

        public void DrawUI()
        {

            DrawBox(mainStartX, mainStartY, mainWidth, 30, " - Main Screen - ");

            DrawBox(statusStartX, statusStartY, statusWidth, 30, "Player Status");


            DrawBox(actionStartX, actionStartY, actionWidth, 5, "Available Actions");

        }
        private static string[] WrapText(string text, int width, string splitChar = null)
        {
            List<string> lines = new List<string>();

            while (!string.IsNullOrEmpty(text) && (splitChar == null))
            {
                // If the text is shorter than the width, add it to the list of lines and exit the loop
                if (text.Length <= width)
                {
                    lines.Add(text);
                    break;
                }

                // Otherwise, find the last space within the width and split the text there
                int spaceIndex = text.Substring(0, width).LastIndexOf(' ');
                if (spaceIndex == -1)
                {
                    // If there is no space within the width, split the text at the width
                    lines.Add(text.Substring(0, width));
                    text = text.Substring(width);
                }
                else
                {
                    // Otherwise, split the text at the last space within the width
                    lines.Add(text.Substring(0, spaceIndex));
                    text = text.Substring(spaceIndex + 1);
                }
            }
            if (splitChar != null)
            {
                string[] parts = text.Split("#");
                foreach(string part in parts)
                {
                    lines.Add(part);
                }
            }

            return lines.ToArray();
        }

        public void MainScreenPos()
        {
            Console.SetCursorPosition(mainXOffSet, mainYOffSet);
        }
        public void StatusScreenPos()
        {
            Console.SetCursorPosition(statusXOffSet, statusYOffSet);
            //string statusText = $"{Hero.Name} level: {Hero.LVL}\n \n Health = {Hero.HP} / {Hero.MaxHealth}\n Attack = {Hero.ATK}\n     Defense = {Hero.DEF}\n Experience = {Hero.EXP} / {Hero.LVL * 100}\n Equipment:\n";
            string statusText = $"{Hero.Name} level: {Hero.LVL}##Health = {Hero.HP} / {Hero.MaxHealth}#Attack = {Hero.ATK}#Defense = {Hero.DEF}#Experience = {Hero.EXP} / {Hero.LVL * 10}##──────Equipment──────##";

            

            if (Hero.EquippedItems.Count < 1)
            {
                statusText += "";
            }
            else
            {
                foreach (KeyValuePair<ItemType, Item> currentEquippedItems in Hero.EquippedItems)
                {
                    if (currentEquippedItems.Key != ItemType.Quest1 && currentEquippedItems.Key != ItemType.Quest2)
                    {
                        statusText += $"{currentEquippedItems.Value.Name}:#";
                        statusText += $"{currentEquippedItems.Value.StatBuff}";
                        switch (currentEquippedItems.Key)
                        {
                            case (ItemType.Weapon):
                                statusText += " ATK#";
                                break;
                            case (ItemType.Armor):
                            case (ItemType.Helmet):
                            case (ItemType.Pants):
                            case (ItemType.Boots):
                                statusText += " DEF#";
                                break;
                            case (ItemType.Ring):
                            case (ItemType.Amulet):
                                statusText += " HP#";
                                break;
                        }
                    }
                    
                }
            }

            DrawWrappedText(statusText, statusTextWidth, statusXOffSet, statusYOffSet, "#");

            
            Console.SetCursorPosition(statusStartX+2,statusStartY+26);
            Console.Write("────────Items────────");
            Console.SetCursorPosition(statusStartX+2, statusStartY + 27);

            if(Hero.EquippedItems.ContainsKey(ItemType.Quest1) && Hero.EquippedItems.ContainsKey(ItemType.Quest2))
            {
                Console.Write($"Sea Chart");
                Console.SetCursorPosition(statusStartX + 2, statusStartY + 28);
                Console.Write($"Mysterious Orb");
            }
            else if(Hero.EquippedItems.ContainsKey(ItemType.Quest1))
            {
                Console.Write($"Sea Chart");
            }
            else if (Hero.EquippedItems.ContainsKey(ItemType.Quest2))
            {
                Console.Write($"Mysterious Orb");
            }


        }
        public void ActionScreenPos()
        {
            Console.SetCursorPosition(actionXOffSet, actionYOffSet);
        }

        public void DrawWrappedText(string text, int textWidth, int xOffSet, int yOffSet, string splitChar = null)
        {
            string[] lines = WrapText(text, textWidth, splitChar);

            
            for (int i = 0; i < lines.Length; i++)
            {
                Console.SetCursorPosition(xOffSet, yOffSet + i);
                Console.WriteLine(lines[i]);
            }
            //Console.SetCursorPosition(0,0);
        }
    }
}