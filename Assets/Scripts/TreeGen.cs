using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGen : MonoBehaviour
{
    public GameObject[] trees;                                  // list of building prefabs

    // Start is called before the first frame update
    void Start()
    {

        // picks a random building and spawns it at the SpawnPoint position that the script is attatched to
        int treeNum = Random.Range(0, trees.Length);
        Instantiate(trees[treeNum], transform.position, Quaternion.identity);
    }
}
