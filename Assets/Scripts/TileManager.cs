/*
 * Jeff McCluckerson - TileManager.cs 
 * Spawns, deletes and keeps track of all tiles in current game scene
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs; // how many different tile styles we have
                                     // Change size in Unity
    private List<GameObject> activeTiles; // a list of all tiles in Scene
    private Transform playerTransform; // to retrieve player position

    private float spawnZ; // where to spawn the next tile
    private float tileLength; // how long a tile is - 
                              // IMPORTANT! - ALL TILES MUST BE SAME Z LENGTH
    private float safeZone; // how much distance should Jeff should be from tile that is being deleted
    private int tilesOnScreen; // how many tiles should be spawned ahead of Jeff
    private int lastPrefabIndex;

    // Start is called before the first frame update
    void Start()
    {
        activeTiles = new List<GameObject>();
        tilesOnScreen = 10;
        tileLength = 30.0f;
        spawnZ = -30.0f;
        safeZone = 60.0f;
        lastPrefabIndex = 0;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
        // spawn initial tiles based on how many are allowed to be on screen
        for(int i = 0; i < tilesOnScreen; i++)
        {
            if (i < 3)
                SpawnTile(0);
            else
                SpawnTile();
        }

    }

    // Update is called once per frame
    void Update()
    {
        // spawn a tile in front of Jeff when he gets to a certain point
        // delete a tile behind Jeff when he gets to a certain point
        if(playerTransform.position.z - safeZone > (spawnZ - tilesOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
            
    }

    // Spawn a tile
    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject obj;
        if (prefabIndex == -1)
            obj = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        else
            obj = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
        obj.transform.SetParent(transform); // set the tile's parent to be TileManager
        obj.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(obj);
    }

    // Destroy a tile behind Jeff
    private void DeleteTile()
    {
        Destroy(activeTiles[0]); // destroy the tile in the Scene
        activeTiles.RemoveAt(0); // remove its content from the list
    }
    
    private int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
            return 0;
        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
