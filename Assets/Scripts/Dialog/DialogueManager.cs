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

    // Start is called before the first frame update
    void Start()
    {
        Sentences = new Queue<string>();
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        sSWitcher = GameObject.Find("SceneSwitcher").GetComponent<SceneSwitcher>();

    }

    public void StartDialogue(Dialogue dialogue)
    {
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

        string sentence = Sentences.Dequeue();
        dialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        Debug.Log("End of Conversation");
        inDialogue = false;
        sSWitcher.SwitchScene();
    }

    public void isInDialogue()
    {
        inDialogue = true;
    }
}
