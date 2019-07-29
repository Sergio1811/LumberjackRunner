using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform[] ObstacleSpawnPoints;

    public GameObject[] Bonus;

    public GameObject[] Obstacles;

    public bool RandomX = false;
    public float minX = -2f, maxX = 2f;

    private void Start()
    {
        bool l_PlaceObstacle = Random.Range(0, 2) == 0; //50%
        int l_ObstacleIndex = -1;

        if (l_PlaceObstacle)
        {
            l_ObstacleIndex = Random.Range(1, ObstacleSpawnPoints.Length);

            CreateObject(ObstacleSpawnPoints[l_ObstacleIndex].position, Obstacles[Random.Range(0, Obstacles.Length)]);
        }

        for (int i = 0; i < ObstacleSpawnPoints.Length; i++)
        {
            if (i == l_ObstacleIndex)
                continue;
            if(Random.Range(0,3)==0)
            {
                CreateObject(ObstacleSpawnPoints[i].position, Bonus[Random.Range(0, Bonus.Length)]);
            }
        }
    }

    void CreateObject(Vector3 position, GameObject prefab)
    {
        if (RandomX)
        {
            position += new Vector3(Random.Range(minX, maxX),0,0);
        }

        Instantiate(prefab, position, Quaternion.identity);
    }
}
