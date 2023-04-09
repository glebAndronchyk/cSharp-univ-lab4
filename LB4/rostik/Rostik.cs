using System;
using System.Collections.Generic;
using LB4.Components;
using LB4.Structs;

namespace LB4.rostik
{
    class Rostik
    {
        public static string name = "Ростік";
        
        //BlockFirst
        static int[] ArrayInputRandom()
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
        static int[] ArrayInputSpace()
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
        static void PrintFirst(int[] array)
        {
            foreach (int element in array)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }
        static void MessageInputArray()
        {
            Console.WriteLine("Як бажаєте заповнити масив?");
            Console.WriteLine("Введiть 1 для випадкового заповнення масиву:");
            Console.WriteLine("Введiть 2 для вводу вручну (через Space):");
            Console.WriteLine("Введiть 0 для виходу з програми!");
        }
        static void BlockFirst()
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
        static void TaskFirst(int[] array)
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
        //BlockSecond
        static int[][] ArrayRandom()
        {
            Console.Write("Введiть кiлькiсть рядкiв: ");
            int rowNumber = Convert.ToInt32(Console.ReadLine());
            int[][] array = new int[rowNumber][];
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"Введiть кiлькiсть елементiв у {i}-му рядку: ");
                int columnCount = Convert.ToInt32(Console.ReadLine());
                array[i] = new int[columnCount];

                for (int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = random.Next(-100, 100);
                }
            }
            return array;
        }
        static int[][] ArraySpace()
        {
            Console.WriteLine("Введiть кiлькiсть рядкiв:");
            int rows = Convert.ToInt32(Console.ReadLine());
            int[][] array = new int[rows][];
            
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine($"Введiть елементи {i}-го рядка, через пробіл:");
                string[] numbers = Console.ReadLine().Split(' ');
                array[i] = new int[numbers.Length];
                
                for (int j = 0; j < numbers.Length; j++)
                {
                    array[i][j] = Convert.ToInt32(numbers[j]);
                }
            }
            return array;
        }
        static void PrintSecond(int[][] array)
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
        static void BlockSecond()
        {
            MessageInputArray();
            int[][] array;
            int choice = Convert.ToInt32(Console.ReadLine());
            
            switch (choice)
            {
                case 0:
                    break;
                case 1:
                    array = ArrayRandom();
                    TaskSecond(array);
                    break;
                case 2:
                    array = ArraySpace();
                    TaskSecond(array);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Команда не розпiзнана!");
                    Console.ResetColor();
                    break;
            }
        }
        static void TaskSecond(int[][] array)
        {
            Console.Write("Введiть номер рядка, який потрiбно знищити: ");
            int number = Convert.ToInt32(Console.ReadLine());
            
            if (number < 0 || number >= array.Length)
            {
                Console.WriteLine($"Рядок з номером {number} не iснує у масивi.");
                return;
            }
            
            Console.WriteLine("Створений масив:");
            PrintSecond(array);
            
            array[number] = array[array.Length - 1];
            Array.Resize(ref array, array.Length - 1);
            
            Console.WriteLine("Результат:");
            PrintSecond(array);
            
        }
        public static void InitTaskMenu()
        {
            Dictionary<int, MenuOptionStruct> menuOptions = new Dictionary<int, MenuOptionStruct>
            {
                { 1, new MenuOptionStruct(BlockFirst) },
                { 2, new MenuOptionStruct(BlockSecond) },
            };

            Menu menu = new Menu(menuOptions);
            menu.Init();
        }
    }
}