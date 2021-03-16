using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager singltonInstance;

    public GameObject TitleScreen;
    public TextMeshProUGUI ScoreText;
    public bool gamePlaying = false;
    public int score;

    public static GameManager SingletonInstance
    {
        get { return singltonInstance; }
    } 

    private void Awake()
    {
        if (singltonInstance != null && singltonInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            singltonInstance = this;
        }
        DontDestroyOnLoad(gameObject.transform);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void playGame()
    {
        if(TitleScreen != null)
        {
            updateScore(0);
            TitleScreen.SetActive(false);
        }
        
        gamePlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void updateScore(int scoreToAdd)
    {
        score = scoreToAdd;
        ScoreText.SetText("Potions: " + score);
    }
}
