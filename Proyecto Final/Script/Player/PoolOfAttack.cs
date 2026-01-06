using UnityEngine;
using System.Collections.Generic;

public class PoolOfAttack : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] int prewarm = 10;

    readonly Queue<GameObject> q = new();

    void Awake()
    {
        for (int i = 0; i < prewarm; i++)
            Return(Create());
    }

    GameObject Create()
    {
        var go = Instantiate(prefab);
        go.SetActive(false);
        return go;
    }

    public GameObject Get()
    {
        var go = q.Count > 0 ? q.Dequeue() : Create();
        go.SetActive(true);
        return go;
    }

    public void Return(GameObject go)
    {
        go.SetActive(false);
        q.Enqueue(go);
    }
}
