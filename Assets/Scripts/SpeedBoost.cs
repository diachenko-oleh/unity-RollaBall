using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public float speedBonus = 2f;
    public float respawnTime = 5f;
    public bool destroyAfterPickup = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.speed += speedBonus;

            gameObject.SetActive(false);
            if (!destroyAfterPickup)
            {
                Invoke(nameof(ReactivatePickup), respawnTime);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
    void ReactivatePickup()
    {
        gameObject.SetActive(true);
    }
}
