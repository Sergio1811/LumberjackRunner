using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   // private static UIManager instance;
    private float Score = 0;
    public Text ScoreText;
    public Text StatusText;

   /* protected UIManager()
    {

    }*/

    private void Awake()
    {
       /* if (instance == null)
        {
            instance = null;
        }
        else
        {
            DestroyImmediate(this);
        }*/
    }

   /* public static UIManager Instance
    {
        get
        {
            if (instance == null)
                instance = new UIManager();

            return instance;
        }
    }*/

   
    public void ResetScore()
    {
        Score = 0;
        UpdateScoreText();
    }

    public void SetScore(float value)
    {
        Score = value;
        UpdateScoreText();
    }

    public void IncreaseScore(float value)
    {
        Score += value;
       UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        ScoreText.text = Score.ToString();
    }

    public void SetStatus(string text)
    {
        print(StatusText);
        StatusText.text = text;
    }
    
   
}
