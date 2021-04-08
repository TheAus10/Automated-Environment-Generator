using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGen : MonoBehaviour
{

    public GameObject[] roadPrefabs;                                // holds types of roads
    public GameObject ground;                                       // ground filler prefab
    public List<GameObject> unusedRoads = new List<GameObject>();   // copy of roads that haven't been used yet
    public Vector3 nextCoords;                                      // coordinates of next road segment to be placed
    public Vector3 groundCoords;                                    // coordinates of next ground tile to be placed
    int segmentLength = 505;                                        // length of 1 segment + 5 for initial length of start segment
    int numSegments = 100;                                          // number of segments user wants to place

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
                for(int j = 0; j < roadPrefabs.Length; j++)
                {
                    unusedRoads.Add(roadPrefabs[j]);
                }
            }

            // getting a random index
            int index = Random.Range(0, unusedRoads.Count);

            // creating a new random piece at nextCoords
            Instantiate(unusedRoads[index], nextCoords, Quaternion.identity);

            // removing it from the list to avoid repeats
            unusedRoads.RemoveAt(index);

            // setting position of next segment
            nextCoords.z += segmentLength;
        }

        groundCoords = new Vector3(-300.0f, -0.1f, -5.0f);

        // setting up ground outside of roads
        for(float x = -300.0f; x < 300.0f; x += 7.5f)
        {
            for(float z = -5.0f; z < (nextCoords.z + 10.0f); z += 7.5f)
            {
                // placing in ground tile
                Instantiate(ground, groundCoords, Quaternion.identity);

                // increasing z axis
                groundCoords.z = z;
            }

            // increasing x axis
            groundCoords.x = x;
        }

    }

    // Update is called once per frame
    void Update()
    {
        /*** Remove for loop and put code in here to make infinite ***/
    }
}
