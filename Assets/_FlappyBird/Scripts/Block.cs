using GameTool;
using UnityEngine;

public class Block : BasePooling
{
    private void OnEnable()
    {
        Disable(10f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
