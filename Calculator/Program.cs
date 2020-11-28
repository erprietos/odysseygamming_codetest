using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //display instructions
            string input = "";
            Console.Write("Enter the expression using the following characters(+,-,*,.,1,2,3,4,5,67,8,9): ");
            ConsoleKeyInfo key;

            //input validation. Only allowed characters are intaken
            //this part of the code can be also extracted and use as a validation
            //class or method for checking the inputs before use any calculations.

            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace)
                {
                    //checks if char is allow
                    if ((char.IsNumber(key.KeyChar) && key.KeyChar.ToString() != "0") ||
                         char.IsWhiteSpace(key.KeyChar) ||                                              
                         (key.KeyChar.ToString() == "+" || key.KeyChar.ToString() == "-" || 
                         key.KeyChar.ToString() == "*" || key.KeyChar.ToString() == "."))
                    {
                        input += key.KeyChar;
                        Console.Write(key.KeyChar);
                    }
                }
                else
                {
                    //Backspace to previous character
                    if (key.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        input = input.Substring(0, (input.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
            // Enter is keyed so no more characters are taken. Now use calculate
            while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            CalcEngine calcEngine = new CalcEngine();
            var result = calcEngine.Process(input);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
