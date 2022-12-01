using System.Collections.Generic;
using System;

namespace GameOfLife;

public class Game
{
    public static bool[] GetCellNeighbours(bool[,] field, int x, int y)
    {
        var neighbours = new List<bool>();
        for (var i = x - 1; i <= x + 1; i++)
        for (var j = y - 1; j <= y + 1; j++)
        {
            try
            {
                neighbours.Add(field[i, j]);
            }
            catch (Exception)
            {
            }
        }

        return neighbours.ToArray();
    }

    public static int GetAliveNeighbours(bool[] neighbours)
    {
        var count = 0;
        foreach (var neighbour in neighbours)
            if (neighbour)
                count++;

        return count;
    }

    public static void TransformCell(bool[,] field, int x, int y)
    {
        var neighbours = GetCellNeighbours(field, x, y);
        var aliveNeighbours = GetAliveNeighbours(neighbours);
        switch (aliveNeighbours)
        {
            case 3:
                field[x, y] = true;
                break;
            case 2: break;
            default:
                field[x, y] = false;
                break;
        }
    }

    public static bool[,] NextStep(bool[,] field)
    {
        var height = field.GetLength(0);
        var width = field.GetLength(1);
        for (var x = 0; x < width; x++)
        for (var y = 0; y < height; y++)
            TransformCell(field, x, y);
        return field;
    }
}