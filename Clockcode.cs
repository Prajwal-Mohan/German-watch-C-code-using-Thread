
using System;
    using System.Threading;
namespace Timing_Word_watch
{


    

    class Program
    {
        static void Main()
        {
            // Dimensions of the matrix
            const int rows = 10;
            const int cols = 40;

            // Initialize the matrix with spaces
            char[,] matrix = new char[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = ' ';
                }
            }

            // Words to represent time in German
            string[] words = { "ZWÖLF", "EINS", "ZWEI", "DREI", "VIER", "FÜNF", "SECHS", "SIEBEN", "ACHT", "NEUN",
                           "ZEHN", "ELF", "ZWÖLF", "UHR", "MINUTE", "SEKUNDE" };

            Console.WriteLine("Press Ctrl+C to exit.");
            int wordIndex = 0;
            while (true)
            {
                // Clear the console and the matrix
                Console.Clear();
                Array.Clear(matrix, 0, matrix.Length);

                // Get the current time
                DateTime now = DateTime.Now;

                // Convert the time to German words
                string hourWord = words[now.Hour % 12];
                string minuteWord = words[now.Minute];
                string secondWord = words[now.Second];

                // Fill the matrix with the words to represent time
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        char letter = ' ';
                        if (wordIndex < hourWord.Length)
                        {
                            letter = hourWord[wordIndex];
                        }
                        else if (wordIndex >= hourWord.Length && wordIndex < hourWord.Length + minuteWord.Length)
                        {
                            letter = minuteWord[wordIndex - hourWord.Length];
                        }
                        else if (wordIndex >= hourWord.Length + minuteWord.Length && wordIndex < hourWord.Length + minuteWord.Length + secondWord.Length)
                        {
                            letter = secondWord[wordIndex - hourWord.Length - minuteWord.Length];
                        }

                        matrix[i, j] = letter;
                    }
                }

                // Display the matrix
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        Console.Write(matrix[i, j]);
                    }
                    Console.WriteLine();
                }

                // Output the current time in German
                Console.WriteLine("Aktuelle Zeit: " + hourWord + " " + minuteWord + " " + secondWord);

                // Wait for one second before updating the matrix
                Thread.Sleep(1000);

                // Increment wordIndex and reset it if it reaches the maximum index for the words
                wordIndex = (wordIndex + 1) % (hourWord.Length + minuteWord.Length + secondWord.Length);
            }
        }
    }



}
