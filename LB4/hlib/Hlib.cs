using System.Collections.Generic;
using LB4.Components;
using LB4.Structs;
using LB4.utils;

namespace LB4.hlib
{
    public class Hlib
    {
        public string Name = "Гліб";
        private readonly ArrayFiller _af = new ArrayFiller();
        
        public void BlockFirst()
        {
            List<int> list = new List<int>();
            _af.Menu(list);
            // TaskFirst(list.ToArray());
        }
        
        public void BlockSecond()
        {
            List<int[]> list = new List<int[]>();
            _af.Menu(list);
            // TaskSecond(list.ToArray());
        }
        
        public void InitTaskMenu()
        {
            Dictionary<int, MenuOptionStruct> menuOptions = new Dictionary<int, MenuOptionStruct>
            {
                { 1, new MenuOptionStruct(BlockFirst) },
                { 2, new MenuOptionStruct(BlockSecond) },
            };

            MenuWithPreDefinedPlaceholder menu = new MenuFactory().CreateMenuWithPreDefinedPlaceholders(menuOptions);
            menu.Init();
        }
    }
}