using System.Collections.Generic;
using LB4.Components;
using LB4.rostik;
using LB4.Structs;

namespace LB4
{
    public class App
    {
        private Rostik _rostik = new Rostik();

        public void Main()
        {
            Dictionary<int, MenuOptionStruct> menuOptions = new Dictionary<int, MenuOptionStruct>
            {
                { 1, new MenuOptionStruct(_rostik.InitTaskMenu, _rostik.Name, true) },
                // { 2, new MenuOptionStruct(Volodimir.InitTaskMenu, Volodimir.name, true) },
                // { 3, new MenuOptionStruct(Hlib.InitTaskMenu, Hlib.name, true) },
            };
            MenuWithPreDefinedPlaceholder menu = new MenuFactory().CreateMenuWithPreDefinedPlaceholders(menuOptions);
            menu.Init();
        }
    }
}