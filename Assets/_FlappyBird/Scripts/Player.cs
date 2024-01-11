using GameTool;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float jumpForce = 20f;
    public float cooldown;
    public float timeShoot = 2.0f;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cooldown = timeShoot;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector2(0, jumpForce);
        }

        cooldown -= Time.deltaTime;
        if (cooldown <= 0.0f)
        {
            PoolingManager.Instance.GetObject(NamePrefabPool.Bullet, null, transform.position).Disable(1);
            cooldown = timeShoot;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Block"))
        {
            Debug.Log("Collided With Square");
        }
    }
}
