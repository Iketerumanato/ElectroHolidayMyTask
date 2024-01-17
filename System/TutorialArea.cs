using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialArea : MonoBehaviour
{
    ToTransparency transparency;
    [SerializeField] Image TutorialImage;

    // Start is called before the first frame update
    void Start()
    {
        transparency = TutorialImage.GetComponent<ToTransparency>();       
        transparency.fadeNum = ToTransparency.FadeMode.FadeBefore;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CallFadeInOut.fadeInout = false;
            transparency.fadeNum = ToTransparency.FadeMode.FadeOut;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            ChangeTutorialImage.ImageCount++;
        }
    }
}
