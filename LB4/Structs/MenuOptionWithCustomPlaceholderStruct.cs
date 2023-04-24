using System;

namespace LB4.Structs
{
    public struct MenuOptionWithCustomPlaceholderStruct
    {
        public string placeholder;
        public Action Task;
        public bool isDisabled;

        public MenuOptionWithCustomPlaceholderStruct(Action task, string placeholder, bool disable)
        {
            Task = task;
            this.placeholder = placeholder;
            isDisabled = disable;
        }
    }
}