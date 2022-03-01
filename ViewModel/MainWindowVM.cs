using GUI_Lab04.Logic;
using GUI_Lab04.Model;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GUI_Lab04.ViewModel
{
    public class MainWindowVM : ObservableRecipient
    {
        IHeroLogic logic;
        Hero selectedHeroLeft;
        Hero selectedHeroRight;

        public ObservableCollection<Hero> armyLeft;
        public ObservableCollection<Hero> armyRight;

        public double AvgPower
        {
            get { return logic.AvgPower; }
        }

        public double AvgSpeed
        {
            get { return logic.AvgSpeed; }
        }

        public Hero SelectedFromLeft
        {
            get { return selectedHeroLeft; }
            set
            {
                SetProperty(ref selectedHeroLeft, value);
            }
        }

        public Hero SelectedFromRight
        {
            get { return selectedHeroRight; }
            set
            {
                SetProperty(ref selectedHeroRight, value);
            }
        }

        public ICommand AddToArmyCommand { get; set; }
        public ICommand RemoveFromArmyCommand { get; set; }
        public ICommand EditHeroCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowVM()
            : this(IsInDesignMode ? null : Ioc.Default.GetService<IHeroLogic>())
        {
        }

        public MainWindowVM(IHeroLogic logic)
        {
            this.logic = logic;

            armyLeft = new ObservableCollection<Hero>();
            armyRight = new ObservableCollection<Hero>();

            armyLeft.Add(new Hero() { Name = "Hero_1", Power = 1, Speed = 10, Villain = VillainEnum.Evil });
            armyLeft.Add(new Hero() { Name = "Hero_2", Power = 3, Speed = 8, Villain = VillainEnum.NotSoGood });
            armyLeft.Add(new Hero() { Name = "Hero_3", Power = 5, Speed = 6, Villain = VillainEnum.Good });
            armyLeft.Add(new Hero() { Name = "Hero_4", Power = 7, Speed = 4, Villain = VillainEnum.Good });
            armyLeft.Add(new Hero() { Name = "Hero_5", Power = 9, Speed = 2, Villain = VillainEnum.NotSoGood });
            armyLeft.Add(new Hero() { Name = "Hero_6", Power = 10, Speed = 1, Villain = VillainEnum.Evil });

            armyRight.Add(armyLeft[2].DeepCopy());
            armyRight.Add(armyLeft[5].DeepCopy());

            logic.SetupArmies(armyLeft, armyRight);

            AddToArmyCommand = new RelayCommand(() => logic.AddToArmy(SelectedFromLeft), () => SelectedFromLeft != null);
            RemoveFromArmyCommand = new RelayCommand(() => logic.RemoveFromArmy(SelectedFromRight), () => SelectedFromRight != null);
            EditHeroCommand = new RelayCommand(() => logic.EditHero(SelectedFromLeft), () => SelectedFromLeft != null);

            Messenger.Register<MainWindowVM, string, string>(this, "HeroInfo", (recipient, msg) =>
            {
                OnPropertyChanged("AvgPower");
                OnPropertyChanged("AvgSpeed");
            });
        }
    }
}
