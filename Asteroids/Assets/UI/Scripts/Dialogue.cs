using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "DialogueSystem/Dialogue", order = 1)]
public class Dialogue : ScriptableObject
{
    [SerializeField]
    private string[] dialogueLines;

    public string GetText()
    {
        string dialogueString = "";

        foreach(string line in dialogueLines)
        {
            dialogueString += line + "\n";
        }
        return dialogueString;
    }
}
