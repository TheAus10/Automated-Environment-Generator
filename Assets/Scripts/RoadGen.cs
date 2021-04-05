using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGen : MonoBehaviour
{

    public GameObject[] roadPrefabs;        // holds types of roads
    public Vector3 nextCoords;              // starting coordinates of map
    int segmentLength = 505;                // length of 1 segment + 5 for initial length of start segment
    int numSegments = 100;                  // number of segments user wants to place

    // Start is called before the first frame update
    void Start()
    {

        // setting start coords
        nextCoords = new Vector3(0, 0, 0);

        for (int i = 0; i < numSegments; i++)
        {
            // creating a new random piece at nextCoords
            Instantiate(roadPrefabs[Random.Range(0, roadPrefabs.Length)], nextCoords, Quaternion.identity);

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
