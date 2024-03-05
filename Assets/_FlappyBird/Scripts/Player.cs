using GameTool;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float jumpForce = 20f;
    public float cooldown;
    public float timeShoot = 2.0f;
    public float boundTop = 4.33f;
    public float boundBottom = -4.5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        AudioManager.Instance.PlayMusic(eMusicName.Game);
        cooldown = timeShoot;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AudioManager.Instance.Shot(eSoundName.Jump);
            rb.velocity = new Vector2(0, jumpForce);
        }

        Vector2 pos = transform.position;
        if (transform.position.y >= boundTop)
        {
            transform.position = new Vector2(pos.x, boundTop);
        }
        else if (pos.y <= boundBottom)
        {
            transform.position = new Vector2(pos.x, boundBottom);
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
        }
    }
}