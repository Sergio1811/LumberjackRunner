using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBorder : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.CompareTag(Blackboard.PlayerTag))
        {
            GameManager.Instance.Die();
        }
    }
}
