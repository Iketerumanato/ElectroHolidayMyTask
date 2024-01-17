using UnityEngine;

public class TitleFadeout : MonoBehaviour
{
    public bool IsTitleFadeOut = false;
    readonly float maxAlpha = 1f;

    [SerializeField] float fadeOutspeed = 0.08f;
    [SerializeField] CanvasGroup FadePanel;

    // Update is called once per frame
    void Update()
    {
        if (IsTitleFadeOut)
            FadeInPanel();
    }

    void FadeInPanel()
    {
        FadePanel.alpha += fadeOutspeed;
        if (FadePanel.alpha >= maxAlpha)
            IsTitleFadeOut = false;
    }
}
