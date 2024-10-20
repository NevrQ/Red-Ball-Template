using UnityEngine;

public class Raise : MonoBehaviour
{
    public float raiseSpeed = 0.1f; 
    public float maxScaleY = 2.0f;  

    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (transform.localScale.y < maxScaleY)
        {
            float newScaleY = transform.localScale.y + raiseSpeed * Time.deltaTime;
            transform.localScale = new Vector3(originalScale.x, Mathf.Min(newScaleY, maxScaleY), originalScale.z);
        }
    }
}