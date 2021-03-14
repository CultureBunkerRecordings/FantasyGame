using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject TitleScreen;
    public TextMeshProUGUI ScoreText;
    public bool gamePlaying = false;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void playGame()
    {
        updateScore(0);
        TitleScreen.SetActive(false);
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
