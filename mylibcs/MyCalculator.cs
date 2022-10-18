using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace mylibcs
{
    public class MyCalculator
    {
        /// <summary>
        /// Calculate the results for statement such as “(1+5)*(5%(10*10))
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static int evaluateInfix(string expression)
        {
            char[] tokens = expression.ToCharArray();

            // Stack for numbers: 'values'
            Stack<int> values = new Stack<int>(); //to store integer data

            // Stack for Operators: 'ops'
            Stack<char> ops = new Stack<char>(); //to store operator

            for (int i = 0; i < tokens.Length; i++)
            {
                // Current token is a whitespace, skip it
                if (tokens[i] == ' ') //to skip because of empty token
                {
                    continue;
                }

                // Current token is a number,
                // push it to stack for numbers
                if (tokens[i] >= '0' && tokens[i] <= '9') //current token is number, insert it in stack
                {
                    StringBuilder sbuf = new StringBuilder();

                    // There may be more than one digits in number
                    while (i < tokens.Length &&
                            tokens[i] >= '0' &&
                                tokens[i] <= '9')
                    {
                        sbuf.Append(tokens[i++]);
                    }
                    values.Push(int.Parse(sbuf.ToString()));

                    //where the loop increases i and we decrease i here to complete the offset.
                    i--;
                }

                // Closing brace encountered, solve entire brace.
                else if (tokens[i] == '(')
                {
                    ops.Push(tokens[i]);
                }

                // Closing brace encountered,
                // solve entire brace
                else if (tokens[i] == ')')
                {
                    while (ops.Peek() != '(')
                    {
                        values.Push(applyOp(ops.Pop(),
                                         values.Pop(),
                                        values.Pop()));
                    }
                    ops.Pop();
                }

                // Function to perform arithmetic operations.
                else if (tokens[i] == '+' ||
                         tokens[i] == '-' ||
                         tokens[i] == '*' ||
                         tokens[i] == '/')
                {

                    // While top of 'ops' has same
                    // or greater precedence to current
                    // token, which is an operator.
                    // Apply operator on top of 'ops'
                    // to top two elements in values stack
                    while (ops.Count > 0 &&
                             hasPrecedence(tokens[i],
                                         ops.Peek()))
                    {
                        values.Push(applyOp(ops.Pop(),
                                         values.Pop(),
                                       values.Pop()));
                    }

                    // Push current token to 'ops'.
                    ops.Push(tokens[i]);
                }
            }

            //All expressions are decomposed into their values.To continue the proceedings
            while (ops.Count > 0)
            {
                values.Push(applyOp(ops.Pop(),
                                 values.Pop(),
                                values.Pop()));
            }

            return values.Pop(); // Top of 'values' contains result, return it.
        }

        public static bool hasPrecedence(char op1, //to find precedence of operators "+,-,*,/"
                                 char op2)
        {
            if (op2 == '(' || op2 == ')')
            {
                return false;
            }
            if ((op1 == '*' || op1 == '/') &&
                   (op2 == '+' || op2 == '-'))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // A utility method to apply an
        // operator 'op' on operands 'a' 
        // and 'b'. Return the result.
        public static int applyOp(char op, int b, int a) // Function to perform arithmetic operations.
        {
            switch (op)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    if (b == 0)
                    {
                        throw new
                        System.NotSupportedException(
                               "Cannot divide by zero");
                    }
                    return a / b;
            }
            return 0;
        }

        /// <summary>
        /// This function will determine missing parenthesis in the statement (Evaluate Infix will use this function inside
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public static bool validateInfix(string exp)
        {
            int previous = 0;
            int previous1 = 0;
            string expEvaluated = string.Empty;
            int operatorOperand = 1;

            for (int i = 0; i < exp.Length; i++)
            {
                char c = exp[i];
                if (c == ')')  //if encountered ")", stop process
                {
                }
                else
                if (c == '(')  //if encountered "(", start process until ")"
                {
                    int j = exp.IndexOf(')', i);
                    if (j == -1)
                        return false;

                    string substring = exp.Substring(i + 1, j - i - 1);

                    while (getcharactercount(substring, '(') != getcharactercount(substring, ')'))
                    {
                        if (j < exp.Length - 1)
                            j = exp.IndexOf(')', j + 1);
                        else
                            break;

                        substring = exp.Substring(i + 1, j - i - 1);
                    }

                    i = j - 1; //Changing the counter i to point to the next character
                    //validating the sub expression
                    if (validateInfix(substring) == true)
                    {
                        if (previous != 0 && previous1 != 0 && previous > previous1)
                        {
                            previous1 = operatorOperand;
                            operatorOperand++;
                            previous = 0;
                        }
                        else if (previous != 0 && previous1 != 0 && previous <= previous1)
                        {
                            return false;
                        }
                        else if (previous1 != 0)
                        {
                            return false;
                        }
                        else
                        {
                            previous1 = operatorOperand;
                            operatorOperand++;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                    if (c == '+'                      // Function to perform arithmetic operations.
                   || c == '-'
                   || c == '*'
                   || c == '/')
                {
                    if (previous != 0)
                    {
                        return false;
                    }
                    previous = operatorOperand;
                    operatorOperand++;
                }
                else
                {
                    if (previous != 0 && previous1 != 0 && previous > previous1)
                    {
                        previous1 = operatorOperand;
                        operatorOperand++;
                        previous = 0;
                    }
                    else if (previous != 0 && previous1 != 0 && previous <= previous1)
                    {
                        return false;
                    }
                    else if (previous1 != 0)
                    {
                        return false;
                    }
                    else
                    {
                        previous1 = operatorOperand;
                        operatorOperand++;
                    }
                }
            }
            if (previous != 0)
                return false;
            return true;
        }

        /// <summary>
        /// This function will convert infix to postfix, and EvaluateInfix will process postfix evaluation. This function will be used in EvaluateInfix
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public static string InfixToPostfixConversion(string exp)
        {
            string result = "";  //start show empty for result

            Stack<char> stack = new Stack<char>(); //starting empty stack in process

            for (int i = 0; i < exp.Length; ++i)
            {
                char c = exp[i];

                // If the scanned character is an operand, add it to output.
                if (char.IsLetterOrDigit(c))
                {
                    result += c;
                }

                // If the scanned character is an '(', push it to the stack.
                else if (c == '(')
                {
                    stack.Push(c);
                }

                else if (c == ')') //when it sees ")" , stop process until ")" is encoutered.
                {
                    while (stack.Count > 0 &&
                            stack.Peek() != '(')
                    {
                        result += stack.Pop();
                    }

                    if (stack.Count > 0 && stack.Peek() != '(') //if "(" encountered, to show invalid expressipn
                    {
                        return "Invalid Expression";
                    }
                    else
                    {
                        stack.Pop();  //to delete expression
                    }
                }
                else // an operator is encountered
                {
                    while (stack.Count > 0 && Prec(c) <=
                                      Prec(stack.Peek()))
                    {
                        result += stack.Pop();
                    }
                    stack.Push(c);
                }

            }

            // pop all the operators from the stack
            while (stack.Count > 0)
            {
                result += stack.Pop();
            }

            return result;
        }
        /// <summary>
        ///         A utility function to return
        /// precedence of a given operator
        /// Higher returned value means higher precedence
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        internal static int Prec(char ch) //to find precedence of operators "+,-,*,/"
        {
            switch (ch)
            {
                case '+':
                case '-':
                    return 1;

                case '*':
                case '/':
                    return 2;

                case '^':
                    return 3;
            }
            return -1;
        }

        /// <summary>
        /// to get the number of desired operation
        /// </summary>
        /// <param name="exp"></param>
        /// <param name="_c"></param>
        /// <returns></returns>
        public static int getcharactercount(string exp, char _c)  
        {
            int count = 0;
            foreach (char c in exp)
            {
                if (c == _c)
                    count++;
            }
            return count;
        }
    }
}