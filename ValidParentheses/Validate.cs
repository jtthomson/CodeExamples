using System.Collections;

namespace ValidParentheses
{
    public class Validate
    {        
        

        public static bool input(string input)
        {
            Stack parenthesisStack = new Stack();

            bool isValid = false;
            char[] chars = input.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                switch (chars[i])
                {
                    case ')':
                        if (parenthesisStack.Count > 0 )
                        {
                            char valPopped = (char)parenthesisStack.Pop();
                            if(valPopped != '(')
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case '}':
                        if (parenthesisStack.Count > 0)
                        {
                            char valPopped = (char)parenthesisStack.Pop();
                            if (valPopped != '{')
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case ']':
                        if (parenthesisStack.Count > 0)
                        {
                            char valPopped = (char)parenthesisStack.Pop();
                            if (valPopped != '[')
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    default:
                        parenthesisStack.Push(chars[i]);
                        break;

                }
            }
            isValid = (parenthesisStack.Count == 0);
            return isValid;
        }
    }
}
