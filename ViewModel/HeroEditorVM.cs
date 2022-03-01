using GUI_Lab04.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Lab04.ViewModel
{
    class HeroEditorVM
    {
        public Hero Actual { get; set; }
        public void Setup(Hero hero)
        {
            this.Actual = hero;
        }

        public HeroEditorVM()
        {

        }
    }
}
