using GUI_Lab04.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Lab04.Logic
{
    public interface IHeroLogic
    {
        double AvgPower { get; }
        double AvgSpeed { get; }

        void AddToArmy(Hero heroToAdd);
        void EditHero(Hero heroToEdit);
        void RemoveFromArmy(Hero heroToRemove);
        void SetupArmies(IList<Hero> leftArmy, IList<Hero> rightArmy);
        void Save();
    }
}