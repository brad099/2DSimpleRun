using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;
    public Transform tf;
    public float spawnrate = 5f;
    public float spawnTime;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime)
        {
        GameObject go = Instantiate(obstacle,tf.position,Quaternion.identity);
        spawnTime = Time.time + spawnrate; 
        Destroy(go,2f);
        }
    }
}
