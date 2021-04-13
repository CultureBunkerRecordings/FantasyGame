using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager singltonInstance;

    public GameObject TitleScreen;
    public GameObject PauseScreen;
    public TextMeshProUGUI p1PotionsText;
    public TextMeshProUGUI p2PotionsText;
    public TextMeshProUGUI TimerText;
    public bool gamePlaying = false;
    public bool gamePaused = false;
    public int p1Potions;
    public int p2Potions;
    public int p1Health;
    public int p2Health;
    public int maxHeath = 12;
    public GameObject[] p1HealthSprites;
    public GameObject[] p1Heads;

    public GameObject[] p2HealthSprites;
    public GameObject[] p2Heads;

    public float dayTime = 6;
    public float nightTime = 0;

    SceneSwitcher switcher;
    bool hasSwitched = false;

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
        switcher = GameObject.Find("SceneSwitcher").GetComponent<SceneSwitcher>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gamePlaying)
        {
            timer();
        }
    }


    public void playGame()
    {
        if(TitleScreen != null && !gamePaused)
        {
            //updateP1Potions(12);
            //updateP2Potions(12);
            updateP1Health(p1Health);
            updateP2Health(p2Health);
            TitleScreen.SetActive(false);
        }

        gamePlaying = true;
    }

    public void timer()
    {
        var formattedTime = DateTime.Now.ToString("HH:mm");
        TimerText.text = formattedTime;
        float hours = Mathf.Round(float.Parse(formattedTime.Substring(0, 2)));
        /*if (hours >= nightTime)
        {
            switcher.loadScenNum(3);
            hasSwitched = true;
        }
        else
        {
            hasSwitched = false;
        }*/

    }

    public void pauseGame()
    {
        gamePlaying = false;
        gamePaused = true;
        PauseScreen.SetActive(true);
    }


    public void updateP1Potions(int potionsToAdd)
    {
        p1Potions = potionsToAdd;
        p1PotionsText.SetText("Potions: " + p1Potions);
    }

    public void updateP2Potions(int potionsToAdd)
    {
        p2Potions = potionsToAdd;
        p2PotionsText.SetText("Potions: " + p2Potions);
    }

    public void updateP1Health(int healthToAdd)
    {
        for (int i = 0; i < p1HealthSprites.Length; i++)
        {
            p1HealthSprites[i].SetActive(false);
        }

        for (int i = 0; i < healthToAdd; i++)
        {
            p1HealthSprites[i].SetActive(true);
        }
    }

    public void updateP2Health(int healthToAdd)
    {
        for (int i = 0; i < p2HealthSprites.Length; i++)
        {
            p2HealthSprites[i].SetActive(false);
        }

        for (int i = 0; i < healthToAdd; i++)
        {
            p2HealthSprites[i].SetActive(true);
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

    public void quitGame()
    {
        Application.Quit();
    }
}


