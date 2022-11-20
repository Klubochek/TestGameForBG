using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationBaker : MonoBehaviour
{
    public GameObject Floor;
    public static NavigationBaker instance;
    public List<NavMeshSurface> surfaces;

    private void Awake()
    {
        instance = this;
    }

    public void Bake()
    {
        surfaces.Add(Floor.GetComponent<NavMeshSurface>());
        for (int i = 0; i < surfaces.Count; i++)
        {
            surfaces[i].BuildNavMesh();
        }
    }

}
