using UnityEngine;

public class Labyrinth
{
    public LabGeneratorCell[,] cells;
    public Vector2Int finishPos;
}
public class LabGeneratorCell
{
    public int _x;
    public int _y;

    public bool WallLeft = true;
    public bool WallBottom = true;
    public bool Floor = true;
    public bool Visited = false;
    public bool DeathArea = false;
    public bool EndArea = false;

    public int DisatanceFromStart;
}
