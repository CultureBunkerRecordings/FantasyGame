using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> Sentences;
    public bool inDialogue = false;

    GameManager gManager;
    SceneSwitcher sSWitcher;

    public Text dialogueText;

    public GameObject screen1;
    public GameObject screen2;

    // Start is called before the first frame update
    void Start()
    {
        
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        sSWitcher = GameObject.Find("SceneSwitcher").GetComponent<SceneSwitcher>();

    }

    public void StartDialogue(Dialogue dialogue)
    {
        Sentences = new Queue<string>();
        isInDialogue();
        dialogueText.text = "Starting conversation with" + dialogue.name;
        Sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            Sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(Sentences.Count == 0)
        {
            EndDialogue();
            
            return;
        }

        if(Sentences.Count == 5)
        {
            screen1.SetActive(false);
            screen2.SetActive(true);
        }

        string sentence = Sentences.Dequeue();
        dialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        Debug.Log("End of Conversation");
        inDialogue = false;
        sSWitcher.nextScene();
    }

    public void isInDialogue()
    {
        inDialogue = true;
    }
}
