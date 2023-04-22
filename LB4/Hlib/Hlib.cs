using System;
using System.Collections.Generic;
using LB4.Components;
using LB4.Structs;
using LB4.utils;

namespace LB4.hlib
{
    public class Hlib
    {
        public string Name = "Гліб";
        private readonly ArrayFiller _af = new ArrayFiller();
        
        public void BlockFirst()
        {
            List<int> list = new List<int>();
            _af.Menu(list);
            TaskFirst(list.ToArray());
        }

        private void TaskFirst(int[] array)
        {
            Console.WriteLine("Створений масив:");
            _af.PrintArray(array);

            int writeIndex = 0;
            for (int readIndex = 0; readIndex < array.Length; readIndex += 2)
            {
                array[writeIndex] = array[readIndex];
                writeIndex++;
            }

            Array.Resize(ref array, writeIndex);

            Console.WriteLine("Результат:");
            _af.PrintArray(array);
            Console.WriteLine($"Фінальна довжина {array.Length}");
        }

        public void BlockSecond()
        {
            List<int[]> list = new List<int[]>();
            _af.Menu(list);
            TaskSecond(list.ToArray());
        }
        
        private void TaskSecond(int[][] array)
        {
            Console.WriteLine("Створений масив:");
            _af.PrintArray(array);

            int newRowsCount = 0;
            for (int i = 0; i < array.Length; i++)
            {
                bool hasZero = false;
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] == 0)
                    {
                        hasZero = true;
                        break;
                    }
                }
                
                if (!hasZero)
                {
                    array[newRowsCount] = array[i];
                    newRowsCount++;
                }
            }
            
            Array.Resize(ref array, newRowsCount);
            
            Console.WriteLine("Результат:");
            _af.PrintArray(array);
            Console.WriteLine($"Фінальна довжина {array.Length}");
        }
        
        public void BlockThird()
        {
            List<int> list = new List<int>();
            _af.Menu(list, true);
            TaskThird(list.ToArray());
        }
        
        private void TaskThird(int[] array)
        {
            int resultLength = 0;
            int maxCol = Int32.MinValue;
            for (int i = 0; i < array.Length; i += array[i] + 1)
            {
                if (array[i] > maxCol) maxCol = array[i];
                resultLength++;
            }

            int[][] resultArray = new int[resultLength][];
            int counter = 0;
            
            for (int i = 0; i < array.Length; i += array[i] + 1)
            {
                resultArray[counter] = new int[maxCol];

                for (int j = i + 1; j <= array[i] + i; j++)
                {
                    resultArray[counter][j - (i + 1)] = array[j];
                }

                counter++;
            }
            
            Console.WriteLine("Результат:");
            _af.PrintArray(resultArray);
            Console.WriteLine("Відсортований масив:");
            Array.Sort(array);
            _af.PrintArray(array);
        }
        
        public void InitTaskMenu()
        {
            Dictionary<int, MenuOptionStruct> menuOptions = new Dictionary<int, MenuOptionStruct>
            {
                { 1, new MenuOptionStruct(BlockFirst) },
                { 2, new MenuOptionStruct(BlockSecond) },
                { 3, new MenuOptionStruct(BlockThird) },
            };

            MenuWithPreDefinedPlaceholder menu = new MenuFactory().CreateMenuWithPreDefinedPlaceholders(menuOptions);
            menu.Init();
        }
    }
}