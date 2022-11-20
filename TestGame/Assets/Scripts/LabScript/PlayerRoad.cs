using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoad : MonoBehaviour
{
    public static PlayerRoad Instance;
    public LabInstaller labInstaller;
    public List<Vector3> road;
    public GameObject player;
    private void Awake()
    {
        Instance = this;
    }

    public void CreateRoad()
    {
        Labyrinth lab = labInstaller.labyrinth;
        Vector2Int currentPos = labInstaller.labyrinth.finishPos;
        road = new List<Vector3>();

        while (currentPos != Vector2Int.zero)
        {
            road.Add((Vector2)currentPos);
            LabGeneratorCell currentCell = lab.cells[currentPos.x, currentPos.y];

            if (currentPos.x > 0 &&
                !currentCell.WallLeft &&
                lab.cells[currentPos.x - 1, currentPos.y].DisatanceFromStart == currentCell.DisatanceFromStart - 1)
            {
                currentPos.x--;
            }
            else if (currentPos.y > 0 &&
                !currentCell.WallBottom &&
                lab.cells[currentPos.x, currentPos.y - 1].DisatanceFromStart == currentCell.DisatanceFromStart - 1)
            {
                currentPos.y--;
            }
            else if (currentPos.x < lab.cells.GetLength(0) - 1 &&
                !lab.cells[currentPos.x + 1, currentPos.y].WallLeft &&
                lab.cells[currentPos.x + 1, currentPos.y].DisatanceFromStart == currentCell.DisatanceFromStart - 1)
            {
                currentPos.x++;
            }
            else if (currentPos.y < lab.cells.GetLength(1) - 1 &&
                !lab.cells[currentPos.x, currentPos.y+1].WallBottom &&
                lab.cells[currentPos.x, currentPos.y+1].DisatanceFromStart == currentCell.DisatanceFromStart - 1)
            {
                currentPos.y++;
            }
        }
        player.GetComponent<PlayerController>().SetRoad();
    }
}