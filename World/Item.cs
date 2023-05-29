using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haven___Text_Adventure
{
    public enum ItemType
    {

        Weapon,
        Armor,
        Helmet,
        Pants,
        Boots,
        Ring,
        Amulet,
        Quest1,
        Quest2,
    }

    public class Item
    {
        //public List<ItemType> questItems = new List<ItemType>();
        public string Name { get; private set; }
        public ItemType Type { get; private set; }
        public string Description { get; private set; }
        public int StatBuff { get; private set; }



        public Item(ItemType slot, string name, int statbuff, string description)
        {
            Type = slot;
            Name = name;
            StatBuff = statbuff;
            Description = description;

        }
    }
}
