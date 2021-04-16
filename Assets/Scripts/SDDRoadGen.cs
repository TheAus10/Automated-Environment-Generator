using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDDRoadGen : MonoBehaviour
{

    public GameObject[] roadPrefabs;                                // holds types of roads
    public GameObject ground;                                       // ground filler prefab
    public List<GameObject> unusedRoads = new List<GameObject>();   // copy of roads that haven't been used yet
    public Vector3 nextCoords;                                      // coordinates of next road segment to be placed
    public Vector3 groundCoords;                                    // coordinates of next ground tile to be placed
    public int segmentLength = 505;                                 // length of 1 segment + 5 for initial length of start segment
    public int numSegments = 5;                                   // number of segments user wants to place

    // Start is called before the first frame update
    void Start()
    {

        // setting start coords
        nextCoords = new Vector3(0, 0, 0);

        // adding one random segment for a specified length
        for (int i = 0; i < numSegments; i++)
        {
            // copying the array if it is empty
            if (unusedRoads.Count == 0)
            {
                for (int j = 0; j < roadPrefabs.Length; j++)
                {
                    unusedRoads.Add(roadPrefabs[j]);
                }
            }

            // getting a random index
            //int index = Random.Range(0, unusedRoads.Count);

            // creating a new random piece at nextCoords
            Instantiate(unusedRoads[i], nextCoords, Quaternion.identity);

            // removing it from the list to avoid repeats
            //unusedRoads.RemoveAt(i);

            // setting position of next segment
            nextCoords.z += segmentLength;

        }

        groundCoords = new Vector3(300.0f, -0.1f, 0.0f);

        // setting up ground outside of roads


        for (float z = 0.0f; z < nextCoords.z + 1000; z += 510f)
        {
            // placing in ground tile
            Instantiate(ground, groundCoords, Quaternion.identity);

            // increasing z axis
            groundCoords.z = z;
        }

    }

    // Update is called once per frame
    void Update()
    {
        /*** Remove for loop and put code in here to make infinite ***/
    }
}
