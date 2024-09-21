using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int userNumber;

        // Usando do-while para garantir que o código seja executado pelo menos uma vez
        do
        {
            Console.Write("Enter a number (0 to quit): ");
            userNumber = int.Parse(Console.ReadLine());

            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        } while (userNumber != 0);

        if (numbers.Count > 0)
        {
            // Usando LINQ para simplificar cálculos
            int sum = numbers.Sum();
            float average = numbers.Average();
            int max = numbers.Max();

            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The max is: {max}");
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }
    }
}
