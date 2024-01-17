using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PoseMenu : MonoBehaviour
{
    [SerializeField] FadeIn fadeIn;
    [SerializeField] FadeOut fadeOut;

    public static bool IsMenuFadeOut;
    public static bool IsMenuFadeIn;
    readonly float MaxMenuAlpha = 1f;
    readonly float MinMenuAlpha = 0f;

    [SerializeField] GameObject[] MenuBeforeEffect;
    [SerializeField] PlayerInput[] _denkiController;

    [SerializeField] CanvasGroup MenuMain;
    [SerializeField] float fadeSpeed = 0.01f;

    [SerializeField] GameObject GotoTitleMenuObj;
    [SerializeField] GameObject MenuButtonObjs;

    [SerializeField] Button YesGotoTitleButton;
    [SerializeField] Button RetryButton;
    [SerializeField] Button GotoTitleButton;

    private void Awake()
    {
        gameObject.SetActive(false);
        GetComponent<PoseMenu>().enabled = false;
        MenuMain.alpha = MinMenuAlpha;
    }

    public void FadeOutMenuButtons()
    {
        RetryButton.Select();
        MenuMain.alpha = MaxMenuAlpha;
        Time.timeScale = 0f;
    }

    public void FadeInMenuButtons()
    {
        MenuMain.alpha = MinMenuAlpha;
        GetComponent<PoseMenu>().enabled = false;
        Time.timeScale = 1f;
    }

    public void PlayelEctricEffect()
    {
        _denkiController[0].actions.FindActionMap("Player").Disable();
        _denkiController[1].actions.FindActionMap("Player").Disable();

        _denkiController[0].actions.FindActionMap("UIManu").Enable();
        _denkiController[1].actions.FindActionMap("UIManu").Enable();

        MenuBeforeEffect[0].SetActive(true);
        MenuBeforeEffect[1].SetActive(true);

        IsMenuFadeOut = true;
    }

    //メニュー画面のボタンの処理群
    public void ActiveGotoTitleMenu()
    {
        SEManager.seInstance.PlayMenuPushButtonSE();
        _denkiController[0].actions.FindActionMap("UIManu").Disable();
        _denkiController[1].actions.FindActionMap("UIManu").Disable();
        MenuButtonObjs.SetActive(false);
        GotoTitleMenuObj.SetActive(true);
        YesGotoTitleButton.Select();
    }

    public void RetryThisStage()
    {
        SEManager.seInstance.PlayMenuPushButtonSE();

        GetComponent<PoseMenu>().enabled = false;

        _denkiController[0].actions.FindActionMap("UIManu").Disable();
        _denkiController[1].actions.FindActionMap("UIManu").Disable();

        _denkiController[0].actions.FindActionMap("Player").Enable();
        _denkiController[1].actions.FindActionMap("Player").Enable();

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnCloseMenu()
    {
        SEManager.seInstance.PlayCloseMenuButtonSE();
        IsMenuFadeIn = true;

        FadeInMenuButtons();

        _denkiController[0].actions.FindActionMap("UIManu").Disable();
        _denkiController[1].actions.FindActionMap("UIManu").Disable();

        _denkiController[0].actions.FindActionMap("Player").Enable();
        _denkiController[1].actions.FindActionMap("Player").Enable();

        gameObject.SetActive(false);
    }

    public void OnCloseMenuButtonVer(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        SEManager.seInstance.PlayCloseMenuButtonSE();
        IsMenuFadeIn = true;

        FadeInMenuButtons();

        _denkiController[0].actions.FindActionMap("UIManu").Disable();
        _denkiController[1].actions.FindActionMap("UIManu").Disable();

        _denkiController[0].actions.FindActionMap("Player").Enable();
        _denkiController[1].actions.FindActionMap("Player").Enable();

        gameObject.SetActive(false);
    }

    public void YesGotoTitle()
    {
        SEManager.seInstance.PlayMenuPushButtonSE();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Title");
    }

    public void NoGotoTitle()
    {
        SEManager.seInstance.PlayMenuPushButtonSE();
        _denkiController[0].actions.FindActionMap("UIManu").Enable();
        _denkiController[1].actions.FindActionMap("UIManu").Enable();
        MenuButtonObjs.SetActive(true);
        GotoTitleButton.Select();
        GotoTitleMenuObj.SetActive(false);
    }
}