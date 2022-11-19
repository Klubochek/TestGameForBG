using System.Collections.Generic;
using UnityEngine;


public class LabGenerator
{
    public int Width = 10;
    public int Height = 10;


    #region GENERATOR


    public Labyrinth GenerateLab()
    {
        LabGeneratorCell[,] cells = new LabGeneratorCell[Width, Height];
        for (int x = 0; x < cells.GetLength(0); x++)
        {
            for (int y = 0; y < cells.GetLength(1); y++)
            {
                cells[x, y] = new LabGeneratorCell { _x = x, _y = y };
                if (Random.Range(0, 5) == 1 && x != 0 && y != 0 && x != cells.GetLength(0)-1 && y != cells.GetLength(1)-1)
                {
                    cells[x, y].DeathArea = true;
                }
            }
        }
        for (int x = 0; x < cells.GetLength(0); x++)
        {
            cells[x, Height - 1].WallLeft = false;
            cells[x, Height - 1].Floor = false;
        }
        for (int y = 0; y < cells.GetLength(1); y++)
        {
            cells[Width - 1,y].WallBottom = false;
            cells[Width - 1, y].Floor = false;
        }

        RemoveWallsWithBacktracker(cells);
        Labyrinth lab = new Labyrinth();
        lab.cells = cells;
        lab.finishPos=PlaceExit(cells);
        return lab;
    }
    #endregion
    #region WALLREMOVER
    public void RemoveWallsWithBacktracker(LabGeneratorCell[,] lab)
    {
        LabGeneratorCell current = lab[0, 0];
        current.Visited = true;
        current.DisatanceFromStart = 0;

        Stack<LabGeneratorCell> stack = new Stack<LabGeneratorCell>();
        do
        {
            List<LabGeneratorCell> unvisitedNeighbours = new List<LabGeneratorCell>();
            int x = current._x;
            int y = current._y;

            if (x > 0 && !lab[x - 1, y].Visited) unvisitedNeighbours.Add(lab[x - 1, y]);
            if (y > 0 && !lab[x, y - 1].Visited) unvisitedNeighbours.Add(lab[x, y - 1]);
            if (x < Width - 2 && !lab[x + 1, y].Visited) unvisitedNeighbours.Add(lab[x + 1, y]);
            if (y < Height - 2 && !lab[x, y + 1].Visited) unvisitedNeighbours.Add(lab[x, y + 1]);

            if (unvisitedNeighbours.Count > 0)
            {
                LabGeneratorCell chosen = unvisitedNeighbours[Random.Range(0, unvisitedNeighbours.Count)];

                RemoveWall(current, chosen);
                chosen.Visited = true;
                stack.Push(chosen);
                chosen.DisatanceFromStart = current.DisatanceFromStart + 1;
                current = chosen;
                
            }
            else
            {
                current = stack.Pop();
            }

        } while (stack.Count > 0);
    }
    private void RemoveWall(LabGeneratorCell a, LabGeneratorCell b)
    {
        if (a._x == b._x)
        {
            if (a._y > b._y) a.WallBottom = false;
            else b.WallBottom = false;
        }
        else
        {
            if (a._x > b._x) a.WallLeft = false;
            else b.WallLeft = false;
        }
    }
    private Vector3 PlaceExit(LabGeneratorCell[,] lab)
    {
        LabGeneratorCell lastCell = lab[0,0];

        for (int x = 0; x < lab.GetLength(0); x++)
        {
            if (lab[x, Height - 2].DisatanceFromStart > lastCell.DisatanceFromStart) lastCell = lab[x, Height - 2];
            if (lab[x, 0].DisatanceFromStart > lastCell.DisatanceFromStart) lastCell = lab[x, 0];
        }
        for (int y = 0; y < lab.GetLength(1); y++)
        {
            if (lab[Width - 2, y].DisatanceFromStart > lastCell.DisatanceFromStart) lastCell = lab[Width - 2, y];
            if (lab[0, y].DisatanceFromStart > lastCell.DisatanceFromStart) lastCell = lab[0, y];
        }
        lastCell.EndArea = true;
        return new Vector3(lastCell._x, 1, lastCell._y) ;
    }
    #endregion
}
