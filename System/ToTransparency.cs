using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToTransparency : MonoBehaviour
{
    [SerializeField] float fadeSpeed = 0.01f;

    [Range(0f,1f)]
    [SerializeField] float fadePercent = 1f;

    Color FadeImage;
    readonly float MinColor = 0f;

    public enum FadeMode
    { 
        FadeBefore,
        FadeIn,
        FadeOut,
    }
    public FadeMode fadeNum;

    void Start()
    {
        FadeImage = GetComponent<Image>().color;
        fadeNum = FadeMode.FadeBefore;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeNum == FadeMode.FadeIn)
        {
            StartFadeIn();
        }

        if (fadeNum == FadeMode.FadeOut)
        {
            StartFadeOut();
        }
    }

    public void StartFadeIn()
    {
        FadeImage.a = Mathf.Clamp(FadeImage.a, MinColor, fadePercent);
        GetComponent<Image>().color = new Color(FadeImage.r, FadeImage.g, FadeImage.b, FadeImage.a);
        FadeImage.a -= fadeSpeed;
    }

    public void StartFadeOut()
    {
        FadeImage.a = Mathf.Clamp(FadeImage.a, MinColor, fadePercent);
        GetComponent<Image>().color = new Color(FadeImage.r, FadeImage.g, FadeImage.b, FadeImage.a);
        FadeImage.a += fadeSpeed;
    }
}
