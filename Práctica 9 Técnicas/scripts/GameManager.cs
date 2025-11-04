using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Área de aparición (X, Y mín y máx)")]
    public Vector2 spawnAreaMin = new Vector2(-5, 0);
    public Vector2 spawnAreaMax = new Vector2(5, 3);

    [Header("Cantidad máxima de monedas activas")]
    public int maxActiveCoins = 3;

    private void OnEnable()
    {
        Coin.OnCollected += HandleCoinCollected;
    }

    private void OnDisable()
    {
        Coin.OnCollected -= HandleCoinCollected;
    }

    void Start()
    {
        for (int i = 0; i < maxActiveCoins; i++)
        {
            SpawnCoin();
        }
    }

    private void HandleCoinCollected(Coin coin)
    {
        ObjectPooler.Instance.ReturnToPool(coin.gameObject);
        SpawnCoin();
    }

    private void SpawnCoin()
    {
        GameObject coinObj = ObjectPooler.Instance.GetInactiveObject();

        Vector2 randomPos = new Vector2(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y)
        );
        coinObj.transform.position = randomPos;
        coinObj.SetActive(true);
    }
}
