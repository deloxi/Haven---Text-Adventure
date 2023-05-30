using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haven___Text_Adventure
{
    public class Location
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public bool HasEnemies { get; set; }
        public int LevelRecommended { get; set; }
        public List<Location> AdjacentLocations { get; set; }
        public List<Monster> Monsters { get; set; }

        public Location(string name, string description, bool isAvailable, bool hasEnemies, int levelRecommended)
        {
            Name = name;
            Description = description;
            IsAvailable = isAvailable;
            HasEnemies = hasEnemies;
            LevelRecommended = levelRecommended;
            AdjacentLocations = new List<Location>();
            Monsters = new List<Monster>();
        }

        public void SetNeighborLocations(Location location)
            {
            this.AdjacentLocations.Add(location);
            location.AdjacentLocations.Add(this);
            }

        // visual danger color for the player
        public void DifficultyColor(int playerLevel)
        {

            if (LevelRecommended == 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (LevelRecommended <= playerLevel)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
        }
    }
}
