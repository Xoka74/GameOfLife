namespace GameOfLife;

public static class Program
{
    public static void Main(string[] args)
    {
        var field = new bool[20, 20];
        while (true)
        {
            Paint(field);
            Thread.Sleep(500);
            field = Game.NextStep(field);
        }
    }
    private static void Paint(bool[,] field)
    {
        Console.SetCursorPosition(0, 0);
        for (int y = 0; y < field.GetLength(1); y++)
        {
            for (int x = 0; x < field.GetLength(0); x++)
            {
                var symbol = field[x, y] ? '#' : ' ';
                Console.Write(symbol);
            }

            Console.WriteLine();
        }
    }
}