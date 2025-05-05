using UnityEngine;
using TMPro;

public class LoseScreen : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject winTextObject;
    void Start()
    {
        scoreText.text = "Score: " + GameManager.score;
        if (!GameManager.win)
        {
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
        }
        else
        {
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Win!";
        }
       

    }
}
