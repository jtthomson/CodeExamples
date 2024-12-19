using System.Text;

namespace Stack
{
    public class MinStack : IStack
    {
        public string Name => "MinStack";
        public List<string> Sets { get; set; }
        public List<int?> Vals { get; set; }
        public int NumberOfVals { get; set; }

        private int minValue = int.MaxValue;
        private List<int> myStack;

        public MinStack()
        {
            
            this.Sets = new List<string>();
            this.Vals = new List<int?>();
            this.myStack = new List<int>();
            this.NumberOfVals = 0;
        }

        public MinStack(List<string> customInstructionSets, List<int?> customInstructionVals)
        {
            string name = customInstructionSets[0];
            if (name != this.Name)
            {
                throw new InvalidOperationException($"Type {name} cannot create type MinStack.");
            }
            customInstructionSets.RemoveAt(0);
            customInstructionVals.RemoveAt(0);
            this.Sets = customInstructionSets;
            this.Vals = customInstructionVals;
            this.myStack = new List<int>();
            this.NumberOfVals = customInstructionSets.Count;
        }

        public static MinStack MinStackFactory(string inputSets, string inputVals)
        {
            //Example: ["MinStack","push","push","push","getMin","pop","top","getMin"] is parsed into a list of strings
            List<string> parsedStringList = inputSets.Trim()
                .Substring(1, inputSets.Length - 2) //Remove first and last [ ] 
                .Replace("\"", "")
                .Split(",")
                .ToList();
            int numberOfSets = parsedStringList.Count;

            List<int?> parsedValList = inputVals.Trim()
                .Substring(1, (inputVals.Length - 2)) //Remove first and last [ ] 
                .Replace("[", "")// remove opening brackets 
                .Replace("]", "")// remove closing brackets 
                .Split(",", StringSplitOptions.None) // split out all values, even if it is an empty string
                .Select(x => {
                    if(string.IsNullOrEmpty(x))
                    {
                        return (int?)null;
                    }
                    else { return Int32.Parse(x); }
                }) // parse the int, otherwise leave it null.  
                .ToList();
            int numberOfVals = parsedValList.Count;
            if( numberOfVals != numberOfSets ) 
            {
                throw new DataMisalignedException("Number of Sets must be equal to the number of vals");
            }

            return new MinStack(parsedStringList, parsedValList);
        }

        public string run()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[null,");
            for (int i = 0; i < NumberOfVals; i++)
            {
                switch (Sets[i])
                {
                    case "push":
                        try
                        {
                            push(Vals[i].Value);
                            sb.Append("null,");
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        break;
                    case "pop":
                        try
                        {
                            pop();
                            sb.Append("null,");
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                        break;
                    case "top":
                        try
                        {
                            sb.Append(top() + ",");
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                        break;
                    case "getMin":
                        sb.Append(getMinValue() + ",");
                        break;
                    default:
                        break;


                }
            }
            sb.Length--;
            sb.Append("]");
            return sb.ToString();
        }

        public void pop()
        {
            int valToPop = myStack[myStack.Count - 1];

            myStack.RemoveAt(myStack.Count - 1);
            if (valToPop == minValue)
            {
                if (myStack.Count > 0)
                {
                    minValue = myStack.Min();
                }
                else
                {
                    minValue = int.MaxValue;
                }
            }
        }

        public void push(int val)
        {
            myStack.Add(val);
            if (val < minValue)
            {
                minValue = val;
            }
        }

        public int top()
        {
            return myStack[myStack.Count - 1];
        }

        public int getMinValue()
        {
            return minValue;
        }
    }
}
