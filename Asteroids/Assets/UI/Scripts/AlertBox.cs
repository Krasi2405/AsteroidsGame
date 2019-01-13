using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertBox : MonoBehaviour
{
    [SerializeField]
    private Text alertText;

    [SerializeField]
    private float defaultFlashDuration = 3f;

    [SerializeField]
    private float blinkDuration = 0.25f;

    private void Start()
    {
        DisableChildren();
    }

    public void Flash(string text)
    {
        Flash(text, defaultFlashDuration);
    }

    public void Flash(string text, float duration)
    {
        alertText.text = text;
        StartCoroutine(FlashCoroutine(duration));
    }

    private IEnumerator FlashCoroutine(float duration)
    {
        float currentDuration = 0;
        while(currentDuration < duration)
        {
            EnableChildren();
            yield return new WaitForSeconds(blinkDuration);
            DisableChildren();
            yield return new WaitForSeconds(blinkDuration);
            currentDuration += blinkDuration * 2;
        }
    }

    private void DisableChildren()
    {
        for(int i = 0; i < transform.childCount; i++)
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
