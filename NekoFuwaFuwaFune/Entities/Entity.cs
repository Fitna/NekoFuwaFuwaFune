using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoFuwaFuwaFune.Entities
{
    public abstract class Entity
    {
        public int ID;
        public string Name;
        public string Description;
        public string ImagePath;

        public Entity (int ID, string Name, string Description, string ImagePath)
        {
            this.ID = ID;
            this.Name = Name;
            this.Description = Description;
            this.ImagePath = ImagePath;
        }
    }
}
