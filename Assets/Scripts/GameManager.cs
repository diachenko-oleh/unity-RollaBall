using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static int score;
    public static bool win;
    public static Color color;
    public static float speed = 5;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
