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

        public ObservableCollection<Hero> ArmyLeft { get; set; }
        public ObservableCollection<Hero> ArmyRight { get; set; }

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
                (AddToArmyCommand as RelayCommand).NotifyCanExecuteChanged();
                (EditHeroCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public Hero SelectedFromRight
        {
            get { return selectedHeroRight; }
            set
            {
                SetProperty(ref selectedHeroRight, value);
                (RemoveFromArmyCommand as RelayCommand).NotifyCanExecuteChanged();
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

            ArmyLeft = new ObservableCollection<Hero>();
            ArmyRight = new ObservableCollection<Hero>();

            ArmyLeft.Add(new Hero() { Name = "Hero_1", Power = 1, Speed = 10, Villain = VillainEnum.Evil });
            ArmyLeft.Add(new Hero() { Name = "Hero_2", Power = 3, Speed = 8, Villain = VillainEnum.NotSoGood });
            ArmyLeft.Add(new Hero() { Name = "Hero_3", Power = 5, Speed = 6, Villain = VillainEnum.Good });
            ArmyLeft.Add(new Hero() { Name = "Hero_4", Power = 7, Speed = 4, Villain = VillainEnum.Good });
            ArmyLeft.Add(new Hero() { Name = "Hero_5", Power = 9, Speed = 2, Villain = VillainEnum.NotSoGood });
            ArmyLeft.Add(new Hero() { Name = "Hero_6", Power = 10, Speed = 1, Villain = VillainEnum.Evil });

            ArmyRight.Add(ArmyLeft[2].DeepCopy());
            ArmyRight.Add(ArmyLeft[4].DeepCopy());

            logic.SetupArmies(ArmyLeft, ArmyRight);

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
