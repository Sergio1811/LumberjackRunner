using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public UIManager UI;
    public GameObject Player;
    public InitializeAdsScript Ads;

    protected GameManager()
    {
        GameState = GameState.Start;
        CanSwipe = false;
    }

    public GameState GameState { get; set; }

    public bool CanSwipe { get; set; }

    public void Die()
    {
        UI.SetStatus(Blackboard.StatusDeadTapToStart);
        this.GameState = GameState.Dead;
        Ads.ShowInterstitialAdd();
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(this);
        }

        Player = GameObject.FindGameObjectWithTag(Blackboard.PlayerTag);
    }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }

    private void Start()
    {
        UI = FindObjectOfType<Canvas>().GetComponent<UIManager>();
    }


}
