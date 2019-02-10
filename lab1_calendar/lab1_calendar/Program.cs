using System;

namespace lab1_calendar {
    class Program {
        static void Main(string[] args) {
            DateTime dateTime;
            Console.Write("Insert date: ");
            var dateString = Console.ReadLine();

            if (DateTime.TryParse(dateString, out dateTime)) {
                var firstDayOfMonth = new DateTime(dateTime.Year, dateTime.Month, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                Console.WriteLine("Mon\tTue\tWed\tThu\tFri\tSat\tSun");
                int startShift = (int) firstDayOfMonth.DayOfWeek;
                if (startShift == 0) {
                    Console.WriteLine(" \t \t \t \t \t");
                }
                else {
                    for (int i = 0; i < startShift - 1; i++) {
                        Console.Write(" \t");
                    }
                }

                var currentDayOfMonth = firstDayOfMonth;
                var workingDays = 0;
                for (int i = 1; i <= lastDayOfMonth.Day; i++) {
                    if (currentDayOfMonth.DayOfWeek == DayOfWeek.Saturday) {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{i}\t");
                    }
                    else if (currentDayOfMonth.DayOfWeek == DayOfWeek.Sunday) {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{i}\t");
                        Console.WriteLine();
                    }
                    else {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write($"{i}\t");
                        workingDays++;
                    }
                    
                    currentDayOfMonth = currentDayOfMonth.AddDays(1);
                }

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\nAmount of working days: {workingDays}");
            }
            else {
                Console.WriteLine("ERROR: can't recognize date format, terminating the program.");
                Environment.Exit(-1);
            }
            
        }
    }
}