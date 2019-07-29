using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMaterial : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Renderer>().material = GetRandomMaterial();
    }

    public Material GetRandomMaterial()
    {
        int l_RandomNumber = Random.Range(0, 5);

        switch (l_RandomNumber)
        {
            case 0:
                return Resources.Load("Materials/RedColor") as Material;
            case 1:
                return Resources.Load("Materials/BlueColor") as Material;
            case 2:
                return Resources.Load("Materials/YellowColor") as Material;
            case 3:
                return Resources.Load("Materials/GreenColor") as Material;
            case 4:
                return Resources.Load("Materials/WhiteColor") as Material;
            default:
                return Resources.Load("Materials/PurpleColor") as Material;
        }
    }
}
