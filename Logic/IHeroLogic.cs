using GUI_Lab04.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Lab04.Logic
{
    interface IHeroLogic
    {
        double AVGPower { get; }
        double AVGSpeed { get; }

        void AddToHeroes(Hero hero);
        void EditHero(Hero hero);
        void RemoveHero(Hero hero);
        void SetupCollections(IList<Hero> choosableHeroes, IList<Hero> heroes);
    }
}
