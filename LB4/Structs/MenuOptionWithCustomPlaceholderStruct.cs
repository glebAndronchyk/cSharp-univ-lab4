using System;

namespace LB4.Structs
{
    public struct MenuOptionWithCustomPlaceholderStruct
    {
        public string placeholder;
        public Action Task;

        public MenuOptionWithCustomPlaceholderStruct(Action task, string placeholder)
        {
            Task = task;
            this.placeholder = placeholder;
        }
    }
}