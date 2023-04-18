using System;
using System.Collections.Generic;
using LB4.Structs;

namespace LB4.Components
{
    public class MenuWithCustomPlaceholder
    {
        private readonly Dictionary<int, MenuOptionWithCustomPlaceholderStruct> _options;
        private string _askPlaceholder;

        public MenuWithCustomPlaceholder(Dictionary<int, MenuOptionWithCustomPlaceholderStruct> options, string askPlaceholder)
        {
            _options = options;
            _askPlaceholder = askPlaceholder;
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
            Console.WriteLine(_askPlaceholder);
            foreach (var option in _options)
            {
                Console.WriteLine($"Введiть {option.Key}, щоб {option.Value.placeholder}:");
            }
            Console.WriteLine("Введiть 0 для виходу з програми!");
        }
    }
}