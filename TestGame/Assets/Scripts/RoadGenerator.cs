using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    public LabInstaller labInstaller;
    public List<Vector3> roadList;

    public void Start()
    {
        
    }
    private List<Vector3> CreateRoad()
    {
        Labyrinth lab = labInstaller.labyrinth;
        List<Vector3> list = new List<Vector3>();
        Vector3 currentPosition = labInstaller.labyrinth.finishPos;
        while (currentPosition != new Vector3(1, 1, 1))
        {
            list.Add(currentPosition);

            //if (currentPosition.x > 0 
                //&&lab.cells[currentPosition.x ,currentPosition.y].WallLeft
                //&&lab.cells[currentPosition.x-1, currentPosition.y].DisatanceFromStart== lab.cells[currentPosition.x, currentPosition.y].DisatanceFromStart-1)
        }

        return roadList;
    }
}
