using System;
using System.Linq;

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

            //input validation. Onl y allowed characters are intaken
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

    public class CalcEngine
    {
        /// <summary>
        /// Process a calculation command string        
        /// </summary>
        /// <param name="expression">cmd</param>
        /// <returns></returns>
        public string Process(string expression)
        {            
            string[] operators = new string[] { "+", "-", "*" };

            decimal num1, num2, total;
            num1 = num2 = total = 0;
            string bit1, bit2, ope1, ope2;
            bit1 = bit2 = ope1 = ope2 = "";

            //validate at least one operator exists
            if (!operators.Any(expression.Contains)) 
                return "incorrect expression!. missing operators";
            
            //loop throught the expression
            foreach (var c in expression)
            {
                //find operators
                if (operators.Contains(c.ToString()))
                {
                    if (ope2 == "" && ope1 != "") ope2 = c.ToString();
                    if (ope1 == "") ope1 = c.ToString();                    
                }
                else
                {  
                    if (!char.IsWhiteSpace(c) && ope1 == "") bit1 += c.ToString();        
                    if (!char.IsWhiteSpace(c) && ope1 != "" && ope2 == "") bit2 += c.ToString();            
                }

                if (ope1 != "" && (ope2 != "" || c.ToString() == "\r"))
                {
                    //check for incorrect expression
                    if ((c.ToString() == "\r" || (ope1 != "" || ope2 != "")) 
                        && (bit1 == "" || bit2 == "")) return "incorrect expression!!";

                    //parse found numbers in string to decimal
                    num1 = Convert.ToDecimal(bit1);
                    num2 = Convert.ToDecimal(bit2);

                    //calculate operation using correct operator
                    if (ope1 == "+")
                    {
                        total = num1 + num2;
                    }
                    else if (ope1 == "-")
                    {
                        total = num1 - num2;
                    }
                    else if (ope1 == "*")
                    {
                        total = num1 * num2;
                    }

                    bit1 = total.ToString();
                    bit2 = "";
                    num1 = 0;
                    num2 = 0;
                    ope1 = ope2;
                    ope2 = "";                    
                }                
            }

            return total.ToString();
        }
    }
}
