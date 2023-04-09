using System;
using System.Collections.Generic;
using LB4.Structs;

namespace LB4.Components
{
    public class Menu
    {
        private readonly Dictionary<int, MenuOptionStruct> _options;

        public Menu(Dictionary<int, MenuOptionStruct> options)
        {
            _options = options;
        }

        public void Init()
        {
            AskUser();
            int inputChoice;

            do
            {
                inputChoice = int.Parse(Console.ReadLine());

                if (inputChoice == 0) return;
                
                if (!_options.ContainsKey(inputChoice))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Команда не розпiзнана!");
                    Console.ResetColor();
                    continue;
                }

                _options[inputChoice].Task();
                return;
            } while (inputChoice != 0);
        }

        private void AskUser()
        {
            Console.WriteLine("Оберіть:");
            foreach (var option in _options)
            {
                string studentText = $"студента {option.Value.studentName}";
                string taskName = option.Value.Task.Method.Name;
                string placeholder = option.Value.isStudent ? studentText : taskName;
                Console.WriteLine($"Введiть {option.Key}, щоб вибрати {placeholder}:");
            }
            Console.WriteLine("Введiть 0 для виходу з програми!");
        }
    }
}