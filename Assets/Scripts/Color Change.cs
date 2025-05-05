using System.Collections;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public float interval = 1f;
    private Renderer objRenderer;
    private Color newColor;

    void Start()
    {
        objRenderer = GetComponent<Renderer>();
        StartCoroutine(ChangeColorRoutine());
    }

    IEnumerator ChangeColorRoutine()
    {
        while (true)
        {
            ChangeColor();
            yield return new WaitForSeconds(interval);
        }
    }

    void ChangeColor()
    {
        newColor = new Color(Random.value,Random.value,Random.value);
        objRenderer.material.color = newColor;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        GameManager.color = newColor;
    }
}
