using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoFuwaFuwaFune.Entities
{
    public class Neko : Entity
    {        
        public int LVL;
        public int HP;
        public int FirePower;

        public Neko(int ID, string Name, string Description, string ImagePath, int LVL, 
            int HP, int FirePower) : base (ID, Name, Description, ImagePath)
        {
            this.LVL = LVL;
            this.HP = HP;
            this.FirePower = FirePower;
        }
    }
}
