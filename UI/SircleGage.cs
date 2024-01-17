using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SircleGage : MonoBehaviour
{
    [SerializeField]
    Image GageImage;

    ToTransparency transparency;
    [SerializeField] Image TutorialImage;

    bool mouseButton = false;

    // Start is called before the first frame update
    void Start()
    {
        GageImage = GetComponent<Image>();
        transparency = TutorialImage.GetComponent<ToTransparency>();
    }

    // Update is called once per frame
    void Update()
    {
        // マウスを使ってゲージを増減させる
        if (Input.GetMouseButtonDown(0))
        {
            mouseButton = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            mouseButton = false;
        }


        if (mouseButton)
        {
            GageImage.fillAmount += Time.deltaTime;
            if(GageImage.fillAmount >= 1f)
            {

                CallFadeInOut.fadeInout = true;
                transparency.fadeNum = ToTransparency.FadeMode.FadeIn;
            }
        }
        else if (GageImage.fillAmount > 0f)
        {
            GageImage.fillAmount = 0f;
        }
    }
}
