using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMPAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Wyniki w pliku wyjściowym.");
                using (StreamWriter writer = new StreamWriter("file.out"))
                {
                    Console.SetOut(writer);
                    string[] inputData = File.ReadAllLines("file.in");
                    List<int> indexes = KMP.Search(inputData[0], inputData[1]);

                    foreach (var i in indexes)
                        Console.WriteLine("Element znaleziono na pozycji: {0}", i);

                    int[] array = KMP.calculateArray(inputData[0]);
                    foreach (var i in array)
                        Console.Write("[{0}]", i);

                    Console.WriteLine("\n");                
                }
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("Nieprawidłowa ścieżka do pliku.");
            }
            finally
            {
                Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
                Console.ReadKey();
            }
        }
    }
}
