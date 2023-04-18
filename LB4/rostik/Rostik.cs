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
        
        //BlockFirst
        public int[] ArrayInputRandom()
        {
            Console.WriteLine("Введiть кiлькiсть елементiв:");
            
            int number = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[number];
            Random random = new Random();
            
            for (int i = 0; i < number; i++)
            {
                array[i] = random.Next(-100, 100);
            }
            return array;
        }
        public int[] ArrayInputSpace()
        {
            Console.WriteLine("Введiть числа через Space:");
            
            string number = Console.ReadLine();
            string[] numbers = number.Split(' ');
            int[] array = new int[numbers.Length];
            
            for (int i = 0; i < numbers.Length; i++)
            {
                array[i] = Convert.ToInt32(numbers[i]);
            }
            return array;
        }
        public void PrintFirst(int[] array)
        {
            foreach (int element in array)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }
        public void MessageInputArray()
        {
            Console.WriteLine("Як бажаєте заповнити масив?");
            Console.WriteLine("Введiть 1 для випадкового заповнення масиву:");
            Console.WriteLine("Введiть 2 для вводу вручну (через Space):");
            Console.WriteLine("Введiть 0 для виходу з програми!");
        }
        public void BlockFirst()
        {
            MessageInputArray();
            int[] array;
            int choice = Convert.ToInt32(Console.ReadLine());
            
            switch (choice)
            {
                case 0:
                    break;
                case 1:
                    array = ArrayInputRandom();
                    TaskFirst(array);
                    break;
                case 2:
                    array = ArrayInputSpace();
                    TaskFirst(array);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Команда не розпiзнана!");
                    Console.ResetColor();
                    break;
            }
        }
        public void TaskFirst(int[] array)
        {
            Console.WriteLine("Введiть номер елемента, з якого починаємо знищення:");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введiть кiлькiсть елементiв, якi треба знищити:");
            int quantity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Створений масив:");
            PrintFirst(array);
            
            if (number < array.Length && number + quantity <= array.Length)
            {
                for (int i = number + quantity; i < array.Length; i++)
                {
                    array[i - quantity] = array[i];
                }
                
                Array.Resize(ref array, array.Length - quantity);
                
                Console.WriteLine("Результат:");
                PrintFirst(array);
            }
            else
            {
                Console.WriteLine($"Неможливо знищити {quantity} елементiв, починаючи з номеру {number}!");
            }
        }
        public void PrintSecond(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write("{0,4}", array[i][j]);
                }
                Console.WriteLine();
            }
        }
        public void BlockSecond()
        {
            int[][] array = new int[100][];
            _af.Menu(array);
            TaskSecond(array);
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
            
            array[number] = array[array.Length - 1];
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