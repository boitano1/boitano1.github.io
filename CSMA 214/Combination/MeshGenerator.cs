using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// automatically put in mesh filter when adding script to object
[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    Mesh generatedMesh;

    Vector3[] vertices;
    int[] triangles;

    // Start is called before the first frame update
    void Start()
    {
        // MakePrimitive();

        generatedMesh = new Mesh();
        GetComponent<MeshFilter>().mesh = generatedMesh;

        CreateMesh();
        UpdateMesh();
    }

    
    void CreateMesh()
    {
        // define the vertices
        vertices = new Vector3[]
        {
            new Vector3 (0,0,0),
            new Vector3 (0,0,1),
            new Vector3 (1,0,0),
            new Vector3 (1,0,1)
        };

        // define the triangles
        triangles = new int[]
        {
            0, 1, 2,
            1, 3, 2
        };
    }

    void UpdateMesh()
    {
        // update the vertices
        generatedMesh.vertices = vertices;

        // update the triangles
        generatedMesh.triangles = triangles;

        generatedMesh.RecalculateNormals();
    }

    void MakePrimitive()
    {
        /*
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);

        plane.GetComponent<Renderer>().material.color = new Color(0.5f, 0.1f, 0.9f);
        */
    }
}
