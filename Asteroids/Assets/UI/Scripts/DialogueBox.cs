using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    [SerializeField]
    private Text text;

    private void Start()
    {
        DisableChildren();
    }

    public void ShowDialogue(Dialogue dialogue)
    {
        Time.timeScale = 0;
        text.text = dialogue.GetText();
        EnableChildren();
    }

    public void HideDialogue()
    {
        Time.timeScale = 1;
        DisableChildren();
    }


    private void DisableChildren()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void EnableChildren()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
