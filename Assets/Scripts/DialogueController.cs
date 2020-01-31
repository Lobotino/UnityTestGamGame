using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public GameObject DialougeUI;
    public Dialogue[] dialogue;
    public int _currentNode;
    public bool ShowDialogue = false;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

  
    public void OnGUI()
    {
        if (ShowDialogue) {
            GUI.Box (new Rect (Screen.width / 2 - 300, Screen.height - 300, 600, 250), "");
            GUI.Label (new Rect (Screen.width / 2 - 250, Screen.height - 280, 500, 90), dialogue [_currentNode].DialogueText);
            for (int i = 0; i < dialogue [_currentNode].Answers.Length; i++) {
                if (GUI.Button (new Rect (Screen.width / 2 - 250, Screen.height - 200 + 25 * i, 500, 25), dialogue [_currentNode].Answers [i].AnswerText)) {
                    if (dialogue [_currentNode].Answers [i].IsCloseAnswer) {
                        ShowDialogue = false;
                    }
                    _currentNode = dialogue [_currentNode].Answers [i].ToNode;
                }
            }
        }
    }

    [System.Serializable]
    public class Answer
    {
        public string AnswerText;
        public int ToNode;
        public bool IsCloseAnswer = false;
    }

    [System.Serializable]
    public class Dialogue
    {
        public Answer[] Answers;
        public string DialogueText;
    }
}
