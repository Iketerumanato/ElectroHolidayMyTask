using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Video;

public class TutorialZone : MonoBehaviour
{
    public static bool PlayerTouchTutorialZone = false;

    [SerializeField]
    PlayerInput[] _playerInputs;

    [SerializeField]
    CanvasGroup TutorialGroup;

    [SerializeField] 
    TutorialImage _tutorialImage;

    [SerializeField]
    TutorialVideo _tutorialVideo;

    [SerializeField]
    VideoPlayer TutorialPlayer;

    [SerializeField]
    FadeOut fadeBack;

    [SerializeField]
    CircleGage gaugeColor;

    //0Ç©ÇÁèâÇﬂ
    [SerializeField]
    int TutorialNum;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<DenkiController>().playerNum == 1)
        {
            gaugeColor.ChangeGaugeColor1P();
            PlayerTouchTutorialZone = true;
            fadeBack.IsTouchTutorialArea = true;
            _playerInputs[0].actions.FindActionMap("Player").Disable();
            _playerInputs[1].actions.FindActionMap("Player").Disable();
            _tutorialImage.ChangeTutorialImage(TutorialNum);
            _tutorialVideo.ChangeTutorialVideo(TutorialNum);
            TutorialPlayer.Play();
            Destroy(gameObject);
        }

        if (other.CompareTag("Player") && other.GetComponent<DenkiController>().playerNum == 2)
        {
            gaugeColor.ChangeGaugeColor2P();
            PlayerTouchTutorialZone = true;
            fadeBack.IsTouchTutorialArea = true;
            _playerInputs[0].actions.FindActionMap("Player").Disable();
            _playerInputs[1].actions.FindActionMap("Player").Disable();
            _tutorialImage.ChangeTutorialImage(TutorialNum);
            _tutorialVideo.ChangeTutorialVideo(TutorialNum);
            TutorialPlayer.Play();
            Destroy(gameObject);
        }
    }
}
