using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoFuwaFuwaFune.Managers
{
    public static class ShipManager
    {
        private static List<Entities.Ship> ShipsPull = new List<Entities.Ship>
        {
            new Entities.Ship(1,"Неуязвимый", "+10% к моральному духу, +15% к скорострельности основных орудий, -5% к точности",
                "",
                3,
                new List<Entities.Neko> {
                    NekoManager.GetNekoByID(1),
                    NekoManager.GetNekoByID(2),
                    NekoManager.GetNekoByID(3)
                },
                50,50,10 
                ),
            new Entities.Ship(2,"Суйка", "Да падёт кара на тех, кто не любит арбузы.",
                "",
                3,
                new List<Entities.Neko> {
                    NekoManager.GetNekoByID(4),
                    NekoManager.GetNekoByID(5),
                    NekoManager.GetNekoByID(6)
                },
                50,50,10
                )

        };


        //Заменить потом глубоким копированием объекта
        public static Entities.Ship GetShipByID(int ID)
        {
            return ShipsPull.Find(x => x.ID == ID);
        }

        public static void RemoveCrewMember(Entities.Ship Ship, Entities.Neko Neko)
        {
            if (Ship.Crew.Contains(Neko))
            {
                Ship.FirePower -= Neko.FirePower;
                Ship.MaxHP -= Neko.HP;
                Ship.Crew.Remove(Neko);
            }
        }

        public static void CalculateStats(Entities.Ship Ship)
        {
            int hp = 0;
            int fp = hp;
            foreach(Entities.Neko n in Ship.Crew)
            {
                hp += n.HP;
                fp += n.FirePower;
            }

            Ship.FirePower += fp;
           // if (Ship.FirePower < 0) { Ship.FirePower = 0; }
            Ship.MaxHP += hp;
         //   if (Ship.MaxHP < 0) { Ship.MaxHP = 1; }
            Ship.CurrentHP = Ship.MaxHP;
        }


    }
}
