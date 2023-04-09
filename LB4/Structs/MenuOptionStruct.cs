using System;

namespace LB4.Structs
{
    public struct MenuOptionStruct
    {
        public bool isStudent;
        public string studentName;
        public Action Task;


        public MenuOptionStruct(Action Task, string studentName = null, bool isStudent = false )
        {
            this.Task = Task;
            this.isStudent = isStudent;
            this.studentName = studentName;
        }
    }
}