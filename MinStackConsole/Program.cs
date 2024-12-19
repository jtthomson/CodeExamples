// See https://aka.ms/new-console-template for more information
bool isActive = true;
while (isActive)
{
    Console.WriteLine(@"Enter Custom Data Set in the form [""MinStack"",""*""].  Example: [""MinStack"",""push"",""push"",""push"",""getMin"",""pop"",""top"",""getMin""]");
    string? datasetInput = Console.ReadLine();
    if (string.IsNullOrEmpty(datasetInput))
    {
        Console.WriteLine("that wasn't a valid data set entry");
        continue;
    }
    Console.WriteLine(@"Enter Custom Data Values in the form [""[]"",""[*]""].  Example: [[],[-2],[0],[-3],[],[],[],[]]");
    string? dataValsInput = Console.ReadLine();
    if (string.IsNullOrEmpty(dataValsInput))
    {
        Console.WriteLine("Value where not valid");
        continue;
    }
    try
    {
        Stack.MinStack minStack = Stack.MinStack.MinStackFactory(datasetInput, dataValsInput);
        Console.WriteLine(minStack.run());
        isActive = false;
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        Console.WriteLine("Try another dataset.");
        continue;
    }
}
Console.WriteLine("End.");
Console.ReadLine();
