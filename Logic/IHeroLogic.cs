using GUI_Lab04.Model;
using System.Collections.Generic;

namespace GUI_Lab04.Logic
{
    public interface IHeroLogic
    {
        void AddToArmy(Hero heroToAdd);
        void EditHero(Hero heroToEdit);
        void RemoveFromArmy(Hero heroToRemove);
        void SetupArmies(IList<Hero> leftArmy, IList<Hero> rightArmy);
    }
}