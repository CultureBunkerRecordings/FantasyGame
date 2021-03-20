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
    public int p1Health;
    public int p2Health;

    public GameObject[] p1HealthSprites;
    public GameObject[] p1Heads;

    public GameObject[] p2HealthSprites;
    public GameObject[] p2Heads;

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
            updateP1Health(p1Health);
            updateP2Health(p2Health);
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

    public void updateP1Health(int healthToAdd)
    {
        foreach (var health in p1HealthSprites)
        {
            health.SetActive(false);
        }
        if(healthToAdd >= 0)
        {
            p1HealthSprites[healthToAdd].SetActive(true);
        }
    }

    public void updateP2Health(int healthToAdd)
    {
        foreach (var health in p2HealthSprites)
        {
            health.SetActive(false);
        }
        if (healthToAdd >= 0)
        {
            p2HealthSprites[healthToAdd].SetActive(true);
        }
    }

    public void updatePlayer1Character(int headNum)
    {
        foreach(var head in p1Heads)
        {
            head.SetActive(false);
        }

        p1Heads[headNum].SetActive(true);
    }

    public void updatePlayer2Character(int headNum)
    {
        foreach (var head in p2Heads)
        {
            head.SetActive(false);
        }

        p2Heads[headNum].SetActive(true);
    }
}
