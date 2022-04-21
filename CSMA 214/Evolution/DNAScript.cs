using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNAScript : MonoBehaviour
{
    // Color DNA
    public float r;
    public float g;
    public float b;

    Color OBJColor;  // This is the color of the object

    // Size DNA
    public float x;
    public float y;
    public float z;




    public Renderer rend;  // This is what determines how the object gets seen in the scene
    public Collider col;  // This is going to let us click on the object in screenspace

    public float timeToDie = 0;  // how long does it take my object to die

    bool dead = false;


    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        col = GetComponent<Collider>();

        rend.material.color = new Color(r, g, b);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // On click, GameObject will disappear
    //private void OnMouseDown()
    public void Die()
    {
        dead = true;
        timeToDie = PopulationManagerScript.elapsed;
        rend.enabled = false;
        col.enabled = false;
    }
}
