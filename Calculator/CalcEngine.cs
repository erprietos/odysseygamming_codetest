using System;
using System.Linq;

namespace Calculator
{
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

            try
            {
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
            }
            catch (Exception e)
            {
                return "incorrect expression!.";
            }
            //loop throught the expression


            return total.ToString();
        }
    }
}
