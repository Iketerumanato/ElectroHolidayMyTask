using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Collections;

public class MovieSkipGage : MonoBehaviour
{
    [SerializeField]
    string SceneName;

    [SerializeField]
    Image GageMainImg;

    [SerializeField]
    float GageSpeed;

    [SerializeField]
    float FadeOutWaitTime = 5f;

    [SerializeField]
    float FadeInWaitTime = 15f;

    [SerializeField]
    float SkipSceneTime = 2f;

    [SerializeField]
    float FadeSpeed = 0.04f;

    [SerializeField]
    CanvasGroup GageGroup;

    readonly float MaxAlpha = 1f;
    readonly float MinAlpha = 0f;

    readonly int FadeCount = 25;

    private void Start()
    {
        GageMainImg.fillAmount = MinAlpha;
        StartCoroutine("FadeOutGage");
        StartCoroutine("FadeInGage");
    }

    private void Update()
    {
        if (Gamepad.current.buttonEast.isPressed
            || Gamepad.current.buttonSouth.isPressed)
        {
            GageMainImg.fillAmount += GageSpeed * Time.deltaTime;

            if (GageMainImg.fillAmount >= MaxAlpha)
            {
                GageMainImg.color = new Color(0f, 0f, 0f, 0f);
                StartCoroutine("SkipThisScene");
            }
        }
    }

    IEnumerator SkipThisScene()
    {
        yield return new WaitForSeconds(SkipSceneTime);
        SceneManager.LoadScene(SceneName);
    }

    IEnumerator FadeOutGage()
    {
        yield return new WaitForSeconds(FadeOutWaitTime);
        for (int f = 0; f < FadeCount; f++)
        {
            GageGroup.alpha += FadeSpeed;
            yield return new WaitForSeconds(FadeSpeed);
        }
        if (GageGroup.alpha >= MaxAlpha) yield break;
    }

    IEnumerator FadeInGage()
    {
        yield return new WaitForSeconds(FadeInWaitTime);
        for (int f = 0; f < FadeCount; f++)
        {
            GageGroup.alpha -= FadeSpeed;
            yield return new WaitForSeconds(FadeSpeed);
        }
        if (GageGroup.alpha <= MinAlpha)
        {
            Destroy(this.gameObject);
            yield break;
        }
    }
}
