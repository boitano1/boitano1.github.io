using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Linq;
using System;

public class PopulationManagerScript : MonoBehaviour
{
    public GameObject OBJInstantiate;
    public int populationSize = 10;
    List<GameObject> population = new List<GameObject>();

    public int min = -5;
    public int max = 5;

    public float landscapeRef;
    public GameObject updateLand;

    public int minScale = 1;
    public int maxScale = 3;

    public int trialTime = 5;  // how much time we have to select our objects
    public int trialTime2 = 7;
    int generation = 1;  // what generation we are on
    public static float elapsed = 0;

    GUIStyle guiStyle = new GUIStyle();

    float survivor1 = 0;
    float survivor2 = 0;

    GameObject s1;
    GameObject s2;

    bool canSelect = true;


    public GameObject FlockContainer;


    // public int bitSequence = 0; // Create an int variable here to store our integer
    // public int attribute = 0;


    // Displays info about our generation system
    void OnGUI()
    {
        guiStyle.fontSize = 50;
        guiStyle.normal.textColor = Color.white;
        GUI.Label(new Rect(10, 10, 100, 20), "Generation: " + generation, guiStyle);
        GUI.Label(new Rect(10, 65, 100, 20), "Trial Time: " + (int)elapsed, guiStyle);
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < populationSize; i++)
        {

            // Generate a random position
            Vector3 pos = new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max));

            // Generate a new scale
            Vector3 scale = new Vector3(Random.Range(minScale, maxScale), Random.Range(minScale, maxScale), Random.Range(minScale, maxScale));

            // place our CUBE on the generated point
            GameObject gO = (GameObject)Instantiate(OBJInstantiate, pos, Quaternion.identity);

            gO.transform.localScale = scale;

            // Define certain variables of the GameObject
            gO.GetComponent<DNAScript>().r = Random.Range(0.0f, 1.0f);
            gO.GetComponent<DNAScript>().g = Random.Range(0.0f, 1.0f);
            gO.GetComponent<DNAScript>().b = Random.Range(0.0f, 1.0f);

            // Define certain variables of the GameObject
            gO.GetComponent<DNAScript>().x = scale.x;
            gO.GetComponent<DNAScript>().y = scale.y;
            gO.GetComponent<DNAScript>().z = scale.z;

            // Add gameobject to our list called population
            population.Add(gO);

            if (gO.GetComponent<DNAScript>().b > survivor1)
            {
                survivor1 = gO.GetComponent<DNAScript>().b;
                s1 = gO;
            }

            else if (gO.GetComponent<DNAScript>().g > survivor2)
            {
                survivor2 = gO.GetComponent<DNAScript>().g;
                s2 = gO;
            }


            /*
            select = Random.Range(1, 3);
  
            if (select == 1)
            {
                // place our CUBE on the generated point
                GameObject gO = (GameObject)Instantiate(cube, pos, Quaternion.identity);

                gO.transform.localScale = scale;

                // Define certain variables of the GameObject
                gO.GetComponent<DNAScript>().r = Random.Range(0.0f, 1.0f);
                gO.GetComponent<DNAScript>().g = Random.Range(0.0f, 1.0f);
                gO.GetComponent<DNAScript>().b = Random.Range(0.0f, 1.0f);

                // Define certain variables of the GameObject
                gO.GetComponent<DNAScript>().x = scale.x;
                gO.GetComponent<DNAScript>().y = scale.y;
                gO.GetComponent<DNAScript>().z = scale.z;

                // Add gameobject to our list called population
                population.Add(gO);

                if (gO.GetComponent<DNAScript>().b > survivor1)
                {
                    survivor1 = gO.GetComponent<DNAScript>().b;
                    s1 = gO;
                }

                else if (gO.GetComponent<DNAScript>().g > survivor2)
                {
                    survivor2 = gO.GetComponent<DNAScript>().g;
                    s2 = gO;
                }
            }

            else
            {
                // place our SPHERE on the generated point
                GameObject gO = (GameObject)Instantiate(sphere, pos, Quaternion.identity);

                gO.transform.localScale = scale;

                // Define certain variables of the GameObject
                gO.GetComponent<DNAScript>().r = Random.Range(0.0f, 1.0f);
                gO.GetComponent<DNAScript>().g = Random.Range(0.0f, 1.0f);
                gO.GetComponent<DNAScript>().b = Random.Range(0.0f, 1.0f);

                // Define certain variables of the GameObject
                gO.GetComponent<DNAScript>().x = scale.x;
                gO.GetComponent<DNAScript>().y = scale.y;
                gO.GetComponent<DNAScript>().z = scale.z;

                // Add gameobject to our list called population
                population.Add(gO);

                if (gO.GetComponent<DNAScript>().b > survivor1)
                {
                    survivor1 = gO.GetComponent<DNAScript>().b;
                    s1 = gO;
                }

                else if (gO.GetComponent<DNAScript>().g > survivor2)
                {
                    survivor2 = gO.GetComponent<DNAScript>().g;
                    s2 = gO;
                }
            }
            */

            // Instantiate the GameObject
            // GameObject gO = Instantiate(OBJInstantiate, pos, Quaternion.identity);


        }
        // OBJInstantiate.transform.parent = FlockContainer.transform;


    }

    GameObject Breed(GameObject parent1, GameObject parent2)
    {
        // position
        Vector3 pos = new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max));

        // scale
        Vector3 scale = new Vector3(Random.Range(minScale, maxScale), Random.Range(minScale, maxScale), Random.Range(minScale, maxScale));

        // define another variable that combines the rotation of both parents

        // offspring
        GameObject offspring = Instantiate(OBJInstantiate, pos, Quaternion.identity);

        // dna of parent 1
        DNAScript dna1 = parent1.GetComponent<DNAScript>();

        // dna of parent 2
        DNAScript dna2 = parent2.GetComponent<DNAScript>();

        // Color
        // r
        float nR = (dna1.r + dna2.r) / 2;

        // g
        float nG = (dna1.g + dna2.g) / 2;

        // b
        float nB = (dna1.b + dna2.b) / 2;

        // Scale
        // x
        float nX = (dna1.x + dna2.x) / 2;

        // y
        float nY = (dna1.y + dna2.y) / 2;

        // z
        float nZ = (dna1.z + dna2.z) / 2;

        // adding the values that we have created by mixing parents to the offspring
        offspring.GetComponent<DNAScript>().r = nR;
        offspring.GetComponent<DNAScript>().g = nG;
        offspring.GetComponent<DNAScript>().b = nB;

        offspring.GetComponent<DNAScript>().x = nX;
        offspring.GetComponent<DNAScript>().y = nY;
        offspring.GetComponent<DNAScript>().z = nZ;

        offspring.transform.localScale = new Vector3(nX, nY, nZ);

        if (offspring.GetComponent<DNAScript>().b > survivor1)
        {
            survivor1 = offspring.GetComponent<DNAScript>().b;
            s1 = offspring;
            //attribute = offspring.GetComponent<DNAScript>().b;
        }

        else if (offspring.GetComponent<DNAScript>().g > survivor2)
        {
            survivor2 = offspring.GetComponent<DNAScript>().g;
            s2 = offspring;
            //attribute = offspring.GetComponent<DNAScript>().g;
        }
        landscapeRef = nB;
        print(landscapeRef);

        return offspring;
    }

    void SelfSelection()
    {
        s1.GetComponent<DNAScript>().Die();
        s2.GetComponent<DNAScript>().Die();
    }

    void BreedNewPopulation()
    {
        List<GameObject> newPopulation = new List<GameObject>();

        List<GameObject> sortedList = population.OrderBy(o => o.GetComponent<DNAScript>().timeToDie).ToList();

        population.Clear();

        survivor1 = 0;
        survivor2 = 0;

        // breed upper half of sorted list
        for (int i = (int)(sortedList.Count / 2.0f) - 1; i < sortedList.Count - 1; i++)
        {
            population.Add(Breed(sortedList[i], sortedList[i + 1]));
            population.Add(Breed(sortedList[i + 1], sortedList[i]));
        }

        for (int i = 0; i < sortedList.Count; i++)
        {
            Destroy(sortedList[i]);
        }

        updateLand.GetComponent<LandscapeGeneratorTwo>().CreateMesh();

        generation++;
    }

    // Update is called once per frame
    void Update()
    {
        // FlockContainer.transform.position = transform.position + new Vector3(Mathf.Sin(Time.time), Mathf.Sin(Time.time), Mathf.Cos(Time.time));
        elapsed += Time.deltaTime;
        if (elapsed > trialTime && canSelect == true)
        {
            SelfSelection();
            canSelect = false;
        }

        if (elapsed > trialTime2)
        {
            BreedNewPopulation();
            canSelect = true;
            elapsed = 0;
        }

        // attribute = gO.GetComponent<DNAScript>().b + gO.GetComponent<DNAScript>().g;

        // Debug.Log(Convert.ToString(attribute, 2));
    }
}
