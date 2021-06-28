using System;
using System.IO;
using System.Linq;

namespace PreparatoryCourse
{
    internal class Program
    {
        private static readonly Menu menu = new Menu()
        {
            MenuItems =

                {
                new MenuItem()
                    {
                        Text = "Exit",
                        Action = () => Console.ReadKey()
                    },
                    new MenuItem()
                    {
                        Text = "Hello World",
                        Action = () => HelloWorld()
                    },
                    new MenuItem()
                    {
                        Text = "Input user details",
                        Action = () => InputUserDetails()
                    },
                    new MenuItem()
                    {
                        Text = "Toogle text color",
                        Action = () => ToggleTextColor()
                    },
                    new MenuItem()
                    {
                        Text = "Print date",
                        Action = () => PrintDate()
                    },
                    new MenuItem()
                    {
                        Text = "Decide the greatest number",
                        Action = () => Greatest()
                    },
                    new MenuItem()
                    {
                        Text = "Guess number",
                        Action = () => GuessNumber()
                    },
                    new MenuItem()
                    {
                        Text = "Write input to file",
                        Action = () => WriteUserInputToDisk()
                    },
                    new MenuItem()
                    {
                        Text = "Read file",
                        Action = () => ReadFile()
                    },
                    new MenuItem()
                    {
                        Text = "Squere root power 2 power 10 ",
                        Action = () => DoMath()
                    },
                    new MenuItem()
                    {
                        Text = "Print multiplication table",
                        Action = () => PrintMultiplicationTable()
                    },
                    new MenuItem()
                    {
                        Text = "Create two arrays",
                        Action = () => CreateTwoArrays()
                    },
                    new MenuItem()
                    {
                        Text = "Check if input is palindrom",
                        Action = () => Palindrom()
                    },
                    new MenuItem()
                    {
                        Text = "Print numbers between input1 and input2",
                        Action = () => AllNumbersBetweenTwoIntegers()
                    },
                    new MenuItem()
                    {
                        Text = "Take input and group by odd and even",
                        Action = () => InputNumbersAndSortOddEven()
                    },
                    new MenuItem()
                    {
                        Text = "Input numbers and print the sum",
                        Action = () => InputNumbersSum()
                    },
                    new MenuItem()
                    {
                        Text = "Create player and opponent",
                        Action = () => InputPlayers()
                    }
                }
        };

        private static void Main(string[] args)
        {
            while (ShowMenu()) ;
        }

        private static Boolean ShowMenu()
        {
            Console.Clear();
            menu.PrintToConsole();

            //wait for user input
            string choice = Console.ReadLine();

            if (choice == "exit" || choice == "0")
            {
                return false;
            }

            if (!int.TryParse(choice, out int choiceIndex) || choiceIndex < 0 || choiceIndex >= menu.MenuItems.Count)
            {
                Console.Clear();

                Console.WriteLine("Invalid selection - try again");
                return ShowMenu();
            }
            else
            {
                Console.Clear();
                var menuItemSelected = menu.MenuItems[choiceIndex];
                menuItemSelected.Action();
                return true;
            }
        }

        private static void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void HelloWorld()
        {
            Console.WriteLine("Hello world");
            PressAnyKeyToContinue();
        }

        public struct User
        {
            public User(string firstName, string surname, int age)
            {
                FirstName = firstName;
                Surname = surname;
                Age = age;
            }

            public string FirstName { get; set; }
            public string Surname { get; set; }
            public int Age { get; set; }
        }

        private static void InputUserDetails()
        {
            Console.WriteLine("What is your first name?");
            User user = new User
            {
                FirstName = Console.ReadLine()
            };

            Console.WriteLine("What is your surname?");
            user.Surname = Console.ReadLine();

            int age;
            do
            {
                Console.WriteLine("What is your age?");
            }
            while (!int.TryParse(Console.ReadLine(), out age));

            user.Age = age;
            Console.Clear();
            Console.WriteLine("Result: {0} {1}, {2}", user.FirstName, user.Surname, user.Age);
            PressAnyKeyToContinue();
        }

