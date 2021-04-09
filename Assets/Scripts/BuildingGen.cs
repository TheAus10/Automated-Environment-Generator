using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGen : MonoBehaviour
{


    public GameObject[] buildings;                                  // list of building prefabs

    // Start is called before the first frame update
    void Start()
    {
        // picks a random building and spawns it at the SpawnPoint position that the script is attatched to
        int buildingNum = Random.Range(0, buildings.Length);
        Instantiate(buildings[buildingNum], transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
