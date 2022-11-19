
using UnityEngine;
using UnityEngine.AI;

public class Cell3D : MonoBehaviour
{
    public GameObject WallLeft;
    public GameObject WallBottom;
    public GameObject DeathArea;
    public GameObject EndArea;

    public NavMeshSurface LeftWallNav;
    public NavMeshSurface BottomWallNav;
    
    public int SizeX=5;
    public int SizeZ=5;
}
