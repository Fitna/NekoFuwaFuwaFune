using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoFuwaFuwaFune.Managers
{
    public static class EffectManager
    {
        private static readonly List<Entities.Effect> EffectsPull = new List<Entities.Effect>
        {

            new Entities.Effect(0, "POTRACHENO", "Вы очнётесь в ближайшей больнице. На самом деле - нет.", 1),
            new Entities.Effect(1, "Уменьшение урона", "На этом наш урон всё.", 1),
            new Entities.Effect(2, "Увеличение урона", "Tons of damage!", 1),
            new Entities.Effect(3, "Уменьшение топлива", "Разве тут нужно описание?",1),
            new Entities.Effect(4, "Увеличение топлива", "Топливо!",1),
            new Entities.Effect(5, "Увеличение максимального здоровья", "Вы выпили кумыса",1),
            new Entities.Effect(6, "Уменьшение максимального здоровья", "Я без понятия, что произошло. Я такого не предвидел.",1),
            new Entities.Effect(7, "Увеличение здоровья", "ЩАСТИЯ, ЗДОРОВИЯ!",1),
            new Entities.Effect(8, "Уменьшение здоровья", "Я без понятия, что произошло. Я такого не предвидел.",1),
            new Entities.Effect(9, "Увеличение максимального количества экипажа", "Шведская семья.",1),
            new Entities.Effect(10, "Уменьшение максимального количества экипажа", "Ничего не придумано",1),

            new Entities.Effect(500, "Уменьшение урона", "Клешнерукая.", 1),
            new Entities.Effect(501, "Увеличение урона", "Хоспаде, мне бы такого адк!", 1),
            new Entities.Effect(502, "Уменьшение топлива", "Тырильщик топлейва.",1),
            new Entities.Effect(503, "Увеличение топлива", "Лояльный тырильщик топлейва.",1),
            new Entities.Effect(504, "Увеличение здоровья", "БОРЦУХА ВАХ!",1),
            new Entities.Effect(505, "Уменьшение здоровья", "БОЛЬНАЯ",1),
            new Entities.Effect(506, "Увеличение уровня", "Хапнули экспириенса и получили левелап",1),
            new Entities.Effect(507, "Уменьшение уровня", "НЕУМЁХА",1)

        };

        public static Entities.Effect GetEffectByID(int ID)
        {
            return EffectsPull.Find(x => x.ID == ID);
        }
    }
}
