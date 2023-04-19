using System;
using System.Collections.Generic;
using LB4.Components;
using LB4.Structs;
using LB4.utils;

namespace LB4.rostik
{
    class Rostik
    {
        public string Name = "Ростік";
        public ArrayFiller _af = new ArrayFiller();
        
        public void BlockFirst()
        {
            List<int> list = new List<int>();
            _af.Menu(list);
            TaskFirst(list.ToArray());
        }
        public void TaskFirst(int[] array)
        {
            Console.WriteLine("Введiть номер елемента, з якого починаємо знищення:");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введiть кiлькiсть елементiв, якi треба знищити:");
            int quantity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Створений масив:");
            _af.PrintArray(array);
            
            if (number < array.Length && number + quantity <= array.Length)
            {
                for (int i = number + quantity; i < array.Length; i++)
                {
                    array[i - quantity] = array[i];
                }
                
                Array.Resize(ref array, array.Length - quantity);
                
                Console.WriteLine("Результат:");
                _af.PrintArray(array);
            }
            else
            {
                Console.WriteLine($"Неможливо знищити {quantity} елементiв, починаючи з номеру {number}!");
            }
        }
        public void BlockSecond()
        {
           List<int[]> list = new List<int[]>();
            _af.Menu(list);
            TaskSecond(list.ToArray());
        }
        public void TaskSecond(int[][] array)
        {
            Console.Write("Введiть номер рядка, який потрiбно знищити: ");
            int number = Convert.ToInt32(Console.ReadLine());
            
            if (number < 0 || number >= array.Length)
            {
                Console.WriteLine($"Рядок з номером {number} не iснує у масивi.");
                return;
            }
            
            Console.WriteLine("Створений масив:");
            _af.PrintArray(array);
            
            for (int i = number; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }
            
            Array.Resize(ref array, array.Length - 1);
            
            Console.WriteLine("Результат:");
            _af.PrintArray(array);
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