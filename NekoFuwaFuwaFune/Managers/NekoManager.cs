using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoFuwaFuwaFune.Managers
{
    public static class NekoManager
    {
        private static List<Entities.Neko> NekosPull = new List<Entities.Neko>
        {
            new Entities.Neko(1, @"Мэрили", @"Мэрили любит печеньки, а также уничтожать своих врагов.",
                Environment.CurrentDirectory+@"\Images\Nekos\Merili.png", 2, 2, 1),
            new Entities.Neko(2, @"Аврора Найтли", @"котается на легкам крейсере",
                Environment.CurrentDirectory+@"\Images\Nekos\Avrora_Nightly.png", 5, 1, 6),
            new Entities.Neko(3, @"Некамэ Косяро", @"Деващка из абыщнай кошащьей семьи военных, нидавняя выпускница военно-морсково ущилища.",
                Environment.CurrentDirectory+@"\Images\Nekos\Nekame_Kosyaro.png", 6, 3, 5),

            new Entities.Neko(4, @"Ремо Гинта", @"Казалось бы, причем тут Суи.",
                Environment.CurrentDirectory+@"\Images\Nekos\Remo_Ginta.png", 6, 3, 5),
            new Entities.Neko(5, @"Ремо_чка", @"Ярая феминистка.",
                Environment.CurrentDirectory+@"\Images\Nekos\Remochka.png", 6, 3, 5),
            new Entities.Neko(6, @"Капитай Суйка", @"Любит арбузы.",
                Environment.CurrentDirectory+@"\Images\Nekos\Captain_Suika.png", 6, 3, 5),
        };

        public static Entities.Neko GetNekoByID(int ID)
        {
            return NekosPull.Find(x => x.ID == ID);
        }

        public static void LVLUPNeko(Entities.Neko Neko)
        {
            Random rnd = new Random();
            Neko.LVL++;
            Neko.HP += rnd.Next(-(Neko.HP / 10) - 1, Neko.HP / 10 + 1);
            Neko.FirePower += rnd.Next(-(Neko.FirePower / 10) - 1, Neko.FirePower / 10 + 1);
        }

        public static void CalculateNeko(Entities.Neko Neko)
        {
        }
    }
}
