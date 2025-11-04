using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [Header("Prefab del objeto a reutilizar")]
    public GameObject objectPrefab;

    [Header("Tamaño inicial del pool")]
    public int poolSize = 10;

    private List<GameObject> pool = new List<GameObject>();

    public static ObjectPooler Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectPrefab, transform);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject GetInactiveObject()
    {
        List<GameObject> inactiveObjects = pool.FindAll(o => !o.activeInHierarchy);
        if (inactiveObjects.Count == 0)
        {
            GameObject newObj = Instantiate(objectPrefab, transform);
            newObj.SetActive(false);
            pool.Add(newObj);
            inactiveObjects.Add(newObj);
        }
        return inactiveObjects[Random.Range(0, inactiveObjects.Count)];
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
    }

    public List<GameObject> GetActiveObjects()
    {
        return pool.FindAll(o => o.activeInHierarchy);
    }
}
