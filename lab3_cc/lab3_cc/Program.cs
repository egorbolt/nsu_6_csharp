using System;
using System.Globalization;
using System.IO;

namespace lab3_cc {
    class Program {
        static int _linesSum = 0;
        
        static void Main(string[] args) {
            CountLines(".");
            Console.WriteLine(_linesSum);
        }

        static void CountLines(string path) {
            foreach (string directory in Directory.GetDirectories(path)) {
                CountLines(directory);
            }

            foreach (string file in Directory.GetFiles(path)) {
                if (Path.GetExtension(file).Equals(".cs")) {
                    using (StreamReader sr = new StreamReader(file, System.Text.Encoding.Default)) {
                        string line;
                        while ((line = sr.ReadLine()) != null) {
                            if (line.Length >= 2) {
                                string sub = line.Substring(0, 2);
                                if (!sub.Equals("//")) {
                                    _linesSum++;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}