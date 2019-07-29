using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDestroyer : MonoBehaviour
{

    public float LifeTime = 10f;

    void Start()
    {
        Invoke("DestroyObject", LifeTime);
    }

    void DestroyObject()
    {
        if (GameManager.Instance.GameState != GameState.Dead)
            Destroy(gameObject);
    }

    
}
