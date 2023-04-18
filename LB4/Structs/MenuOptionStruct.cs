using System;

namespace LB4.Structs
{
    public struct MenuOptionStruct
    {
        public bool isStudent;
        public string studentName;
        public Action Task;


        public MenuOptionStruct(Action task, string studentName = null, bool isStudent = false )
        {
            Task = task;
            this.isStudent = isStudent;
            this.studentName = studentName;
        }
    }
}