        private static void ToggleTextColor()
        {
            if (Console.ForegroundColor == ConsoleColor.Gray)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        private static void PrintDate()
        {
            Console.WriteLine("{0}-{1}-{2}", DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            PressAnyKeyToContinue();
        }

        private static void Greatest()
        {
            var value = new Int32[2];
            for (int i = 0; i < value.Length; i++)
            {
                Console.WriteLine("Insert value");
                value[i] = Int32.Parse(Console.ReadLine());
            }
            if (value[0] == value[1])
            {
                Console.WriteLine("{0} equals to {0}", value[0]);
                return;
            }
            int theGreatestIndex = (value[0] > value[1]) ? 0 : 1;

            Console.WriteLine("{0} is the greatest!", value[theGreatestIndex]);

            PressAnyKeyToContinue();
        }

        private static void GuessNumber()
        {
            int guess;
            int numberOfGuesses = 0;
            int number = new Random().Next(1, 100);
            do
            {
                // Wait for int input
                do
                {
                    Console.Clear();
                    Console.WriteLine("Input a number: (0 for exit)");
                }
                while (!int.TryParse(Console.ReadLine(), out guess));

                // exit if user input is 0
                if (guess == 0)
                {
                    return;
                }

                numberOfGuesses++;
                if (guess == number)
                {
                    Console.WriteLine("Well done! it took {0} tries", numberOfGuesses);
                    PressAnyKeyToContinue();
                    return;
                }
                Console.Clear();
                if (guess > number)
                {
                    Console.WriteLine("{0} is greater than the target number", guess);
                }
                else
                {
                    Console.WriteLine("{0} is less than the target number", guess);
                }
                PressAnyKeyToContinue();
            } while (guess != number);
        }

        private static void WriteUserInputToDisk()
        {
            Console.WriteLine("Write something that will be saved to a WriteText.txt");
            String userInput = Console.ReadLine();
            File.WriteAllText("WriteText.txt", userInput);
            Console.WriteLine("input saved to WriteText.txt");
            PressAnyKeyToContinue();
        }

        private static void ReadFile()
        {
            // Read the file as one string.
            string text = File.ReadAllText(@"WriteText.txt");

            // Display the file contents to the console. Variable text is a string.
            Console.WriteLine("Contents of WriteText.txt = {0}", text);
            PressAnyKeyToContinue();
        }

        private static void DoMath()
        {
            Double input;
            do
            {
                Console.Clear();
                Console.WriteLine("Input a decimal:");
            }
            while (!Double.TryParse(Console.ReadLine(), out input));

            var result = Math.Pow(Math.Pow(Math.Sqrt(input), 2), 10);
            Console.WriteLine("the result is {0}", result);

            PressAnyKeyToContinue();
        }

        private static void PrintMultiplicationTable()
        {
            for (int i = 1; i <= 10; i++)
            {
                for (int x = 1; x <= 10; x++)
                {
                    Console.Write(i * x + "\t");
                }
                Console.WriteLine();
            }

            PressAnyKeyToContinue();
        }

        private static void CreateTwoArrays()
        {
            Random random = new Random();
            byte[] bytes = new byte[5];
            random.NextBytes(bytes);
            byte[] newArray = (byte[])bytes.Clone();
            Array.Sort(newArray);
        }

        private static void Palindrom()
        {
            Console.WriteLine("Input: ");
            String input = Console.ReadLine().ToLower();
            if (input.SequenceEqual(input.Reverse()))
            {
                Console.WriteLine("{0} is a palindrom", input);
            }
            else
            {
                Console.WriteLine("{0} is not a palindrom", input);
            }

            PressAnyKeyToContinue();
        }

        private static void AllNumbersBetweenTwoIntegers()
        {
            Int16 input1;
            Int16 input2;
            do
            {
                Console.Clear();
                Console.WriteLine("Input first integer:");
            }
            while (!Int16.TryParse(Console.ReadLine(), out input1));
            do
            {
                Console.Clear();
                Console.WriteLine("Input second integer:");
            }
            while (!Int16.TryParse(Console.ReadLine(), out input2));
            Console.Clear();

            var isinput2greater = input2 > input1;
            var start = isinput2greater ? input1 : input2;
            int count = isinput2greater ? input2 : input1;

            start++;
            count -= 2;

            var range = Enumerable.Range(start, count).ToArray();
            if (!isinput2greater)
            {
                Array.Reverse(range);
            }

            foreach (var integer in range)
            {
                Console.WriteLine(integer);
            }

            PressAnyKeyToContinue();
        }

        private static void InputNumbersAndSortOddEven()
        {
            Console.Write("Please enter a bunch of digits separated by a comma: ");

            try
            {
                String[] allDigits = Console.ReadLine().Split(',');

                int[] digits = allDigits.Select(d => Int32.Parse(d)).ToArray();

                Array.Sort(digits);

                var evens = digits.Where(x => x % 2 == 0);
                var odds = digits.Where(x => x % 2 == 1);

                Console.WriteLine("Evens: {0}", String.Join("\t", evens));
                Console.WriteLine("Odds {0}", String.Join("\t", odds));

                PressAnyKeyToContinue();
            }
            catch
            {
                // Just try again
                InputNumbersAndSortOddEven();
            }
        }

        private static void InputNumbersSum()
        {
            Console.Write("Please enter a bunch of digits separated by a comma: ");

            try
            {
                String[] allDigits = Console.ReadLine().Split(',');

                int[] digits = allDigits.Select(d => Int32.Parse(d)).ToArray();

                int sum = digits.Sum();

                Console.WriteLine("Sum {0}={1}", String.Join("+", digits), sum);

                PressAnyKeyToContinue();
            }
            catch
            {
                // Just try again
                InputNumbersAndSortOddEven();
            }
        }

        private static void InputPlayers()
        {
            Console.WriteLine("Player name:");
            Random random = new Random();
            Player player = new Player(Console.ReadLine())
            {
                Health = random.Next(1, 100),
                Luck = random.Next(1, 100),
                Strength = random.Next(1, 100)
            };

            Console.WriteLine("Opponent name:");
            Player opponent = new Player(Console.ReadLine())
            {
                Health = random.Next(1, 100),
                Luck = random.Next(1, 100),
                Strength = random.Next(1, 100)
            };
        }
    }
}