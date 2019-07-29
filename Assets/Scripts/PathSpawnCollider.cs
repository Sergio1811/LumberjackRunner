using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSpawnCollider : MonoBehaviour
{
    public float positionY = 0.81f;
    public Transform[] PathSpawnPoints;
    public GameObject Path;
    public GameObject DangerousBorder;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Blackboard.PlayerTag))
        {
            int l_RandomSpawnPoint = Random.Range(0, PathSpawnPoints.Length);
            for (int i = 0; i < PathSpawnPoints.Length; i++)
            {
                if (i==l_RandomSpawnPoint)
                {
                    Instantiate(Path, PathSpawnPoints[i].position, PathSpawnPoints[i].rotation);
                }
                else
                {
                    Vector3 l_Rotation = PathSpawnPoints[i].rotation.eulerAngles;
                    l_Rotation.y += 90;
                    Vector3 l_Position = PathSpawnPoints[i].position;
                    l_Position.y += positionY;
                    Instantiate(DangerousBorder, l_Position, Quaternion.Euler(l_Rotation));
                }
            }
        }
    }
}
