using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{

    public GameObject[] p1Character;
    public GameObject[] p2Character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void P1FaunSelect()
    {
        foreach (var c in p1Character)
        {
            c.SetActive(false);
        }

        p1Character[0].SetActive(true);
        GameManager.SingletonInstance.updatePlayer1Character(0);
    }

    public void P1GhoulSelect()
    {
        foreach (var c in p1Character)
        {
            c.SetActive(false);
        }

        p1Character[1].SetActive(true);
        GameManager.SingletonInstance.updatePlayer1Character(1);
    }

    public void P1SkeletonSelect()
    {
        foreach (var c in p1Character)
        {
            c.SetActive(false);
        }

        p1Character[2].SetActive(true);
        GameManager.SingletonInstance.updatePlayer1Character(2);
    }

    public void P1WerewolfSelect()
    {
        foreach (var c in p1Character)
        {
            c.SetActive(false);
        }

        p1Character[3].SetActive(true);
        GameManager.SingletonInstance.updatePlayer1Character(3);
    }

    public void P2FaunSelect()
    {
        foreach (var c in p2Character)
        {
            c.SetActive(false);
        }

        p2Character[0].SetActive(true);
        GameManager.SingletonInstance.updatePlayer2Character(0);
    }

    public void P2GhoulSelect()
    {
        foreach (var c in p2Character)
        {
            c.SetActive(false);
        }

        p2Character[1].SetActive(true);
        GameManager.SingletonInstance.updatePlayer2Character(1);
    }

    public void P2SkeletonSelect()
    {
        foreach (var c in p2Character)
        {
            c.SetActive(false);
        }

        p2Character[2].SetActive(true);
        GameManager.SingletonInstance.updatePlayer2Character(2);
    }

    public void P2WerewolfSelect()
    {
        foreach (var c in p2Character)
        {
            c.SetActive(false);
        }

        p2Character[3].SetActive(true);
        GameManager.SingletonInstance.updatePlayer2Character(3);
    }
}
