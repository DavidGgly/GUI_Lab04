using GUI_Lab04.Logic;
using GUI_Lab04.Model;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Lab04.ViewModel
{
    public class MainWindowVM : ObservableRecipient
    {
        IHeroLogic logic;
        Hero selectedHeroLeft;
        Hero selectedHeroRight;

        public ObservableCollection<Hero> armyLeft;
        public ObservableCollection<Hero> armyRight;

        public MainWindowVM(IHeroLogic logic)
        {
            this.logic = logic;
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
    }
}
