using UnityEngine;
using UnityEngine.AI;

public class LabInstaller : MonoBehaviour
{
    public GameObject CellPref;
    public Labyrinth labyrinth;

    private void Start()
    {
        LabGenerator labgen = new LabGenerator();
        labyrinth = labgen.GenerateLab();

        for (int x = 0; x < labyrinth.cells.GetLength(0); x++)
        {
            for (int z = 0; z < labyrinth.cells.GetLength(1); z++)
            {
                Cell3D c = Instantiate(CellPref, new Vector3(x * 5, 1, z * 5), Quaternion.identity).GetComponent<Cell3D>();
                c.WallLeft.SetActive(labyrinth.cells[x, z].WallLeft);
                c.WallBottom.SetActive(labyrinth.cells[x, z].WallBottom);
                c.Floor.SetActive(labyrinth.cells[x, z].Floor);
                c.DeathArea.SetActive(labyrinth.cells[x, z].DeathArea);
                c.EndArea.SetActive(labyrinth.cells[x, z].EndArea);

                NavigationBaker.instance.surfaces.Add(c.WallLeft.GetComponent<NavMeshSurface>());
                NavigationBaker.instance.surfaces.Add(c.WallBottom.GetComponent<NavMeshSurface>());
                NavigationBaker.instance.surfaces.Add(c.Floor.GetComponent<NavMeshSurface>());


            }
            
        }
        NavigationBaker.instance.Bake();
    }
}
