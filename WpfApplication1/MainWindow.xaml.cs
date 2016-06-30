using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WpfApplication1
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

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static GameState gs;
        public static BattleActions PBA, EBA;
        public static Boolean IsDefeat;

        public static List<NekoFuwaFuwaFune.Entities.Ship> PlayerShips = new List<NekoFuwaFuwaFune.Entities.Ship>();
        public static List<NekoFuwaFuwaFune.Entities.Ship> EnemyShips = new List<NekoFuwaFuwaFune.Entities.Ship>();

        public MainWindow()
        {
            InitializeComponent();

            IsDefeat = true;

            PlayerShips.Add(NekoFuwaFuwaFune.Managers.ShipManager.GetShipByID(1));
            foreach (NekoFuwaFuwaFune.Entities.Ship s in PlayerShips)
            {
                NekoFuwaFuwaFune.Managers.ShipManager.CalculateStats(s);
            }

            EnemyShips.Add(NekoFuwaFuwaFune.Managers.ShipManager.GetShipByID(2));
            foreach (NekoFuwaFuwaFune.Entities.Ship s in EnemyShips)
            {
                NekoFuwaFuwaFune.Managers.ShipManager.CalculateStats(s);
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
            textBlock.Inlines.Clear();
            textBlock.Inlines.Add("<------- Можешь атаковать этих ублюдков!\n\n");
            textBlock.Inlines.Add("<------- Говно идея!\n\n");
            textBlock.Inlines.Add("<------- Ещё одна говноидея!\n");
        }

        public void Enemy()
        {
            Random r = new Random();
            switch (r.Next(3))
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
                case (BattleActions.Attack):
                    {
                        textBlock.Inlines.Add("Вы решили атаковать.\n");
                        switch (EBA)
                        {
                            case (BattleActions.Attack):
                                {
                                    int dmg = 0;
                                   textBlock.Inlines.Add("Ваш противник тоже решил атаковать.\n");
                                   textBlock.Inlines.Add("В ходе сражения вы ");
                                    if (r.Next(100) < 75)
                                    {

                                        foreach (NekoFuwaFuwaFune.Entities.Ship s in PlayerShips)
                                        {
                                            dmg += s.FirePower;
                                        }
                                       textBlock.Inlines.Add("нанесли ");
                                     
                                       textBlock.Inlines.Add(new Run(Convert.ToString(dmg)) { Foreground = Brushes.Green });
                                       
                                       textBlock.Inlines.Add(" единицы урона.\n");
                                    }
                                    else {textBlock.Inlines.Add("промахнулись, оставив легкие царапины на борту вражеского судна.\n"); dmg = 0; }

                                    foreach (NekoFuwaFuwaFune.Entities.Ship s in EnemyShips)
                                    {

                                        s.CurrentHP = s.CurrentHP - (dmg / EnemyShips.Count() + 1);

                                    }
                                    dmg = 0;
                                   textBlock.Inlines.Add("Ваш противник ");
                                    if (r.Next(100) < 75)
                                    {
                                        foreach (NekoFuwaFuwaFune.Entities.Ship s in EnemyShips)
                                        {
                                            dmg += s.FirePower;
                                        }
                                       textBlock.Inlines.Add("нанёс ");

                                        textBlock.Inlines.Add(new Run(Convert.ToString(dmg)) { Foreground = Brushes.Red });

                                        textBlock.Inlines.Add(" единицы урона.\n");
                                    }
                                    else {textBlock.Inlines.Add("промахнулся, оставив несколько вмятин на корпусе вашего судна.\n"); dmg = 0; }
                                    foreach (NekoFuwaFuwaFune.Entities.Ship s in PlayerShips)
                                    {
                                        s.CurrentHP = s.CurrentHP - (dmg / PlayerShips.Count() + 1);
                                    }
                                    break;
                                }
                            case (BattleActions.Evade):
                                {
                                    int dmg = 0;
                                   textBlock.Inlines.Add("Ваш противник решил уклоняться от ваших атак.\n");
                                   textBlock.Inlines.Add("В ходе сражения вы ");
                                    if (r.Next(100) < 45)
                                    {

                                        foreach (NekoFuwaFuwaFune.Entities.Ship s in PlayerShips)
                                        {
                                            dmg += s.FirePower;
                                        }
                                       textBlock.Inlines.Add("нанесли ");
                                        textBlock.Inlines.Add(new Run(Convert.ToString(dmg)) { Foreground = Brushes.Green });
                                        textBlock.Inlines.Add(" удиницы урона.\n");
                                    }
                                    else {textBlock.Inlines.Add("промахнулись, повредив краску обшивки вражеской флотилии\n"); dmg = 0; }

                                    foreach (NekoFuwaFuwaFune.Entities.Ship s in EnemyShips)
                                    {
                                        s.CurrentHP = s.CurrentHP - (dmg / EnemyShips.Count() + 1);
                                    }
                                    dmg = 0;

                                   textBlock.Inlines.Add("Ваш противник не мог стрелять из-за маневров.");

                                    break;
                                }
                            case (BattleActions.Counter):
                                {
                                    int dmg = 0;
                                   textBlock.Inlines.Add("Ваш противник контратакует!\n");
                                   textBlock.Inlines.Add("В ходе сражения вы ");
                                    if (r.Next(100) < 95)
                                    {

                                        foreach (NekoFuwaFuwaFune.Entities.Ship s in PlayerShips)
                                        {
                                            dmg += s.FirePower;
                                        }

                                       textBlock.Inlines.Add("нанесли ");
                                        textBlock.Inlines.Add(new Run(Convert.ToString(dmg)) { Foreground = Brushes.Red });
                                        textBlock.Inlines.Add(" удиницы урона.\n");
                                    }
                                    else {textBlock.Inlines.Add("промахнулись, погнув несколько поручней на вражеском судне.\n"); dmg = 0; }

                                    foreach (NekoFuwaFuwaFune.Entities.Ship s in EnemyShips)
                                    {
                                        s.CurrentHP = s.CurrentHP - (dmg / EnemyShips.Count() + 1);
                                    }
                                    dmg = 0;
                                   textBlock.Inlines.Add("В виду контратаки, противник ");
                                    if (r.Next(100) < 95)
                                    {
                                        foreach (NekoFuwaFuwaFune.Entities.Ship s in EnemyShips)
                                        {
                                            dmg += s.FirePower;
                                        }
                                        dmg = dmg + dmg / 5;
                                       textBlock.Inlines.Add("нанёс ");
                                        textBlock.Inlines.Add(new Run(Convert.ToString(dmg)) { Foreground = Brushes.Red });
                                        textBlock.Inlines.Add(" единицы урона.\n");
                                    }
                                    else { dmg = 0;textBlock.Inlines.Add("промахнулся. Скажи спасибо корейскому рандому, шанс около 1%\n"); }
                                    foreach (NekoFuwaFuwaFune.Entities.Ship s in PlayerShips)
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
                       textBlock.Inlines.Add("Вы решили уклоняться.\n");
                        switch (EBA)
                        {
                            case (BattleActions.Attack):
                                {
                                    int dmg = 0;
                                   textBlock.Inlines.Add("Ваш противник решил атаковать.\n");
                                   textBlock.Inlines.Add("В ходе сражения вы не нанесли никакого урона, так как выполняли манёвры.\n");

                                   textBlock.Inlines.Add("Ваш противник ");
                                    if (r.Next(100) < 45)
                                    {
                                        foreach (NekoFuwaFuwaFune.Entities.Ship s in EnemyShips)
                                        {
                                            dmg += s.FirePower;
                                        }
                                       textBlock.Inlines.Add("нанёс ");
                                        textBlock.Inlines.Add(new Run(Convert.ToString(dmg)) { Foreground = Brushes.Red });
                                        textBlock.Inlines.Add(" единицы урона.\n");
                                    }
                                    else {textBlock.Inlines.Add("промахнулся, напугав снарядами членов экипажа.\n"); dmg = 0; }
                                    foreach (NekoFuwaFuwaFune.Entities.Ship s in PlayerShips)
                                    {
                                        s.CurrentHP = s.CurrentHP - (dmg / PlayerShips.Count() + 1);
                                    }
                                    break;
                                }
                            case (BattleActions.Evade):
                                {
                                   textBlock.Inlines.Add("Ваш противник тоже решил провести маневры по уклонению от снарядов.\n");
                                   textBlock.Inlines.Add("В ходе сражения вы не нанесли никакого урона, так как выполняли манёвры.\n");
                                   textBlock.Inlines.Add("Ваш противник не мог стрелять из-за маневров.");
                                   textBlock.Inlines.Add("Вы оба не очень умные.");
                                    break;
                                }
                            case (BattleActions.Counter):
                                {
                                    int dmg = 0;
                                   textBlock.Inlines.Add("Ваш противник контратакует!\n");
                                   textBlock.Inlines.Add("В ходе сражения вы не нанесли никакого урона, так как выполняли манёвры.\n");

                                   textBlock.Inlines.Add("В виду контратаки, противник ");
                                    if (r.Next(100) < 20)
                                    {
                                        foreach (NekoFuwaFuwaFune.Entities.Ship s in EnemyShips)
                                        {
                                            dmg += s.FirePower;
                                        }
                                       textBlock.Inlines.Add("нанёс ");
                                        textBlock.Inlines.Add(new Run(Convert.ToString(dmg)) { Foreground = Brushes.Green });
                                        textBlock.Inlines.Add(" единицы урона.\n");
                                    }
                                    else {textBlock.Inlines.Add("промахнулся, повредив любимое кресло капитана.\n"); dmg = 0; }
                                    foreach (NekoFuwaFuwaFune.Entities.Ship s in PlayerShips)
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
                       textBlock.Inlines.Add("Вы решили котратаковать.\n");
                        switch (EBA)
                        {
                            case (BattleActions.Attack):
                                {
                                    int dmg = 0;
                                   textBlock.Inlines.Add("Ваш противник решил атаковать.\n");
                                   textBlock.Inlines.Add("В ходе сражения вы ");
                                    if (r.Next(100) < 95)
                                    {

                                        foreach (NekoFuwaFuwaFune.Entities.Ship s in PlayerShips)
                                        {
                                            dmg += s.FirePower;
                                        }
                                        dmg = dmg + dmg / 5;
                                       textBlock.Inlines.Add("нанесли ");
                                        textBlock.Inlines.Add(new Run(Convert.ToString(dmg)) { Foreground = Brushes.Green });
                                        textBlock.Inlines.Add(" удиницы урона.\n");
                                    }
                                    else {textBlock.Inlines.Add("промахнулись, разбив несколько стёкол вражеского судна.\n"); dmg = 0; }

                                    foreach (NekoFuwaFuwaFune.Entities.Ship s in EnemyShips)
                                    {
                                        s.CurrentHP = s.CurrentHP - (dmg / EnemyShips.Count() + 1);
                                    }
                                    dmg = 0;
                                   textBlock.Inlines.Add("Ваш противник ");
                                    if (r.Next(100) < 75)
                                    {
                                        foreach (NekoFuwaFuwaFune.Entities.Ship s in EnemyShips)
                                        {
                                            dmg += s.FirePower;
                                        }
                                       textBlock.Inlines.Add("нанёс ");
                                        textBlock.Inlines.Add(new Run(Convert.ToString(dmg)) { Foreground = Brushes.Red });
                                        textBlock.Inlines.Add(" единицы урона.\n");
                                    }
                                    else {textBlock.Inlines.Add("промахнулся, сбив стол с завтраком капитана.\n"); dmg = 0; }
                                    foreach (NekoFuwaFuwaFune.Entities.Ship s in PlayerShips)
                                    {
                                        s.CurrentHP = s.CurrentHP - (dmg / PlayerShips.Count() + 1);
                                    }
                                    break;
                                }
                            case (BattleActions.Evade):
                                {
                                    int dmg = 0;
                                   textBlock.Inlines.Add("Ваш противник решил уклоняться от ваших атак.\n");
                                   textBlock.Inlines.Add("В ходе сражения вы ");
                                    if (r.Next(100) < 20)
                                    {

                                        foreach (NekoFuwaFuwaFune.Entities.Ship s in PlayerShips)
                                        {
                                            dmg += s.FirePower;
                                        }
                                        dmg = dmg + dmg / 5;
                                       textBlock.Inlines.Add("нанесли ");
                                        textBlock.Inlines.Add(new Run(Convert.ToString(dmg)) { Foreground = Brushes.Green });
                                        textBlock.Inlines.Add(" удиницы урона.\n");
                                    }
                                    else {textBlock.Inlines.Add("промахнулись, поцарапав обшивку вражеского судна.\n"); dmg = 0; }

                                    foreach (NekoFuwaFuwaFune.Entities.Ship s in EnemyShips)
                                    {
                                        s.CurrentHP = s.CurrentHP - (dmg / EnemyShips.Count() + 1);
                                    }
                                    dmg = 0;

                                   textBlock.Inlines.Add("Ваш противник не мог стрелять из-за маневров.");

                                    break;
                                }
                            case (BattleActions.Counter):
                                {
                                    int dmg = 0;
                                   textBlock.Inlines.Add("Ваш противник контратакует!\n");
                                   textBlock.Inlines.Add("В ходе сражения вы ");
                                    if (r.Next(100) < 95)
                                    {

                                        foreach (NekoFuwaFuwaFune.Entities.Ship s in PlayerShips)
                                        {
                                            dmg += s.FirePower;
                                        }
                                        dmg = dmg + dmg / 5;
                                       textBlock.Inlines.Add("нанесли ");
                                        textBlock.Inlines.Add(new Run(Convert.ToString(dmg)) { Foreground = Brushes.Green });
                                        textBlock.Inlines.Add(" удиницы урона.\n");
                                    }
                                    else {textBlock.Inlines.Add("промахнулись, соскоблив краску с вражеской флотилии.\n"); dmg = 0; }

                                    foreach (NekoFuwaFuwaFune.Entities.Ship s in EnemyShips)
                                    {
                                        s.CurrentHP = s.CurrentHP - (dmg / EnemyShips.Count() + 1);
                                    }
                                    dmg = 0;
                                   textBlock.Inlines.Add("В виду контратаки, противник ");
                                    if (r.Next(100) < 95)
                                    {
                                        foreach (NekoFuwaFuwaFune.Entities.Ship s in EnemyShips)
                                        {
                                            dmg += s.FirePower;
                                        }
                                        dmg = dmg + dmg / 5;
                                       textBlock.Inlines.Add("нанёс ");
                                        textBlock.Inlines.Add(new Run(Convert.ToString(dmg)) { Foreground = Brushes.Red });
                                        textBlock.Inlines.Add(" единицы урона.\n");
                                    }
                                    else { dmg = 0;textBlock.Inlines.Add("промахнулся, разбив любимое зеркало капитана.\n"); }
                                    foreach (NekoFuwaFuwaFune.Entities.Ship s in PlayerShips)
                                    {
                                        s.CurrentHP = s.CurrentHP - (dmg / PlayerShips.Count() + 1);
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                default:
                   textBlock.Inlines.Add("ОПА ОПА ОШИБКА");
                    break;
            }
           textBlock.Inlines.Add("\n");
            CheckWinner();
        }

        public void CheckWinner()
        {
            int php = 0;
            int mphp = 0;
            foreach (NekoFuwaFuwaFune.Entities.Ship s in PlayerShips)
            {
                php += s.CurrentHP;
                mphp += s.MaxHP;
            }

            int ehp = 0;
            int mehp = 0;

            foreach (NekoFuwaFuwaFune.Entities.Ship s in EnemyShips)
            {
                ehp += s.CurrentHP;
                mehp += s.MaxHP;
            }

            if (php > mphp) php = mphp;
            if (ehp > mehp) ehp = mehp;

            if (php < 1 && ehp < 1)
            {
               textBlock.Inlines.Add("Неожиданно обе флотилии затонули. Ничья.");
            }
            else
            {
                if (ehp < 1)
                {
                   textBlock.Inlines.Add("Поздравляем! Вы потопили вражеский флот.");
                }
                else
                if (php < 1)
                {
                   textBlock.Inlines.Add("Какая неудача. Вас разгромили.");
                }
                else
                {
                   
                   textBlock.Inlines.Add("Ваше текущее общее здоровье ");
                    textBlock.Inlines.Add(new Run(php + "/" + mphp + "\n") { Foreground = Brushes.Green });
                   textBlock.Inlines.Add("Текущее общее здоровье противника ");
                 
                    textBlock.Inlines.Add(new Run(ehp + "/" + mehp + "\n\n") { Foreground = Brushes.Red });
                    textBlock.Inlines.Add("-----------------------------------------------------------\n");
                    return;
                }
            }
            btnAttack.IsEnabled = false;
            btnCounter.IsEnabled = false;
            btnEvade.IsEnabled = false;
            btnEnemy.IsEnabled = false;
            btnWe.IsEnabled = false;

            Button bt = new Button();
            bt.Content = " Начать заново ";
            bt.HorizontalAlignment = HorizontalAlignment.Center;
            bt.Click += (s, e) => {
                btnAttack.IsEnabled = true;
                btnCounter.IsEnabled = true;
                btnEvade.IsEnabled = true;
                btnEnemy.IsEnabled = true;
                btnWe.IsEnabled = true;
                IsDefeat = true;

                PlayerShips.Add(NekoFuwaFuwaFune.Managers.ShipManager.GetShipByID(1));
                foreach (NekoFuwaFuwaFune.Entities.Ship ss in PlayerShips)
                {
                    NekoFuwaFuwaFune.Managers.ShipManager.CalculateStats(ss);
                }

                EnemyShips.Add(NekoFuwaFuwaFune.Managers.ShipManager.GetShipByID(2));
                foreach (NekoFuwaFuwaFune.Entities.Ship ss in EnemyShips)
                {
                    NekoFuwaFuwaFune.Managers.ShipManager.CalculateStats(ss);
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
                textBlock.Inlines.Clear();
                textBlock.Inlines.Add("<------- Можешь атаковать этих ублюдков!\n\n");
                textBlock.Inlines.Add("<------- Говно идея!\n\n");
                textBlock.Inlines.Add("<------- Ещё одна говноидея!\n");
            };
            InlineUIContainer container = new InlineUIContainer(bt);
          
            textBlock.Inlines.Add("\n                                                      ");
            textBlock.Inlines.Add(container);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (!((Run)textBlock.Inlines.LastInline).Text.Contains("-") || ((Run)textBlock.Inlines.LastInline).Text.Contains("идея!"))
            {
                textBlock.Inlines.Clear();
            }
            PBA = BattleActions.Attack;
            Enemy();
            Decision();
        }

        private void btnWe_Click(object sender, RoutedEventArgs e)
        {
            scrollContainer.ScrollToTop();
            textBlock.Inlines.Clear();
            textBlock.Inlines.Add(new Run("Союзный флот \n") { Foreground = Brushes.Green });
            foreach (NekoFuwaFuwaFune.Entities.Ship s in PlayerShips)
            {

                textBlock.Inlines.Add("На корабле ");
                textBlock.Inlines.Add(new Run(s.Name) { Foreground = Brushes.Green });
                textBlock.Inlines.Add(".\n");
                textBlock.Inlines.Add("Который описывается в древних скрижалях как:\n");
                textBlock.Inlines.Add(s.Description + "\n\n");
                textBlock.Inlines.Add("Имеет следующие характеристики:\n");
                textBlock.Inlines.Add("Прочность: " + s.CurrentHP + "/" + s.MaxHP + " ед.\n");
                textBlock.Inlines.Add("Экипаж: " + s.Crew.Count() + "/" + s.CrewMax + " ед.\n");
                textBlock.Inlines.Add("Боевая мощь: " + s.FirePower + " ед.");
                textBlock.Inlines.Add("\n\n");
                textBlock.Inlines.Add("Содержит следующий экипаж:\n");
                foreach (NekoFuwaFuwaFune.Entities.Neko n in s.Crew)
                {

                    BitmapImage MyImageSource = new BitmapImage(new Uri(n.ImagePath, UriKind.Relative));
                    Image image = new Image();
                    image.Source = MyImageSource;
                    image.Height = 100;
                    image.Width = 80;
                    image.Visibility = Visibility.Visible;
                    InlineUIContainer container = new InlineUIContainer(image);

                    textBlock.Inlines.Add(container);


                    textBlock.Inlines.Add("\n");

                    textBlock.Inlines.Add(new Run(n.Name + ".\n") { Foreground = Brushes.Green });

                    textBlock.Inlines.Add(n.Description + "\n");
                    textBlock.Inlines.Add("Уровень: " + n.LVL + "\n");
                    textBlock.Inlines.Add("Изменение огневой мощи: " + n.FirePower + "\n");
                    textBlock.Inlines.Add("Изменение структуры корабля: " + n.HP + "\n\n");
                }
            }

        }

        private void btnEvade_Click(object sender, RoutedEventArgs e)
        {
            if (!((Run)textBlock.Inlines.LastInline).Text.Contains("-") || ((Run)textBlock.Inlines.LastInline).Text.Contains("идея!"))
            {
                textBlock.Inlines.Clear();
            }
            PBA = BattleActions.Evade;
            Enemy();
            Decision();
        }

        private void btnCounter_Click(object sender, RoutedEventArgs e)
        {
            if (!((Run)textBlock.Inlines.LastInline).Text.Contains("-") || ((Run)textBlock.Inlines.LastInline).Text.Contains("идея!"))
            {
                textBlock.Inlines.Clear();
            }
            PBA = BattleActions.Counter;
            Enemy();
            Decision();
        }

        private void btnEnemy_Click(object sender, RoutedEventArgs e)
        {
            scrollContainer.ScrollToTop();
            textBlock.Inlines.Clear();
            textBlock.Inlines.Add(new Run("Вражеский флот \n") { Foreground = Brushes.Red });
            foreach (NekoFuwaFuwaFune.Entities.Ship s in EnemyShips)
            {

                textBlock.Inlines.Add("На корабле ");
                textBlock.Inlines.Add(new Run(s.Name) { Foreground = Brushes.Red });
                textBlock.Inlines.Add(".\n");
                textBlock.Inlines.Add("Который описывается в древних скрижалях как:\n");
                textBlock.Inlines.Add(s.Description + "\n\n");
                textBlock.Inlines.Add("Имеет следующие характеристики:\n");
                textBlock.Inlines.Add("Прочность: " + s.CurrentHP + "/" + s.MaxHP + " ед.\n");
                textBlock.Inlines.Add("Экипаж: " + s.Crew.Count() + "/" + s.CrewMax + " ед.\n");
                textBlock.Inlines.Add("Боевая мощь: " + s.FirePower + " ед.");
                textBlock.Inlines.Add("\n\n");
                textBlock.Inlines.Add("Содержит следующий экипаж:\n");
                foreach (NekoFuwaFuwaFune.Entities.Neko n in s.Crew)
                {

                    BitmapImage MyImageSource = new BitmapImage(new Uri(n.ImagePath, UriKind.Relative));
                    Image image = new Image();
                    image.Source = MyImageSource;
                    image.Height = 100;
                    image.Width = 80;
                    image.Visibility = Visibility.Visible;
                    InlineUIContainer container = new InlineUIContainer(image);
                 
                    textBlock.Inlines.Add(container);

                    textBlock.Inlines.Add("\n");

                    textBlock.Inlines.Add(new Run(n.Name + ".\n") { Foreground = Brushes.Red });
                    textBlock.Inlines.Add(n.Description + "\n");
                    textBlock.Inlines.Add("Уровень: " + n.LVL + "\n");
                    textBlock.Inlines.Add("Изменение огневой мощи: " + n.FirePower + "\n");
                    textBlock.Inlines.Add("Изменение структуры корабля: " + n.HP + "\n\n\n");
                }
            }
        }
    }

}
