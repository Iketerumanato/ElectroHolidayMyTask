using UnityEngine;
using UnityEngine.UI;

public class TutorialImage : MonoBehaviour
{
    Image Images;

    [SerializeField] Sprite[] TutorialImageSprite;
 
    int ImageNum;

    public int TutorialImageNum
    {
        get { return ImageNum; }
        set { ImageNum = value; }
    }

    private void Awake()
    {
        Images = GetComponent<Image>();
    }

    public void ChangeTutorialImage(int TutorialNum)
    {
        Images.sprite = TutorialImageSprite[TutorialNum];
    }
}
