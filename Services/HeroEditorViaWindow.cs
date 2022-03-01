using GUI_Lab04.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Lab04.Services
{
    class HeroEditorViaWindow : IHeroEditorService
    {
        public void Edit(Hero hero)
        {
            new HeroEditorWindow(hero).ShowDialog();
        }
    }
}
