using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class bitSetter : MonoBehaviour
{

    public int bitSequence = 0; // Create an int variable here to store our integer

    static public int height = 1;
    static public int power = 2;
    static public int health = 4;
    static public int speed = 8;
    static public int stamina = 16;

    public int attribute = 0;

    // Start is called before the first frame update
    void Start()
    {
        //attribute = height + power;
        //attribute = speed | stamina;
        //attribute = health ~power;
        //attribute = stamina ^ height;

        //attribute = GetComponent<PopulationManagerScript>().s1;

        Debug.Log(Convert.ToString(attribute, 2));

        //Debug.Log(Convert.ToString(bitSequence, 2)); // Printing to console
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(Convert.ToString(bitSequence, 2)); // Print the value to the console
    }
}
