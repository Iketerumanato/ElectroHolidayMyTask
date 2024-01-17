using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text TalkText;
    [SerializeField] string[] texts;
    int textNum;
    float textFadeSped = 0.01f;

    readonly float MinColor = 0f;
    readonly float MaxColor = 1f;

    readonly float delayTime = 2f;

    Color FadeTalkText;

    TextFadeInOut textFadeinout;
    [SerializeField] CanvasGroup TalkBox;

    void Start()
    {
        textFadeinout = TalkBox.GetComponent<TextFadeInOut>();
        textNum = 1;

        FadeTalkText = GetComponent<TMP_Text>().color;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            textNum++;
        }

        switch (textNum)
        {
            case 0:
                TextFadeOut();
                TalkText.text = "";
                break;
            case 1:
                TextFadeOut();
                TalkText.text = texts[0];
                break;
            case 2:
                TalkText.text = texts[1];
                break;
            case 3:
                TalkText.text = texts[2];
                break;
            case 4:
                TalkText.text = texts[3];
                break;
            case 5:
                textFadeinout.isTextFadeIn = true;
                Invoke(nameof(TextReset), delayTime);
                break;
        }         
    }

    void TextReset()
    {
        textNum = 1;
    }

    IEnumerable TextFade()
    {
        FadeTalkText.a = Mathf.Clamp(FadeTalkText.a, MinColor, MaxColor);
        GetComponent<TMP_Text>().color = new Color(FadeTalkText.r, FadeTalkText.g, FadeTalkText.b, FadeTalkText.a);
        FadeTalkText.a -= textFadeSped;

        // 1•b‘Ò‹@
        yield return new WaitForSeconds(1f);

        FadeTalkText.a = Mathf.Clamp(FadeTalkText.a, MinColor, MaxColor);
        GetComponent<TMP_Text>().color = new Color(FadeTalkText.r, FadeTalkText.g, FadeTalkText.b, FadeTalkText.a);
        FadeTalkText.a += textFadeSped;
    }

    public void TextFadeIn()
    {
        FadeTalkText.a = Mathf.Clamp(FadeTalkText.a, MinColor, MaxColor);
        GetComponent<TMP_Text>().color = new Color(FadeTalkText.r, FadeTalkText.g, FadeTalkText.b, FadeTalkText.a);
        FadeTalkText.a -= textFadeSped;
    }

    public void TextFadeOut()
    {
        FadeTalkText.a = Mathf.Clamp(FadeTalkText.a, MinColor, MaxColor);
        GetComponent<TMP_Text>().color = new Color(FadeTalkText.r, FadeTalkText.g, FadeTalkText.b, FadeTalkText.a);
        FadeTalkText.a += textFadeSped;
    }
}
