using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TalkArea : MonoBehaviour
{
    TextFadeInOut textFadeinout;
    [SerializeField] CanvasGroup TalkBox;

    // Start is called before the first frame update
    void Start()
    {
        textFadeinout = TalkBox.GetComponent<TextFadeInOut>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            textFadeinout.isTextFadeOut = true;
        }
    }

    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        textFadeinout.isTextFadeIn = true;
    //    }
    //}
}
