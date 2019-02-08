using System;
using System.Collections.Generic;

namespace lab2_guesser {
    class Program {
        static void Main(string[] args) {
            string[] gjPhrases = new string[] {
                " мне сказали передать Вам, что Вы молодец. Угадывайте дальше.",
                " мимо, продолжаем. ",
                " я, конечно, ни на что не намекаю, но Вы не угадали.",
                " долго ещё гадать будем? Снова неверно.",
                " :) намёк поняли? Гадайте дальше.",
                " это было близко, но число Вы так и не угадали.",
                " мдеее, ну Вы, конечно, мдааааа. Ещё угадывайте."
            };
            List<Attempt> attempts = new List<Attempt>();
            
            Console.WriteLine("Приветствую! Я - программа для игры в \"угадайку\". Как Вас зовут?");
            Console.Write("Введите своё имя: ");
            string playerName = Console.ReadLine();

            Random rand = new Random();
            int target = rand.Next(0, 50);
            
            Console.WriteLine($"{playerName}, я загадала число от 0 до 50. Сможете угадать?");

            int number = -1;
            int tryAmount = 0;
            DateTime startTime = DateTime.Now;

            do {
                Console.Write("Ваш вариант: ");
                string line = Console.ReadLine();
                if (line.Equals("q")) {
                    Console.WriteLine("Вы нажали q, значит я должна извиниться и закрыться. Извинияюсь и закрываюсь.");
                    Environment.Exit(1);
                }

                try {
                    number = Int32.Parse(line);
                    if (number < 0 || number > 50) {
                        throw new FormatException();
                    }
                }
                catch (FormatException ex) {
                    Console.WriteLine("ОШИБКА: неверное значение аргумента; допустимы числа в диапозоне [0,50] и буква q");
                    continue;
                }

                if (number != target) {
                    string difference = (number > target) ? "больше" : "меньше";
                    attempts.Add(new Attempt(number, difference));
                    tryAmount++;
                    Console.WriteLine(
                        $"Вы не угадали, Ваше число {difference} загаданного, продолжайте угадывать.");
                    if (tryAmount % 4 == 0) {
                        string phrase = gjPhrases[rand.Next(0, gjPhrases.Length)];
                        Console.WriteLine($"{playerName},{phrase}");
                    }
                }
            } while (number != target);
            
            DateTime stopTime = DateTime.Now;
                                
            Console.WriteLine("Вы угадали число, поздравляю!");
            Console.WriteLine($"Количество совершённых попыток: {tryAmount}");
            if (attempts.Count > 0) {
                Console.WriteLine("История попыток:");
                foreach (var attempt in attempts) {
                    Console.WriteLine($"{attempt.Number}: {attempt.Diff}");
                }
            }
            else {
                Console.WriteLine("Вы угадали с первого раза, Вы везунчик!");
            }

            TimeSpan interval = stopTime - startTime;
            Console.WriteLine(
                $"Вам потребовалось для угадывания {interval.Hours} часов {interval.Minutes} минут {interval.Seconds} секунд");
            Environment.Exit(0);
        }
    }

    class Attempt {
        private int number;
        private string diff;

        public Attempt(int n, string d) {
            number = n;
            diff = d;
        }

        public int Number {
            get { return number; }
            set { number = value; }
        }

        public string Diff {
            get { return diff; }
            set { diff = value; }
        }
    }
}