using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFadeInOut : MonoBehaviour
{
    CanvasGroup TalkTextBox;
    public bool isTextFadeIn = false;
    public bool isTextFadeOut = false;

    readonly float MaxTextalpha = 1f;
    readonly float MinTextalpha = 0f;

    private void Start()
    {
        TalkTextBox = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isTextFadeIn)
        {
            StartTextFadeIn();
        }

        if (isTextFadeOut)
        {
            StartTextFadeOut();
        }
    }

    public void StartTextFadeOut()
    {
        if (TalkTextBox.alpha < MaxTextalpha)
        {
            TalkTextBox.alpha += Time.deltaTime;
            if (TalkTextBox.alpha >= MaxTextalpha)
            {
                isTextFadeOut = false;
            }
        }
    }

    public void StartTextFadeIn()
    {
        if (TalkTextBox.alpha >= MinTextalpha)
        {
            TalkTextBox.alpha -= Time.deltaTime;
            if (TalkTextBox.alpha == MinTextalpha)
            {
                isTextFadeIn = false;
            }
        }
    }
}
