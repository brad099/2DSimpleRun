using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] tiles;
    private Transform playerT;
    private float spawnX;
    private float spawnLenght = 64f;
    private int amount = 3;
    private List<GameObject> currentL; 
    private void Start() 
    {
          currentL = new List<GameObject>();
        // Finding Player
          playerT = GameObject.FindGameObjectWithTag ("Player").transform;

          //Spawn lanes per amount
          for (int i = 0; i < amount; i++)
          {
             Spawner();
          }
    }
    void Update()
    {
        //Calculate Distance
        if (playerT.transform.position.x - 64f >(spawnX - amount * spawnLenght))
        {
            Spawner();
            Deleting();
        }
    }

    private void Spawner()
    {
        // Instantiate
        GameObject go;
        go = Instantiate(tiles[0],transform.position,Quaternion.identity) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.right * spawnX;
        spawnX += spawnLenght;
        currentL.Add(go);
    }

     private void Deleting()
    {
        // Destroy Out of memory
        Destroy(currentL[0]);
        currentL.RemoveAt(0);
    }
    }
