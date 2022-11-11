using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class boundaries : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Gives the boundary object a collider after flipping the mesh inside out
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.triangles = mesh.triangles.Reverse().ToArray();
        gameObject.AddComponent<MeshCollider>();
    }

}
