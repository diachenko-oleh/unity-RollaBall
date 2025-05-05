using UnityEngine;
using UnityEngine.Audio;

public class Collectible : MonoBehaviour
{
    public AudioSource collectSound;
    public GameObject onCollectEffect;
    public bool isfixed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject effect = Instantiate(onCollectEffect, transform.position, transform.rotation);
            AudioSource newSound = Instantiate(collectSound, transform.position, Quaternion.identity);
            newSound.Play();
            Destroy(newSound.gameObject, 1f);
            Destroy(effect, 1f);
            if (!isfixed)
            {
                Destroy(gameObject);
            }
           
        }

    }
}
