using GameTool;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float cooldown;
    public float spawnTime = 5f;

    private void Start()
    {
        cooldown = spawnTime;
    }

    private void Update()
    {
        cooldown -= Time.deltaTime;
        
        if (cooldown <= 0)
        {
            cooldown = spawnTime;
            PoolingManager.Instance.GetObject(NamePrefabPool.Wall, position: new Vector3(5f, 0f, 0f)).Disable(10f);
        }
    }
}
