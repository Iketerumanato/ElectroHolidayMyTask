using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    //SE�̑f�ތQ
    [SerializeField] AudioClip[] BGM;
   
    AudioSource BGMSource;

    public static BGMManager seInstance;

    private void Awake()
    {
        //if (seInstance == null)
        //{
        //    seInstance = this;
        //    DontDestroyOnLoad(this.gameObject);
        //}
        //else
        //{
        //    Destroy(this.gameObject);
        //}

        BGMSource = gameObject.GetComponent<AudioSource>();

        //BGM�̐؂�ւ�
        if (SceneManager.GetActiveScene().name == "Title")
            ChangeTitleBGM();
        else
            ChangeStageBGM();

        BGMSource.Play();
    }

    public void ChangeTitleBGM()
    {
        BGMSource.clip = BGM[0];
    }

    public void ChangeStageBGM()
    {
        BGMSource.clip = BGM[1];
    }
}