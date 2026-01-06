using UnityEngine;

public class AttackPooled : MonoBehaviour
{
    [SerializeField] float lifeTime = 0.3f;
    [SerializeField] float speed = 6f;

    float timer;
    PoolOfAttack pool;
    Vector2 direction;

    public void Init(PoolOfAttack pool, Vector2 direction)
    {
        this.pool = pool;
        this.direction = direction.normalized;
        timer = lifeTime;
    }

    void OnEnable()
    {
        timer = lifeTime;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            pool.Return(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit " + other.name);
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        } else if (other.gameObject.layer == LayerMask.NameToLayer("Collectable"))
        {
            return;
        } else if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerDeath>().Die();
        }
        pool.Return(gameObject);
    }
}
