using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public ParticleSystem jumpParticles;
    public AudioClip ballSound;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private float speed;
    private int count;
    public int playerScore;

    public float jumpForce = 5f;
    private bool onGround = true;
    Renderer objRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        speed = GameManager.speed;
        SetCountText();
        winTextObject.SetActive(false);
        objRenderer = GetComponent<Renderer>();

    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movingVector = movementValue.Get<Vector2>();
        movementX = movingVector.x;
        movementY = movingVector.y;
    }
    private void OnJump(InputValue jumpValue)
    {
        if (onGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onGround = false;
        }

        if (jumpParticles != null)
        {
            ParticleSystem effect = Instantiate(
                jumpParticles,
                transform.position - new Vector3(0, transform.localScale.y / 2f, 0),
                Quaternion.identity
            );
            effect.Play();
            Destroy(effect.gameObject, 1f);
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
    private void FixedUpdate()
    {
        speed = GameManager.speed;
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement*speed);
        if (count >= 12)                                         //WIN
        {
            winTextObject.SetActive(true);
            GameManager.win = true;
            GetComponent<PlayerController>().enabled = false;
            GameObject.FindGameObjectWithTag("Enemy").SetActive(false);
            StartCoroutine(LoadSceneAfterDelay());
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        AudioSource.PlayClipAtPoint(ballSound, transform.position);

        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
        if (collision.gameObject.CompareTag("Enemy"))                    //LOSE
        {
            GetComponent<PlayerController>().enabled = false;
            GameObject.FindGameObjectWithTag("Enemy").SetActive(false);
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
            GameManager.win = false;
            StartCoroutine(LoadSceneAfterDelay());
        }
    }
    private IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(2);
        GameManager.score = count;
        SceneManager.LoadScene(2);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Pickup")
        {
            other.gameObject.SetActive(false);
            count++;
            GameManager.score = count;
            SetCountText();
        }
        else if(other.gameObject.tag == "Colorup")
        {
            objRenderer.material.color = GameManager.color;
        }
    }
}
