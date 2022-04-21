using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    // GameObject to act as the boid
    public GameObject flockOBJ;

    //GameObject to hold flock Objects
    public GameObject FlockContainer;

    // An int to define how many objects are in the array of GameObjects
    public int numOBJ;

    // An array of GameObjects that hold all of our boids
    public GameObject[] allFlockOBJ;

    // A GAMEOBJECT FOR THE FLOCK TO AVOID
    public GameObject Predator;

    // INTEGER FOR CREATING RANDOM OBJECTS
    int select;

    // GAMEOBJECT TO HOLD SPHERES
    public GameObject sphere;

    // GAMEOBJECT TO HOLD CUBES
    public GameObject cube;
    

    // A Vector3 that determines the bounds of where our GameObject gets instantiated
    public Vector3 limit = new Vector3(5, 5, 5);

    // WE WANT TO ADD A SERIES OF GLOBAL VARIABLES
    [Header("Flock Attributes")]
    [Range(0.0f, 5.0f)]             // Min speed of flocking object
    public float minSpeed;
    [Range(0.0f, 5.0f)]             // Max speed of flocking object
    public float maxSpeed;
    [Range(1.0f, 10.0f)]            // Radius of exterior sphere
    public float neighborDistance;
    [Range(1.0f, 5.0f)]             // Radius of interior sphere
    public float comfortDistance;
    [Range(1.0f, 100.0f)]           // Distance flock keeps from Predator Object
    public float predatorDistance;  


    // Goal
    // dBounding Limit

    // Start is called before the first frame update
    void Start()
    {
        // place the number of objects from our numOBJ into our allFlockOBJ array
        allFlockOBJ = new GameObject[numOBJ];

        

        // for loop
        for (int i = 0; i < numOBJ; i++)
        {
            // generate a random point
            Vector3 pos = this.transform.position = new Vector3(Random.Range(-limit.x, limit.x),
                                                                Random.Range(-limit.y, limit.y),
                                                                Random.Range(-limit.z, limit.z));
                                                              

            Vector3 scale = new Vector3(Random.Range(0.1f, 1), Random.Range(0.1f, 1), Random.Range(0.1f, 1));

            // GENERATE RANDOM SELECTION OF SHAPES BETWEEN SPHERES AND CUBES
            select = Random.Range(1, 3);

            // IF STATEMENT FOR INPUTTING EACH SHAPE WHEN ONE OR TWO IS SELECTED
            if (select == 1)
            {
                // place our CUBE on the generated point
                allFlockOBJ[i] = (GameObject)Instantiate(cube, pos, Quaternion.identity);
            }

            else
            {
                // place our SPHERE on the generated point
                allFlockOBJ[i] = (GameObject)Instantiate(sphere, pos, Quaternion.identity);
            }
            

            // place the instantiated object as the child of an empty GameObject to keep our Hierarchy organized
            allFlockOBJ[i].transform.parent = FlockContainer.transform;

            // add the FlockManager to the object being instantiated
            allFlockOBJ[i].GetComponent<flockMove>().managerForThisObject = this;

            // How could we instantiate these objects at different scales
            // allFlockOBJ[i].transform.localScale = new Vector3(Random.Range(-limit.x, limit.x),
                                                            //  Random.Range(-limit.y, limit.y),
                                                            //  Random.Range(-limit.z, limit.z));

        }
    }
    // generate a random point


    // place our random GameObject on the generated point

    // Update is called once per frame
    void Update()
    {
    
    }
}
