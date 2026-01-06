using UnityEngine;

public class TartaFollower : MonoBehaviour
{
    [Range(0,2)]
    public int tartaIndex;

    Rigidbody2D rb;
    DistanceJoint2D joint;

    bool collected = false;

    void OnEnable()
    {
        GameEvents.OnLevelFinished += OnLevelFinished;
    }

    void OnDisable()
    {
        GameEvents.OnLevelFinished -= OnLevelFinished;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        int levelID = FindObjectOfType<LevelIdentifier>().levelID;

        // Si ya estaba recogida en otra sesión, no aparece
        if (LevelProgressManager.HasTarta(levelID, tartaIndex))
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (collected) return;
        if (!other.CompareTag("Player")) return;

        Collect(other.transform);
    }

        void OnLevelFinished()
    {
        Release();
        FlyUp();
    }

    void Collect(Transform target)
    {
        collected = true;
        GameEvents.OnCollectiblePicked?.Invoke();
        int levelID = FindObjectOfType<LevelIdentifier>().levelID;

        joint = gameObject.AddComponent<DistanceJoint2D>();
        joint.connectedBody = target.GetComponent<Rigidbody2D>();

        joint.autoConfigureDistance = false;
        joint.distance = 2.2f;       
        joint.maxDistanceOnly = true;   
        joint.enableCollision = false;

        rb.gravityScale = 0f;  
        rb.mass = 0.05f;         
        rb.linearDamping = 4f;          
        LevelProgressRuntime.RegisterTarta(levelID, tartaIndex);
        GameEvents.OnTartaCollected?.Invoke(
            levelID,
            tartaIndex,
            transform
        );
    }

    public void Release()
    {
        if (joint != null)
            Destroy(joint);

        rb.linearVelocity = Vector2.zero;
        rb.isKinematic = true;
    }

    public void FlyUp()
    {
        rb.isKinematic = false;
        rb.linearVelocity = Vector2.up * 20f;
    }
}
