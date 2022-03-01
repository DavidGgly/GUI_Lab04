using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Lab04.Model
{
    public class Hero : ObservableObject
    {
        string name;
        int power;
        int speed;
        VillainEnum villain;

        public string Name { get => name; set => SetProperty(ref name, value); }
        public int Power { get => power; set => SetProperty(ref power, value); }
        public int Speed { get => speed; set => SetProperty(ref speed, value); }
        public VillainEnum Villain { get => villain; set => SetProperty(ref villain, value); }

        public Hero DeepCopy()
        {
            return new Hero
            {
                Name = this.name,
                Power = this.power,
                Speed = this.speed,
                Villain = this.villain
            };
        }
    }
}
