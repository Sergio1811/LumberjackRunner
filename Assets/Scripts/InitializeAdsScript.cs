using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InitializeAdsScript : MonoBehaviour
{
    string gameIDGoogle = "3230079";
    string gameIDApple = "3230078";
    public bool testMode;

    void Start()
    {
        Advertisement.Initialize(gameIDGoogle, testMode);
    }

    public void ShowInterstitialAdd()
    {
        Advertisement.Show();
        print("ADD");
    }
   
}
