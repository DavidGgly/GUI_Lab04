using GUI_Lab04.Model;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GUI_Lab04.Logic
{
    public class HeroLogic : IHeroLogic
    {
        IList<Hero> heroesLeft;
        IList<Hero> heroesRight;
        IMessenger messenger;

        public HeroLogic(IMessenger messenger)
        {
            this.messenger = messenger;
        }

        public void SetupArmies(IList<Hero> leftArmy, IList<Hero> rightArmy)
        {
            this.heroesLeft = leftArmy;
            this.heroesRight = rightArmy;
        }

        public void AddToArmy(Hero heroToAdd)
        {
            if (heroToAdd != null)
            {
                heroesRight.Add(heroToAdd);
            }
        }

        public void RemoveFromArmy(Hero heroToRemove)
        {
            if (heroToRemove != null)
            {
                heroesRight.Remove(heroToRemove);
            }
        }

        public void EditHero(Hero heroToEdit)
        {

        }
    }
}
