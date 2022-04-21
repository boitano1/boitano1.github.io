using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class LandscapeGeneratorTwo : MonoBehaviour
{
    Mesh generatedMesh;

    Vector3[] vertices;
    int[] triangles;
    Vector2[] uvs;

    public int xSize = 30;
    public int zSize = 30;

    public GameObject popManager;

    // Start is called before the first frame update
    void Start()
    {
        // MakePrimitive();

        generatedMesh = new Mesh();
        GetComponent<MeshFilter>().mesh = generatedMesh;

        CreateMesh();
        //UpdateMesh();
    }


    public void CreateMesh()
    {
        // create the vertices
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise(x * popManager.GetComponent<PopulationManagerScript>().landscapeRef, z * 0.3f) * 2f;

                vertices[i] = new Vector3(x, y, z);
                i++;
            }
        }

        // create the triangles

        triangles = new int[xSize * zSize * 6];
        int vert = 0;
        int tris = 0;

        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }

        // define the uv array
        uvs = new Vector2[vertices.Length];

        // create uvs
        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                uvs[i] = new Vector2((float)x / xSize, (float)z / zSize);
                i++;
            }  
        }
        UpdateMesh();
    }

    void UpdateMesh()
    {
        // update the vertices
        generatedMesh.vertices = vertices;

        // update the triangles
        generatedMesh.triangles = triangles;

        generatedMesh.uv = uvs;
        
        // calculate normals
        generatedMesh.RecalculateNormals();
    }

    private void OnDrawGizmos()
    {
        if (vertices == null)
        {
            return;
        }

        for (int i = 0; i < vertices.Length; i++)
        {
             Gizmos.DrawSphere(vertices[i], 0.1f);
        }
    }

    void Update()
    {

    }
}
