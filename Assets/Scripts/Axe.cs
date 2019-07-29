using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    //[HideInInspector]
    public bool inAttack;
    public float animTimer;
    public float currentTimer =0;
    private void Update()
    {
        if(inAttack)
        {
           // if(Vector3.Dot(GameManager.Instance.Player.transform.forward, ))
            currentTimer += Time.deltaTime;
            if (currentTimer >= animTimer)
                inAttack = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {/*
        print("trigger");
        if(inAttack)
        {
            print("inaattack");
            if (other.CompareTag("Breakable"))
            {
                print("breakable");
                Destroy(other.gameObject);
                print("CageBreaked");
            }
        }*/
    }
}
