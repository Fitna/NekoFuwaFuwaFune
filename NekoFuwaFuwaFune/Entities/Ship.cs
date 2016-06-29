using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoFuwaFuwaFune.Entities
{
    public class Ship : Entity
    {
        public int CrewMax;
        public List<Neko> Crew;

        public int MaxHP;
        public int CurrentHP;
        public int FirePower;
        

        public Ship(int ID, string Name, string Description, string ImagePath, int CrewMax, List<Neko> Crew, int MaxHP, int CurrentHP,
             int FirePower) : base (ID,Name,Description,ImagePath)
        {
            this.CrewMax = CrewMax;
            this.Crew = Crew;
            this.MaxHP = MaxHP;
            this.CurrentHP = CurrentHP;
            this.FirePower = FirePower;
        }
    }
}
