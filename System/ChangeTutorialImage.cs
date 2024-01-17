using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTutorialImage : MonoBehaviour
{
    [SerializeField] Image TutorialImage;
    [SerializeField] Sprite[] ResourceImage;
    public static int ImageCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        TutorialImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (ImageCount)
        {
            case 0:
                TutorialImage.sprite = ResourceImage[0];
                break;
            case 1:
                TutorialImage.sprite = ResourceImage[1];
                break;
        }
    }
}
