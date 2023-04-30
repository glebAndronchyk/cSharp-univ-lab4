using System.Collections.Generic;
using LB4.Components;
using LB4.hlib;
using LB4.rostik;
using LB4.Structs;

namespace LB4
{
    public class App
    {
        private Rostik _rostik = new Rostik();
        private Hlib _hlib = new Hlib();

        public void Main()
        {
            Dictionary<int, MenuOptionStruct> menuOptions = new Dictionary<int, MenuOptionStruct>
            {
                { 1, new MenuOptionStruct(_rostik.InitTaskMenu, _rostik.Name, true) },
                { 2, new MenuOptionStruct(_hlib.InitTaskMenu, _hlib.Name, true) },
            };
            MenuWithPreDefinedPlaceholder menu = new MenuFactory().CreateMenuWithPreDefinedPlaceholders(menuOptions);
            menu.Init();
        }
    }
}