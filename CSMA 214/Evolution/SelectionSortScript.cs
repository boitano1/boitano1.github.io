using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionSortScript : MonoBehaviour
{
    // VARIABLES TO STORE OUR LIST OF NUMBERS
    public int[] listOfNumbers;

    public GameObject oneOBJ;

    public GameObject twoOBJ;

    // Start is called before the first frame update
    void Start()
    {
        SelectionSort(listOfNumbers);
    }

    // OUR SELECTION SORT ALGORITHM
    void SelectionSort(int[] unsortedList)
    {
        int min;  // use this to keep track of index of smallest number

        for (int i = 0; i < unsortedList.Length; i++)
        {
            min = i;
            int temp;

            for (int j = i + 1; j < unsortedList.Length; j++)
            {
                if (unsortedList[j] < unsortedList[min])
                {
                    min = j;
                }
            }


            if (min != i)
            {
                temp = unsortedList[i];
                unsortedList[i] = unsortedList[min];
                unsortedList[min] = temp;
                PrintArray(unsortedList);

                
            }
        }
    }

    void PrintArray(int[] someArrayOfNumbers)
    {
        string resultString = "";
        for (int i = 0; i < someArrayOfNumbers.Length; i++)
        {
            resultString = resultString + someArrayOfNumbers[i] + ", ";

            // oneOBJ
            Vector3 pos = this.transform.position = new Vector3(i, i * -1, i);
            oneOBJ = (GameObject)Instantiate(oneOBJ, pos, Quaternion.identity);

            Vector3 scale = this.transform.localScale = new Vector3(i, i, i);
            oneOBJ = (GameObject)Instantiate(oneOBJ, scale, Quaternion.identity);


            // twoOBJ
            Vector3 twopos = this.transform.position = new Vector3(i * -1, i * -1, i);
            twoOBJ = (GameObject)Instantiate(twoOBJ, twopos, Quaternion.identity);

            Vector3 twoscale = this.transform.localScale = new Vector3(i, i, i);
            twoOBJ = (GameObject)Instantiate(twoOBJ, twoscale, Quaternion.identity);
        }

        print(resultString);

        
    }

    void update()
    {
        
    }
}
