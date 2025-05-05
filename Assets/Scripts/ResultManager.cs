using UnityEngine;

public class ResultManager : MonoBehaviour
{
    public AudioSource winSound;
    public AudioSource loseSound;
    void Start()
    {
        if (!GameManager.win)
        {
            Instantiate(loseSound, transform.position, Quaternion.identity).Play();
        }
        else
        {
            Instantiate(winSound, transform.position, Quaternion.identity).Play();
        }
    }

}
