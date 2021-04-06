using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGen : MonoBehaviour
{

    public GameObject[] roadPrefabs;        // holds types of roads
    public List<GameObject> usedRoads = new List<GameObject>();
    public Vector3 nextCoords;              // starting coordinates of map
    int segmentLength = 505;                // length of 1 segment + 5 for initial length of start segment
    int numSegments = 100;                  // number of segments user wants to place

    // Start is called before the first frame update
    void Start()
    {

        // setting start coords
        nextCoords = new Vector3(0, 0, 0);

        // adding one random segment for a specified length
        for (int i = 0; i < numSegments; i++)
        {
            // copying the array if it is empty
            if (usedRoads.Count == 0)
            {
                for(int j = 0; j < roadPrefabs.Length; j++)
                {
                    usedRoads.Add(roadPrefabs[j]);
                }
            }

            // getting a random index
            int index = Random.Range(0, usedRoads.Count);

            // creating a new random piece at nextCoords
            Instantiate(usedRoads[index], nextCoords, Quaternion.identity);

            // removing it from the list to avoid repeats
            usedRoads.RemoveAt(index);

            // setting position of next segment
            nextCoords.z += segmentLength;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*** Remove for loop and put code in here to make infinite ***/
    }
}
