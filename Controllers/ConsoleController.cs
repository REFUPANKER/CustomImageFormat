public class ConsoleController
{
    private static ConsoleColor previousConsoleColor;
    public static void cwl(Object msg, ConsoleColor color)
    {
        previousConsoleColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(msg);
        Console.ForegroundColor = previousConsoleColor;
    }

    public static void cw(Object msg, ConsoleColor color)
    {
        previousConsoleColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.Write(msg);
        Console.ForegroundColor = previousConsoleColor;
    }

    public static void cwl(Object msg)
    {
        Console.WriteLine(msg);
    }

    public static void cw(Object msg)
    {
        Console.Write(msg);
    }
    
    public static void cls()
    {
        Console.Clear();
    }

    public static string createLine(int length, string letter)
    {
        string result = "";
        for (int i = 0; i < length; i++)
        {
            result += letter;
        }
        return result;
    }
}