using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 class TileManager : MonoBehaviour

{ 

     public GameObject[] tilePrefabs;
     private Transform playerTransform;
     public float tileLenght = 5.0f;
     public int amnTilesOnScreen = 2;
     private List<GameObject> activeTiles;
     private int lastPrefabIndex = 0;


        private void Start()
       {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < amnTilesOnScreen; i++)
        {
            if (i < 8)
        
                SpawnTile (0); 

            else 
                SpawnTile ();
        }
       }




    private void SpawnTile(int PrefabIndex = -1)
    {
        GameObject go;
        if (PrefabIndex == -1)
            go = Instantiate (tilePrefabs [RandomPrefabIndex()]) as GameObject;
        else
            go = Instantiate(tilePrefabs[PrefabIndex]) as GameObject;
        go.transform.SetParent (transform);
        go.transform.position = Vector3.right * 65f;
        activeTiles.Add (go);
    }   

    private void DeleteTile()
    {
        Destroy (activeTiles[0]);
        activeTiles.RemoveAt (0);
    }

    private int RandomPrefabIndex() 
    {
        if (tilePrefabs.Length <= 1)
            return 0;

        int randomIndex = lastPrefabIndex;  
        while (randomIndex == lastPrefabIndex)
        { 
            randomIndex = Random.Range (0, tilePrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }

    private void Update()
       {
        if (playerTransform.position.z - 65f > (65f - amnTilesOnScreen * tileLenght))
        {
            SpawnTile();
            DeleteTile();
        } 
       }
}