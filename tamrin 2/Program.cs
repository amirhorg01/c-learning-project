using System.ComponentModel;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace tamrin_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.WriteLine("\n===== EXERCISE MENU =====");
                Console.WriteLine("1. Check divisibility of two numbers");
                Console.WriteLine("2. Check if a number is prime");
                Console.WriteLine("3. Check if a number is even or odd");
                Console.WriteLine("4. Generate random number and check divisibility by 5");
                Console.WriteLine("5. Calculate average of several numbers");
                Console.WriteLine("6. Calculate median of several numbers");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                string choiceInput = Console.ReadLine();

                if (!int.TryParse(choiceInput, out int choice))
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Exercise1_Divisibility();
                        break;
                    case 2:
                        Exercise2_PrimeCheck();
                        break;
                    case 3:
                        Exercise3_EvenOdd();
                        break;
                    case 4:
                        Exercise4_RandomDivisibleBy5();
                        break;
                    case 5:
                        Exercise5_Average();
                        break;
                    case 6:
                        Exercise6_Median();
                        break;
                    case 0:
                        keepRunning = false;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select 0-6.");
                        break;
                }
            }
        }

        // ========== EXERCISE 1: DIVISIBILITY ==========
        static void Exercise1_Divisibility()
        {
            Console.Write("Enter first number: ");
            if (!int.TryParse(Console.ReadLine(), out int first))
            {
                Console.WriteLine("Invalid number!");
                return;
            }

            Console.Write("Enter second number: ");
            if (!int.TryParse(Console.ReadLine(), out int second))
            {
                Console.WriteLine("Invalid number!");
                return;
            }

            if (second != 0 && first % second == 0)
                Console.WriteLine($"{first} is divisible by {second}");
            else
                Console.WriteLine($"{first} is NOT divisible by {second}");
        }

        // ========== EXERCISE 2: PRIME CHECK ==========
        static void Exercise2_PrimeCheck()
        {
            Console.Write("please enter your number: ");
            int num = int.Parse(Console.ReadLine());


            if (num < 2)
            {
                Console.WriteLine("\nits not prime");
            }
            else if (num == 2)
            {
                Console.WriteLine("\nits prime number");
            }
            else if (num == 3)
            {
                Console.WriteLine("\nits prime number");
            }
            else if (num == 5)
            {
                Console.WriteLine("\nits prime number");
            }
            else if (num == 7)
            {
                Console.WriteLine("\nits prime number");
            }
            else if (num == 11)
            {
                Console.WriteLine("\nits prime number");
            }


            else if (num % 2 == 0)
            {
                Console.WriteLine("\nits not prime number (divisible to 2)");
            }
            else if (num % 3 == 0)
            {
                Console.WriteLine("\nits not prime number (divisible to 3)");
            }
            else if (num % 5 == 0)
            {
                Console.WriteLine("\nits not prime number (divisible to 5)");
            }
            else if (num % 7 == 0)
            {
                Console.WriteLine("\nits not prime number (divisible to 7)");
            }
            else if (num % 11 == 0)
            {
                Console.WriteLine("\nits not prime number (divisible to 11)");
            }
            else
            {
                // اگه به هیچکدوم از موارد بالا بخش‌پذیر نبود اول است
                Console.WriteLine("\nits prime number");
            }
        }

        // ========== EXERCISE 3: EVEN OR ODD ==========
        static void Exercise3_EvenOdd()
        {
            Console.Write("Enter a number: ");
            if (!int.TryParse(Console.ReadLine(), out int num))
            {
                Console.WriteLine("Invalid number!");
                return;
            }

            if (num % 2 == 0)
                Console.WriteLine($"{num} is even");
            else
                Console.WriteLine($"{num} is odd");
        }

        // ========== EXERCISE 4: RANDOM NUMBER DIVISIBLE BY 5 ==========
        static void Exercise4_RandomDivisibleBy5()
        {
            Random rand = new Random();
            int randomNumber = rand.Next(1, 1001); // 1 to 1000

            Console.WriteLine($"Random number generated: {randomNumber}");

            if (randomNumber % 5 == 0)
                Console.WriteLine($"{randomNumber} is divisible by 5");
            else
                Console.WriteLine($"{randomNumber} is NOT divisible by 5");
        }

        // ========== EXERCISE 5: AVERAGE ==========
        static void Exercise5_Average()
        {
            Console.Write("How many numbers? ");
            if (!int.TryParse(Console.ReadLine(), out int count) || count <= 0)
            {
                Console.WriteLine("Invalid count!");
                return;
            }

            double sum = 0;

            for (int i = 1; i <= count; i++)
            {
                Console.Write($"Enter number {i}: ");
                if (!double.TryParse(Console.ReadLine(), out double num))
                {
                    Console.WriteLine("Invalid number! Try again.");
                    i--; // retry this iteration
                    continue;
                }
                sum += num;
            }

            double average = sum / count;
            Console.WriteLine($"Average: {average:F2}");
        }

        // ========== EXERCISE 6: MEDIAN ==========
        static void Exercise6_Median()
        {
            Console.Write("How many numbers? ");
            if (!int.TryParse(Console.ReadLine(), out int count) || count <= 0)
            {
                Console.WriteLine("Invalid count!");
                return;
            }

            double[] numbers = new double[count];

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter number {i + 1}: ");
                if (!double.TryParse(Console.ReadLine(), out double num))
                {
                    Console.WriteLine("Invalid number! Try again.");
                    i--; // retry this iteration
                    continue;
                }
                numbers[i] = num;
            }

            Array.Sort(numbers);

            double median;
            if (count % 2 == 1) // odd count
                median = numbers[count / 2];
            else // even count
                median = (numbers[count / 2 - 1] + numbers[count / 2]) / 2;

            Console.WriteLine($"Sorted numbers: {string.Join(", ", numbers)}");
            Console.WriteLine($"Median: {median:F2}");
        }
    }
}
