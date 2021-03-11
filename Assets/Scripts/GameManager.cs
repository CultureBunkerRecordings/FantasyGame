using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject TitleScreen;
    public TextMeshProUGUI Score;
    public bool gamePlaying = false;
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
        Score.SetText("Score: " + scoreToAdd);
    }
}
