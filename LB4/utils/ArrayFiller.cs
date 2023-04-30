using System;
using System.Collections.Generic;
using LB4.Components;
using LB4.Structs;

namespace LB4.utils
{
    public class ArrayFiller
    {
        public void Menu(List<int> list, bool disableRandom = false, bool disableHand = false)
        {
            Dictionary<int, MenuOptionWithCustomPlaceholderStruct> menuOptions =
                new Dictionary<int, MenuOptionWithCustomPlaceholderStruct>
                {
                    { disableRandom ? 0 : 1, new MenuOptionWithCustomPlaceholderStruct(() => RandomArray(list), "заповнити рандомом", disableRandom) },
                    { disableRandom ? 1 : 2, new MenuOptionWithCustomPlaceholderStruct(() => FillByHands(list), "заповнити руками", disableHand) },
                };
            MenuWithCustomPlaceholder menu =
                new MenuFactory().CreateMenuWithCustomPlaceholders(menuOptions, "Як бажаєте заповнити масив?");
            menu.Init();
        }

        public void Menu(List<int[]> list, bool disableRandom = false, bool disableHand = false)
        {
            Dictionary<int, MenuOptionWithCustomPlaceholderStruct> menuOptions =
                new Dictionary<int, MenuOptionWithCustomPlaceholderStruct>
                {
                    { disableRandom ? 0 : 1, new MenuOptionWithCustomPlaceholderStruct(() => RandomArray(list), "заповнити рандомом", disableRandom) },
                    { disableRandom ? 1 : 2, new MenuOptionWithCustomPlaceholderStruct(() => FillByHands(list), "заповнити руками", disableHand) },
                };
            MenuWithCustomPlaceholder menu =
                new MenuFactory().CreateMenuWithCustomPlaceholders(menuOptions, "Як бажаєте заповнити масив?");
            menu.Init();
        }

        private void RandomArray(List<int> list)
        {
            Console.WriteLine("Введiть кiлькiсть елементiв:");
            int number = Convert.ToInt32(Console.ReadLine());

            Random random = new Random();
            for (int i = 0; i < number; i++)
            {
                list.Add(random.Next(-100, 100));
            }
        }

        private void RandomArray(List<int[]> list)
        {
            Console.Write("Введiть кiлькiсть рядкiв: ");
            int rowNumber = Convert.ToInt32(Console.ReadLine());

            Random random = new Random();
            for (int i = 0; i < rowNumber; i++)
            {
                Console.Write($"Введiть кiлькiсть елементiв у {i}-му рядку: ");
                int columnCount = Convert.ToInt32(Console.ReadLine());
                list.Add(new int[columnCount]);

                for (int j = 0; j < columnCount; j++)
                {
                    list[i][j] = random.Next(-100, 100);
                }
            }
        }

        private void FillByHands(List<int> list)
        {
            Console.WriteLine("Введiть числа через Space:");
            
            string number = Console.ReadLine();
            string[] numbers = number.Split(' ');

            for (int i = 0; i < numbers.Length; i++)
            {
                list.Add(Convert.ToInt32(numbers[i]));
            }
        }

        private void FillByHands(List<int[]> list)
        {
            Console.WriteLine("Введiть кiлькiсть рядкiв:");
            int rows = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine($"Введiть елементи {i}-го рядка, через пробіл:");
                string[] numbers = Console.ReadLine().Split(' ');
                list.Add(new int[numbers.Length]);
                
                for (int j = 0; j < numbers.Length; j++)
                {
                    list[i][j] = Convert.ToInt32(numbers[j]);
                }
            }
        }
        
        public void PrintArray(int[] array)
        {
            foreach (int element in array)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }
        
        public void PrintArray(int[][] array)
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
    }
}