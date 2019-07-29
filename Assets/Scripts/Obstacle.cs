using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Blackboard.Axe))
        {
            if (other.gameObject.GetComponent<Axe>().inAttack)
            {
                Destroy(this.gameObject);
                GameManager.Instance.UI.IncreaseScore(100);
            }
        }

        if (other.gameObject.CompareTag(Blackboard.PlayerTag))
        {
            GameManager.Instance.Die();
        }
    }
}
