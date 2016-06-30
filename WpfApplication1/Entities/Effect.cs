using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoFuwaFuwaFune.Entities
{
    public class Effect
    {
        public int ID;
        public string Name;
        public string Description;
        public int Ticks;
        public Effect(int ID, string Name, string Description, int Ticks)
        {
            this.ID = ID;
            this.Name = Name;
            this.Description = Description;
            this.Ticks = Ticks;
        }
    }
}
