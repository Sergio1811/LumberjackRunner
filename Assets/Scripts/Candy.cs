using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    public float rotateSpeed = 50f;
    public int ScorePoints = 100;
    UIManager UI = GameManager.Instance.UI;
    private void Update()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * rotateSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        UI.IncreaseScore(ScorePoints);
        Destroy(this.gameObject);
    }
}
