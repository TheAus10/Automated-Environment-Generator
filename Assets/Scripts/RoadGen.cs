using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGen : MonoBehaviour
{

    public GameObject[] roadPrefabs;        // holds types of roads
    public Transform startPos;              // start of initial plane - needs to be somehow set to 0,0,0 always
    int segmentLength = 505;                // length of 1 segment + 5 for initial length of start segment
    int nextPos = 0;                        // value of next segment position on Z-axis
    int numSegments = 100;                  // number of segments user wants to place

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numSegments; i++)
        {
            // setting position of next segment
            nextPos += segmentLength;

            // creating a new random piece at coords [0,0,nextPos]
            Instantiate(roadPrefabs[Random.Range(0, roadPrefabs.Length)], new Vector3(startPos.position.x, startPos.position.y, startPos.position.z + nextPos), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*** Remove for loop and put code in here to make infinite ***/
    }
}
