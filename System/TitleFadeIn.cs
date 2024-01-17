using UnityEngine;

public class TitleFadeIn : MonoBehaviour
{
    public bool IsTitleFadeIn = false;
    readonly float minAlpha = 0f;

    [SerializeField] float fadeInspeed = 0.08f;
    [SerializeField] CanvasGroup FadePanel;

    private void Awake()
    {
        IsTitleFadeIn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsTitleFadeIn)
            FadeInPanel();
    }

    void FadeInPanel()
    {
        FadePanel.alpha -= fadeInspeed;
        if (FadePanel.alpha <= minAlpha)
            IsTitleFadeIn = false;
    }
}
