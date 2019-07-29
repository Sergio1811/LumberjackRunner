using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLevel : MonoBehaviour
{
    void StraightLevelStart()
    {
        SceneManager.LoadScene("StraightPathLevel");
    }

    void RotatedLevelStart()
    {
        SceneManager.LoadScene("RotatingPathLevel");
    }
}
