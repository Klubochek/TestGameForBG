using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationBaker : MonoBehaviour
{
    public static NavigationBaker instance;
    public List <NavMeshSurface> surfaces;

    private void Awake()
    {
        instance = this;
    }
    
    public void Bake() 
    {
        
        for (int i = 0; i < surfaces.Count; i++)
        {
            surfaces[i].BuildNavMesh();
        }
    }

}
