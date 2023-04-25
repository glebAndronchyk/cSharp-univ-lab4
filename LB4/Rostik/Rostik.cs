using System;
using System.Collections.Generic;
using System.Linq;
using LB4.Components;
using LB4.Structs;
using LB4.utils;

namespace LB4.rostik
{
    class Rostik
    {
        public string Name = "Ростік";
        private readonly ArrayFiller _af = new ArrayFiller();
        
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
        public void BlockThird()
        {
            List<int[]> list = new List<int[]>();
            _af.Menu(list);
            TaskThird(list.ToArray());
        }
        private void TaskThird(int[][] arrayP)
        {
            int[][] arrayQ = new int[arrayP.Length][];
            int maxColumns = arrayP[0].Length;
            Random rand = new Random();

            for (int i = 0; i < arrayP.Length; i++)
            {
                int lastZeroIndex = -1;

                for (int j = arrayP[i].Length - 1; j >= 0; j--)
                {
                    if (arrayP[i][j] == 0)
                    {
                        lastZeroIndex = j;
                        break;
                    }
                }

                if (lastZeroIndex == -1)
                {
                    arrayQ[i] = new int[arrayP[i].Length];
                }
                else
                {
                    arrayQ[i] = new int[lastZeroIndex + 1];
                }

                for (int j = 0; j < arrayQ[i].Length; j++)
                {
                    arrayQ[i][j] = rand.Next(-100, 100);
                }

                for (int j = 1; j < arrayQ[i].Length; j++)
                {
                    int key = arrayQ[i][j];
                    int k = j - 1;

                    while (k >= 0 && arrayQ[i][k] < key)
                    {
                        arrayQ[i][k + 1] = arrayQ[i][k];
                        k--;
                    }
                    arrayQ[i][k + 1] = key;
                }

                if (arrayQ[i].Length > maxColumns)
                {
                    maxColumns = arrayQ[i].Length;
                }
            }

            int[] arrayZ = new int[arrayP.Length];

            for (int i = 0; i < arrayP.Length; i++)
            {
                arrayZ[i] = arrayQ[i].Length;
            }

            Console.WriteLine("Матриця P:");
            _af.PrintArray(arrayP);
            Console.WriteLine("Масив Z:");
            _af.PrintArray(arrayZ);
            Console.WriteLine("Матриця Q:");
            _af.PrintArray(arrayQ);
        }
        public void InitTaskMenu()
        {
            Dictionary<int, MenuOptionStruct> menuOptions = new Dictionary<int, MenuOptionStruct>
            {
                { 1, new MenuOptionStruct(BlockFirst) },
                { 2, new MenuOptionStruct(BlockSecond) },
                { 3, new MenuOptionStruct(BlockThird)}
            };

            MenuWithPreDefinedPlaceholder menu = new MenuFactory().CreateMenuWithPreDefinedPlaceholders(menuOptions);
            menu.Init();
        }
    }
}