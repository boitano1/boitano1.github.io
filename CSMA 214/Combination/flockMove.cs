using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flockMove : MonoBehaviour
{

    public float speed = 5;
    public FlockManager managerForThisObject;
    public GameObject Predator;
    GameObject predator;

    // Start is called before the first frame update
    void Start()
    {
        predator = managerForThisObject.Predator;

        speed = Random.Range(managerForThisObject.minSpeed, managerForThisObject.maxSpeed);

        
    }

    // Update is called once per frame
    void Update()
    {
        

        MoveRules();
        transform.Translate(0, 0, Time.deltaTime * speed); 
    }

    void MoveRules()
    {


        GameObject[] gOs;
        gOs = managerForThisObject.allFlockOBJ;

        // CENTER OF GROUP  : VECTOR3
        Vector3 vCenter = Vector3.zero;

        // AVOID DIRECTION  : VECTOR3
        Vector3 vAvoid = Vector3.zero;

        // GROUP SPEED      : FLOAT
        float groupSpeed = 0.01f;

        // NEIGHBORDISTANCE : FLOAT
        float neighborDistance;

        // PREDATORDISTANCE : FLOAT
        float predatorDistance;

        // GROUP SIZE       : INT
        int groupSize = 0;

        foreach (GameObject go in gOs)
        {
            if (go != this.gameObject)
            {
                // CALCULATE THE DISTANCE BETWEEN THIS OBJECT AND (go) : Vector3.Distance
                neighborDistance = Vector3.Distance(go.transform.position, this.transform.position);

                // IF THE OTHER OBJECT IS INSIDE OF THE NEIGHNOR DISTANCE RUN THIS
                if (neighborDistance <= managerForThisObject.neighborDistance)
                {
                    // CALCULATE VCENTER
                    vCenter += go.transform.position;

                    // ADD TO GROUP
                    groupSize++;
                }

                // IF THE OTHER OBJECT IS INSIDE OF THE NEIGHBORDISTANCE AND INSIDE OF THE
                // CALCULATE AVOID
                if (neighborDistance < managerForThisObject.comfortDistance)
                {
                    vAvoid = vAvoid + (this.transform.position - go.transform.position);
                }

                // DEFINE GROUP SPEED
                flockMove anotherFlockMove = go.GetComponent<flockMove>();
                groupSpeed = groupSpeed + anotherFlockMove.speed;


                // CALCULATE THE DISTANCE BETWEEN PREDATOR AND (go) : Vector3.Distance 
                predatorDistance = Vector3.Distance(go.transform.position, Predator.transform.position);

                // IF STATEMENT TO MAKE FLOCK KEEP A DISTANCE FROM THE PREDATOR WHEN PREDATOR COMES NEAR
                if (predatorDistance <= managerForThisObject.neighborDistance + 30)
                {
                    // FLOCKS AVOIDS PREDATOR
                    vAvoid = vAvoid + (go.transform.position - Predator.transform.position);
                }
                
            }
        }

        // IF THE GROUP IS BIGGER THAN 0
        if (groupSize > 0)
        {
             

            // CALCULATE THE CENTER OF THE OBJECTS GROUP
            vCenter = vCenter / groupSize;

            // CALCULATE THE SPEED OF THE GROUP AS AN AVERAGE OF ALL SPEEDS FROM GROUP MEMBERS
            speed = groupSize / groupSize;

            // DEFINE THE DIRECTION OF TRAVEL AS 
            Vector3 direction = (vCenter + vAvoid) - transform.position;

            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation,
                                                      Quaternion.LookRotation(direction),
                                                      Time.deltaTime);
            }
        }



    }

}
