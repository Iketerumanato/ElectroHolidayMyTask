using UnityEngine;
using UnityEngine.Video;

public class TutorialVideo : MonoBehaviour
{
    [SerializeField] VideoClip[] TutorialClip;

    VideoPlayer TutorialVideoPlayer;

    int VideoNum;

    public int TutorialVideoNum
    {
        get { return VideoNum; }
        set { VideoNum = value; }
    }

    private void Awake()
    {
        TutorialVideoPlayer = GetComponent<VideoPlayer>();
    }

    public void ChangeTutorialVideo(int TutorialNum)
    {
       
        TutorialVideoPlayer.clip = TutorialClip[TutorialNum];
    }
}
