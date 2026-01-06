using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour
{
    [Header("Shoot Settings")]
    public PoolOfAttack attackPool;
    public Transform shootPoint;
    public float shootInterval = 2f;

    public Vector2 shootDirection = Vector2.right;

    void Start()
    {
        StartCoroutine(ShootLoop());
    }

    IEnumerator ShootLoop()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(shootInterval);
        }
    }

    void Shoot()
    {
        GameObject proj = attackPool.Get();
        proj.transform.position = shootPoint.position;
        proj.transform.rotation = Quaternion.identity;

        AttackPooled pooled = proj.GetComponent<AttackPooled>();
        pooled.Init(attackPool, shootDirection);
    }
}
