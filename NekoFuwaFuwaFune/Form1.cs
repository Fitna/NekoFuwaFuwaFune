using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NekoFuwaFuwaFune
{

    enum GameState
    {
        Menu = 0,
        Skirmish,
        Exit = 100
    }

    public enum BattleActions
    {
        Attack = 1,
        Evade,
        Counter
    }

    public partial class MainForm : Form
    {

        private static GameState gs;
        public static BattleActions PBA, EBA;
        public static Boolean IsDefeat;

        public static List<Entities.Ship> PlayerShips = new List<Entities.Ship>();
        public static List<Entities.Ship> EnemyShips = new List<Entities.Ship>();

        public MainForm()
        {
            InitializeComponent();

            MainTextBox.ForeColor = Color.Black;
            MainTextBox.Font = new Font("Arial", 10);

            IsDefeat = true;

            PlayerShips.Add(Managers.ShipManager.GetShipByID(1));
            foreach (Entities.Ship s in PlayerShips)
            {
                Managers.ShipManager.CalculateStats(s);
            }
            
            EnemyShips.Add(Managers.ShipManager.GetShipByID(2));
            foreach (Entities.Ship s in EnemyShips)
            {
                Managers.ShipManager.CalculateStats(s);
            }

            while (!IsDefeat)
            {
                switch (gs)
                {
                    case GameState.Skirmish:
                        {





                            break;
                        }
                    case GameState.Menu:
                    case GameState.Exit:
                    default:
                        {
                            gs = GameState.Menu;
                            break;
                        }
                }
            }
        }
    

        private void AttackBtn_Click(object sender, EventArgs e)
        {
            PBA = BattleActions.Attack;
            Enemy();
            Decision();

            MainTextBox.SelectionStart = MainTextBox.TextLength - 1;
            MainTextBox.ScrollToCaret();
        }

        private void EvadeBtn_Click(object sender, EventArgs e)
        {
            PBA =BattleActions.Evade;
            Enemy();
            Decision();

            MainTextBox.SelectionStart = MainTextBox.TextLength - 1;
            MainTextBox.ScrollToCaret(); 
        }

        private void CounterBtn_Click(object sender, EventArgs e)
        {
            PBA = BattleActions.Counter;
            Enemy();
            Decision();

            MainTextBox.SelectionStart = MainTextBox.TextLength - 1;
            MainTextBox.ScrollToCaret();
        }

        public void Enemy()
        {
            Random r = new Random();
            switch(r.Next(3))
            {
                case (0):
                    {
                        EBA = BattleActions.Attack;
                        break;
                    }
                case (1):
                    {
                        EBA = BattleActions.Counter;
                        break;
                    }
                case (2):
                    {
                        EBA = BattleActions.Evade;
                        break;
                    }
            }
        }

        public void Decision()
        {
            Random r = new Random();
            switch (PBA)
            {
                case(BattleActions.Attack):
                    {
                        MainTextBox.AppendText("Вы решили атаковать.\n");
                        switch(EBA)
                        {
                            case (BattleActions.Attack):
                                {
                                    int dmg = 0;
                                    MainTextBox.AppendText("Ваш противник тоже решил атаковать.\n");
                                    MainTextBox.AppendText("В ходе сражения вы ");
                                    if(r.Next(100)<75)
                                    {
                                        
                                        foreach(Entities.Ship s in PlayerShips)
                                        {
                                            dmg += s.FirePower;
                                        }
                                        MainTextBox.AppendText("нанесли ");
                                        MainTextBox.SelectionColor = Color.Green;
                                        MainTextBox.AppendText(Convert.ToString(dmg));
                                        MainTextBox.SelectionColor = Color.Black;
                                        MainTextBox.AppendText(" единицы урона.\n");
                                    }
                                    else { MainTextBox.AppendText("промахнулись, оставив легкие царапины на борту вражеского судна.\n"); dmg = 0; }

                                    foreach (Entities.Ship s in EnemyShips)
                                    {
                                        
                                        s.CurrentHP=s.CurrentHP-(dmg/EnemyShips.Count() + 1);

                                    }
                                    dmg = 0;
                                    MainTextBox.AppendText("Ваш противник ");
                                    if (r.Next(100) < 75)
                                    {
                                        foreach (Entities.Ship s in EnemyShips)
                                        {
                                            dmg+= s.FirePower;
                                        }
                                        MainTextBox.AppendText("нанёс ");
                                        MainTextBox.SelectionColor = Color.Red;
                                        MainTextBox.AppendText(Convert.ToString(dmg));
                                        MainTextBox.SelectionColor = Color.Black;
                                        MainTextBox.AppendText(" единицы урона.\n");
                                    }
                                    else { MainTextBox.AppendText("промахнулся, оставив несколько вмятин на корпусе вашего судна.\n"); dmg = 0; }
                                    foreach (Entities.Ship s in PlayerShips)
                                    {
                                        s.CurrentHP = s.CurrentHP - (dmg / PlayerShips.Count() + 1);
                                    }
                                    break;
                                }
                            case (BattleActions.Evade):
                                {
                                    int dmg = 0;
                                    MainTextBox.AppendText("Ваш противник решил уклоняться от ваших атак.\n");
                                    MainTextBox.AppendText("В ходе сражения вы ");
                                    if (r.Next(100) < 45)
                                    {

                                        foreach (Entities.Ship s in PlayerShips)
                                        {
                                            dmg += s.FirePower;
                                        }
                                        MainTextBox.AppendText("нанесли ");
                                        MainTextBox.SelectionColor = Color.Green;
                                        MainTextBox.AppendText(Convert.ToString(dmg));
                                        MainTextBox.SelectionColor = Color.Black;
                                        MainTextBox.AppendText(" удиницы урона.\n");
                                    }
                                    else { MainTextBox.AppendText("промахнулись, повредив краску обшивки вражеской флотилии\n"); dmg = 0; }

                                    foreach (Entities.Ship s in EnemyShips)
                                    {
                                        s.CurrentHP = s.CurrentHP - (dmg / EnemyShips.Count() + 1);
                                    }
                                    dmg = 0;

                                    MainTextBox.AppendText("Ваш противник не мог стрелять из-за маневров.");
                                    
                                    break;
                                }
                            case (BattleActions.Counter):
                                {
                                    int dmg = 0;
                                    MainTextBox.AppendText("Ваш противник контратакует!\n");
                                    MainTextBox.AppendText("В ходе сражения вы ");
                                    if (r.Next(100) < 95)
                                    {

                                        foreach (Entities.Ship s in PlayerShips)
                                        {
                                            dmg += s.FirePower;
                                        }

                                        MainTextBox.AppendText("нанесли ");
                                        MainTextBox.SelectionColor = Color.Green;
                                        MainTextBox.AppendText(Convert.ToString(dmg));
                                        MainTextBox.SelectionColor = Color.Black;
                                        MainTextBox.AppendText(" удиницы урона.\n");
                                    }
                                    else { MainTextBox.AppendText("промахнулись, погнув несколько поручней на вражеском судне.\n"); dmg = 0; }

                                    foreach (Entities.Ship s in EnemyShips)
                                    {
                                        s.CurrentHP = s.CurrentHP -(dmg / EnemyShips.Count() + 1);
                                    }
                                    dmg = 0;
                                    MainTextBox.AppendText("В виду контратаки, противник ");
                                    if (r.Next(100) < 95)
                                    {
                                        foreach (Entities.Ship s in EnemyShips)
                                        {
                                            dmg += s.FirePower;
                                        }
                                        dmg = dmg + dmg / 5;
                                        MainTextBox.AppendText("нанёс ");
                                        MainTextBox.SelectionColor = Color.Red;
                                        MainTextBox.AppendText(Convert.ToString(dmg));
                                        MainTextBox.SelectionColor = Color.Black;
                                        MainTextBox.AppendText(" единицы урона.\n");
                                    }
                                    else { dmg = 0; MainTextBox.AppendText("промахнулся. Скажи спасибо корейскому рандому, шанс около 1%\n"); }
                                    foreach (Entities.Ship s in PlayerShips)
                                    {
                                        s.CurrentHP = s.CurrentHP - (dmg / PlayerShips.Count() + 1);
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                case (BattleActions.Evade):
                    {
                        MainTextBox.AppendText("Вы решили уклоняться.\n");
                        switch (EBA)
                        {
                            case (BattleActions.Attack):
                                {
                                    int dmg = 0;
                                    MainTextBox.AppendText("Ваш противник решил атаковать.\n");
                                    MainTextBox.AppendText("В ходе сражения вы не нанесли никакого урона, так как выполняли манёвры.\n"); 
                                    
                                    MainTextBox.AppendText("Ваш противник ");
                                    if (r.Next(100) < 45)
                                    {
                                        foreach (Entities.Ship s in EnemyShips)
                                        {
                                            dmg += s.FirePower;
                                        }
                                        MainTextBox.AppendText("нанёс ");
                                        MainTextBox.SelectionColor = Color.Red;
                                        MainTextBox.AppendText(Convert.ToString(dmg));
                                        MainTextBox.SelectionColor = Color.Black;
                                        MainTextBox.AppendText(" единицы урона.\n");
                                    }
                                    else { MainTextBox.AppendText("промахнулся, напугав снарядами членов экипажа.\n"); dmg = 0; }
                                    foreach (Entities.Ship s in PlayerShips)
                                    {
                                        s.CurrentHP = s.CurrentHP - (dmg / PlayerShips.Count() + 1);
                                    }
                                    break;
                                }
                            case (BattleActions.Evade):
                                {
                                    MainTextBox.AppendText("Ваш противник тоже решил провести маневры по уклонению от снарядов.\n");
                                    MainTextBox.AppendText("В ходе сражения вы не нанесли никакого урона, так как выполняли манёвры.\n");
                                    MainTextBox.AppendText("Ваш противник не мог стрелять из-за маневров.");
                                    MainTextBox.AppendText("Вы оба не очень умные.");
                                    break;
                                }
                            case (BattleActions.Counter):
                                {
                                    int dmg = 0;
                                    MainTextBox.AppendText("Ваш противник контратакует!\n");
                                    MainTextBox.AppendText("В ходе сражения вы не нанесли никакого урона, так как выполняли манёвры.\n");

                                    MainTextBox.AppendText("В виду контратаки, противник ");
                                    if (r.Next(100) < 20)
                                    {
                                        foreach (Entities.Ship s in EnemyShips)
                                        {
                                            dmg += s.FirePower;
                                        }
                                        MainTextBox.AppendText("нанёс ");
                                        MainTextBox.SelectionColor = Color.Red;
                                        MainTextBox.AppendText(Convert.ToString(dmg));
                                        MainTextBox.SelectionColor = Color.Black;
                                        MainTextBox.AppendText(" единицы урона.\n");
                                    }
                                    else { MainTextBox.AppendText("промахнулся, повредив любимое кресло капитана.\n"); dmg = 0; }
                                    foreach (Entities.Ship s in PlayerShips)
                                    {
                                        s.CurrentHP = s.CurrentHP - (dmg / PlayerShips.Count() + 1);
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                case (BattleActions.Counter):
                    {
                        MainTextBox.AppendText("Вы решили котратаковать.\n");
                        switch (EBA)
                        {
                            case (BattleActions.Attack):
                                {
                                    int dmg = 0;
                                    MainTextBox.AppendText("Ваш противник решил атаковать.\n");
                                    MainTextBox.AppendText("В ходе сражения вы ");
                                    if (r.Next(100) < 95)
                                    {

                                        foreach (Entities.Ship s in PlayerShips)
                                        {
                                            dmg += s.FirePower;
                                        }
                                        dmg = dmg + dmg / 5;
                                        MainTextBox.AppendText("нанесли ");
                                        MainTextBox.SelectionColor = Color.Green;
                                        MainTextBox.AppendText(Convert.ToString(dmg));
                                        MainTextBox.SelectionColor = Color.Black;
                                        MainTextBox.AppendText(" удиницы урона.\n");
                                    }
                                    else { MainTextBox.AppendText("промахнулись, разбив несколько стёкол вражеского судна.\n"); dmg = 0; }
                                    
                                    foreach (Entities.Ship s in EnemyShips)
                                    {
                                        s.CurrentHP = s.CurrentHP - (dmg / EnemyShips.Count() + 1);
                                    }
                                    dmg = 0;
                                    MainTextBox.AppendText("Ваш противник ");
                                    if (r.Next(100) < 75)
                                    {
                                        foreach (Entities.Ship s in EnemyShips)
                                        {
                                            dmg += s.FirePower;
                                        }
                                        MainTextBox.AppendText("нанёс ");
                                        MainTextBox.SelectionColor = Color.Red;
                                        MainTextBox.AppendText(Convert.ToString(dmg));
                                        MainTextBox.SelectionColor = Color.Black;
                                        MainTextBox.AppendText(" единицы урона.\n");
                                    }
                                    else { MainTextBox.AppendText("промахнулся, сбив стол с завтраком капитана.\n"); dmg = 0; }
                                    foreach (Entities.Ship s in PlayerShips)
                                    {
                                        s.CurrentHP = s.CurrentHP - (dmg / PlayerShips.Count() + 1);
                                    }
                                    break;
                                }
                            case (BattleActions.Evade):
                                {
                                    int dmg = 0;
                                    MainTextBox.AppendText("Ваш противник решил уклоняться от ваших атак.\n");
                                    MainTextBox.AppendText("В ходе сражения вы ");
                                    if (r.Next(100) < 20)
                                    {

                                        foreach (Entities.Ship s in PlayerShips)
                                        {
                                            dmg += s.FirePower;
                                        }
                                        dmg = dmg + dmg / 5;
                                        MainTextBox.AppendText("нанесли ");
                                        MainTextBox.SelectionColor = Color.Green;
                                        MainTextBox.AppendText(Convert.ToString(dmg));
                                        MainTextBox.SelectionColor = Color.Black;
                                        MainTextBox.AppendText(" удиницы урона.\n");
                                    }
                                    else { MainTextBox.AppendText("промахнулись, поцарапав обшивку вражеского судна.\n"); dmg = 0; }
                                    
                                    foreach (Entities.Ship s in EnemyShips)
                                    {
                                        s.CurrentHP = s.CurrentHP - (dmg / EnemyShips.Count() + 1);
                                    }
                                    dmg = 0;

                                    MainTextBox.AppendText("Ваш противник не мог стрелять из-за маневров.");

                                    break;
                                }
                            case (BattleActions.Counter):
                                {
                                    int dmg = 0;
                                    MainTextBox.AppendText("Ваш противник контратакует!\n");
                                    MainTextBox.AppendText("В ходе сражения вы ");
                                    if (r.Next(100) < 95)
                                    {

                                        foreach (Entities.Ship s in PlayerShips)
                                        {
                                            dmg += s.FirePower;
                                        }
                                        dmg = dmg + dmg / 5;
                                        MainTextBox.AppendText("нанесли ");
                                        MainTextBox.SelectionColor = Color.Green;
                                        MainTextBox.AppendText(Convert.ToString(dmg));
                                        MainTextBox.SelectionColor = Color.Black;
                                        MainTextBox.AppendText(" удиницы урона.\n");
                                    }
                                    else { MainTextBox.AppendText("промахнулись, соскоблив краску с вражеской флотилии.\n"); dmg = 0; }

                                    foreach (Entities.Ship s in EnemyShips)
                                    {
                                        s.CurrentHP = s.CurrentHP - (dmg / EnemyShips.Count() + 1);
                                    }
                                    dmg = 0;
                                    MainTextBox.AppendText("В виду контратаки, противник ");
                                    if (r.Next(100) < 95)
                                    {
                                        foreach (Entities.Ship s in EnemyShips)
                                        {
                                            dmg += s.FirePower;
                                        }
                                        dmg = dmg + dmg / 5;
                                        MainTextBox.AppendText("нанёс ");
                                        MainTextBox.SelectionColor = Color.Red;
                                        MainTextBox.AppendText(Convert.ToString(dmg));
                                        MainTextBox.SelectionColor = Color.Black;
                                        MainTextBox.AppendText(" единицы урона.\n");
                                    }
                                    else { dmg = 0; MainTextBox.AppendText("промахнулся, разбив любимое зеркало капитана.\n"); }
                                    foreach (Entities.Ship s in PlayerShips)
                                    {
                                        s.CurrentHP = s.CurrentHP - (dmg / PlayerShips.Count() + 1);
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                default:
                    MainTextBox.AppendText("ОПА ОПА ОШИБКА");
                    break;
            }
            MainTextBox.AppendText("\n");
            CheckWinner();
        }

        public void CheckWinner()
        {
            int php = 0;
            int mphp = 0;
            foreach(Entities.Ship s in PlayerShips)
            {
                php += s.CurrentHP;
                mphp += s.MaxHP;
            }

            int ehp = 0;
            int mehp = 0;

            foreach (Entities.Ship s in EnemyShips)
            {
                ehp += s.CurrentHP;
                mehp += s.MaxHP;
            }
            
            if (php > mphp) php = mphp;
            if (ehp > mehp) ehp = mehp;
            
            if (php<1 && ehp <1)
            {
                MainTextBox.AppendText("Неожиданно обе флотилии затонули. Ничья.");
            }
            else
            {
                if(ehp<1)
                {
                    MainTextBox.AppendText("Поздравляем! Вы потопили вражеский флот.");
                }
                else
                if(php<1)
                {
                    MainTextBox.AppendText("Какая неудача. Вас разгромили.");
                }
                else
                {
                    MainTextBox.SelectionColor = Color.Black;
                    MainTextBox.AppendText("Ваше текущее общее здоровье ");
                    MainTextBox.SelectionColor = Color.Green;
                    MainTextBox.AppendText(php + "/" + mphp+"\n");
                    MainTextBox.SelectionColor = Color.Black;
                    MainTextBox.AppendText("Текущее общее здоровье противника ");
                    MainTextBox.SelectionColor = Color.Red;
                    MainTextBox.AppendText(ehp + "/" + mehp + "\n\n");
                    MainTextBox.AppendText("------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
                    return;
                }                
            }
            AttackBtn.Enabled = false;
            EvadeBtn.Enabled = false;
            CounterBtn.Enabled = false;
            AboutEnemy.Enabled = false;
            AboutUs.Enabled = false;
        }

        private void AboutUs_Click(object sender, EventArgs e)
        {
            MainTextBox.SelectionColor = Color.Green;
            MainTextBox.AppendText("Союзный флот \n");
            MainTextBox.SelectionColor = Color.Black;
            foreach (Entities.Ship s in PlayerShips)
            {
                
                MainTextBox.AppendText("На корабле ");
                MainTextBox.SelectionColor = Color.Green;
                MainTextBox.AppendText(s.Name);
                MainTextBox.SelectionColor = Color.Black;
                MainTextBox.AppendText(".\n");
                MainTextBox.AppendText("Который описывается в древних скрижалях как:\n");
                MainTextBox.AppendText(s.Description+ "\n\n");
                MainTextBox.AppendText("Имеет следующие характеристики:\n");
                MainTextBox.AppendText("Прочность: " + s.CurrentHP + "/" + s.MaxHP+" ед.\n");
                MainTextBox.AppendText("Экипаж: " + s.Crew.Count() + "/" + s.CrewMax+" ед.\n");
                MainTextBox.AppendText("Боевая мощь: " + s.FirePower + " ед.");
                MainTextBox.AppendText("\n\n");
                MainTextBox.AppendText("Содержит следующий экипаж:\n");
                foreach (Entities.Neko n in s.Crew)
                {
                    MainTextBox.ReadOnly = false;
                    Image img = Image.FromFile(n.ImagePath);
                    Clipboard.Clear();
                    Clipboard.SetImage(img);
                    MainTextBox.Paste();
                    Clipboard.Clear();
                    MainTextBox.AppendText("\n");

                    MainTextBox.ReadOnly = true;
                    MainTextBox.SelectionColor = Color.Green;
                    MainTextBox.AppendText(n.Name+ ".\n");
                    MainTextBox.SelectionColor = Color.Black;
                    MainTextBox.AppendText(n.Description+"\n");
                    MainTextBox.AppendText("Уровень: " + n.LVL + "\n");
                    MainTextBox.AppendText("Изменение огневой мощи: " + n.FirePower + "\n");
                    MainTextBox.AppendText("Изменение структуры корабля: " + n.HP + "\n\n");
                }
                MainTextBox.AppendText("------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            }
            MainTextBox.SelectionStart = MainTextBox.TextLength - 1;
            MainTextBox.ScrollToCaret();
        }

        private void AboutEnemy_Click(object sender, EventArgs e)
        {            
            MainTextBox.SelectionColor = Color.Red;
            MainTextBox.AppendText("Вражеский флот \n");
            MainTextBox.SelectionColor = Color.Black;
            foreach (Entities.Ship s in EnemyShips)
            {
                
                MainTextBox.AppendText("На корабле ");
                MainTextBox.SelectionColor = Color.Red;
                MainTextBox.AppendText(s.Name);
                MainTextBox.SelectionColor = Color.Black;
                MainTextBox.AppendText(".\n");
                MainTextBox.AppendText("Который описывается в древних скрижалях как:\n");
                MainTextBox.AppendText(s.Description + "\n\n");
                MainTextBox.AppendText("Имеет следующие характеристики:\n");
                MainTextBox.AppendText("Прочность: " + s.CurrentHP + "/" + s.MaxHP + " ед.\n");
                MainTextBox.AppendText("Экипаж: " + s.Crew.Count() + "/" + s.CrewMax + " ед.\n");
                MainTextBox.AppendText("Боевая мощь: " + s.FirePower + " ед.");
                MainTextBox.AppendText("\n\n");
                MainTextBox.AppendText("Содержит следующий экипаж:\n");
                foreach (Entities.Neko n in s.Crew)
                {
                    MainTextBox.ReadOnly = false;
                    Image img = Image.FromFile(n.ImagePath);
                    Clipboard.Clear();
                    Clipboard.SetImage(img);
                    MainTextBox.Paste();
                    Clipboard.Clear();
                    MainTextBox.AppendText("\n");

                    MainTextBox.SelectionColor = Color.Red;
                    MainTextBox.AppendText(n.Name + ".\n");
                    MainTextBox.SelectionColor = Color.Black;
                    MainTextBox.AppendText(n.Description + "\n");
                    MainTextBox.AppendText("Уровень: " + n.LVL + "\n");
                    MainTextBox.AppendText("Изменение огневой мощи: " + n.FirePower + "\n");
                    MainTextBox.AppendText("Изменение структуры корабля: " + n.HP + "\n\n\n");
                }
                MainTextBox.AppendText("------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
            }
            MainTextBox.SelectionStart = MainTextBox.TextLength - 1;
            MainTextBox.ScrollToCaret();
        }

        public void printAboutUs()
        {
            
        }
        
    }
}
