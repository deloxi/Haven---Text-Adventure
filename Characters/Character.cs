using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haven___Text_Adventure
{
    public class Character
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int ATK { get; set; }
        public int DEF { get; set; }
        public int LVL { get; set; }
        public int EXP { get; set; }
        public int MaxHealth { get; set; }

        public bool IsAlive()
        {
            return HP > 0;
        }
    }
}
