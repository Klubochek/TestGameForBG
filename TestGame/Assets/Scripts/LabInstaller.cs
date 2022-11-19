using UnityEngine;

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
                GameObject newCell = Instantiate(CellPref,transform);
                newCell.transform.localPosition = new Vector3(-22.5f + 5 * x, 0.25f, -22.5f +5* z);
                Cell3D c =newCell.GetComponent<Cell3D>();
                c.WallLeft.SetActive(labyrinth.cells[x, z].WallLeft);
                c.WallBottom.SetActive(labyrinth.cells[x, z].WallBottom);
                c.DeathArea.SetActive(labyrinth.cells[x, z].DeathArea);
                c.EndArea.SetActive(labyrinth.cells[x, z].EndArea);

                NavigationBaker.instance.surfaces.Add(c.LeftWallNav);
                NavigationBaker.instance.surfaces.Add(c.BottomWallNav);


            }

        }
        NavigationBaker.instance.Bake();
    }
}
