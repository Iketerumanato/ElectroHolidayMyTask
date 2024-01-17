using UnityEngine;
using UnityEngine.SceneManagement;

public class Lever : MonoBehaviour
{
    [SerializeField] GameObject LeverStick;
    readonly float MaxLeverRotaZ = 30f;

    private void FixedUpdate()
    {
        if (29f <= LeverStick.transform.localEulerAngles.z && LeverStick.transform.localEulerAngles.z <= 31f)
        {
            SceneManager.LoadScene("Movie_Epi");
        }
    }
}
