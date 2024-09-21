using System;

class Program
{
    static void Main(string[] args)
    {
        // Usando um número aleatório como "magic number"
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);
        int guess;

        // Loop até o usuário acertar o número
        do
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        } while (guess != magicNumber);
    }
}
