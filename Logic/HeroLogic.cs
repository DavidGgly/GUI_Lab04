﻿using GUI_Lab04.Model;
using GUI_Lab04.Services;
using Microsoft.Toolkit.Mvvm.Messaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
        IHeroEditorService editorService;

        public double AvgPower => heroesRight.Count != 0 ? heroesRight.Average(p => p.Power) : 0;

        public double AvgSpeed => heroesRight.Count != 0 ? heroesRight.Average(s => s.Speed) : 0;

        public HeroLogic(IMessenger messenger)
        {
            this.messenger = messenger;
        }

        public HeroLogic()
        {
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
            editorService.Edit(heroToEdit);
        }

        public void Save()
        {
            string jsonLeft = JsonConvert.SerializeObject(heroesLeft);
            string jsonRight = JsonConvert.SerializeObject(heroesRight);

            File.WriteAllText("armyLeft.json", jsonLeft);
            File.WriteAllText("armyRight.json", jsonRight);
        }
    }
}
