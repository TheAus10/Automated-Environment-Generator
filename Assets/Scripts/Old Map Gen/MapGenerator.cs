﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GridVisualizer gridVisualizer;
    public MapVisualizer mapVisualizer;

    public Direction startEdge, exitEdge;
    public bool randomPlacement;
    [Range(1, 50)]
    public int numberOfPieces;

    public bool visualizeUsingPrefabs = false;
    public bool autoRepair = true;

    private Vector3 startPosition, exitPosition;
    private CandidateMap map;
    
    [Range(3,20)]
    public int width, length = 11;
    private MapGrid grid;
    // Start is called before the first frame update
    void Start()
    {
        
        gridVisualizer.VisualizeGrid(width, length);
        GenerateNewMap();
        
    }

    public void GenerateNewMap()
    {
        mapVisualizer.ClearMap();

        grid = new MapGrid(width, length);

        MapHelper.RandomlyChooseAndSetStartAndExit(grid, ref startPosition, ref exitPosition, randomPlacement, startEdge, exitEdge);

        map = new CandidateMap(grid, numberOfPieces);
        map.CreateMap(startPosition, exitPosition, autoRepair);
        mapVisualizer.VisualizeMap(grid,map.ReturnMapData(), visualizeUsingPrefabs);
    }

    public void TryRepair()
    {
        if(map != null)
        {
            var listOfObstaclesToRemove = map.Repair();
            if(listOfObstaclesToRemove.Count > 0)
            {
                mapVisualizer.ClearMap();
                mapVisualizer.VisualizeMap(grid,map.ReturnMapData(), visualizeUsingPrefabs);
            }

        }
    }
}
