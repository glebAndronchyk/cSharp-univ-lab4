using System;
using System.Collections.Generic;
using LB4.Structs;

namespace LB4.Components
{
    interface IMenuFactory
    {
        MenuWithPreDefinedPlaceholder CreateMenuWithPreDefinedPlaceholders(Dictionary<int, MenuOptionStruct> options);
        MenuWithCustomPlaceholder CreateMenuWithCustomPlaceholders(Dictionary<int, MenuOptionWithCustomPlaceholderStruct> options, string askPlaceholder);
    }

    public class MenuFactory : IMenuFactory
    {
        public MenuWithPreDefinedPlaceholder CreateMenuWithPreDefinedPlaceholders(Dictionary<int, MenuOptionStruct> options)
        {
            return new MenuWithPreDefinedPlaceholder(options);
        }

        public MenuWithCustomPlaceholder CreateMenuWithCustomPlaceholders(Dictionary<int, MenuOptionWithCustomPlaceholderStruct> options, string askPlaceholder)
        {
            return new MenuWithCustomPlaceholder(options, askPlaceholder);
        }
    }
}