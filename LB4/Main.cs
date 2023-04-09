using System;
using LB4.Components;
using LB4.rostik;
using System.Collections.Generic;
using LB4.Structs;

namespace LB4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("LAB4");
            Dictionary<int, MenuOptionStruct> menuOptions = new Dictionary<int, MenuOptionStruct>
            {
                { 1, new MenuOptionStruct(Rostik.InitTaskMenu, Rostik.name, true) },
            };
            Menu menu = new Menu(menuOptions);
            menu.Init();
        }
    }
}