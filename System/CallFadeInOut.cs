using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallFadeInOut : MonoBehaviour
{
    ToTransparency callFadeInout;
    [SerializeField] Image FadeImage;
    public static bool fadeInout;//true FadeIn/false FadeOut 

    // Start is called before the first frame update
    void Start()
    {
        callFadeInout = FadeImage.GetComponent<ToTransparency>();
        fadeInout = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!fadeInout)
        {
            callFadeInout.fadeNum = ToTransparency.FadeMode.FadeOut;
        }

        if (fadeInout)
        {
            callFadeInout.fadeNum = ToTransparency.FadeMode.FadeIn;
        }
    }
}
