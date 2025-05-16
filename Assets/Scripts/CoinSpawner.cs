using Mirror;
using UnityEngine;

public class CoinSpawner : NetworkBehaviour
{
    public GameObject coinPrefab;
    public float spawnInterval = 2f;
    public int maxCoins = 10;
    public Vector3 areaSize = new Vector3(10, 1, 10);

    private void Start()
    {
        if (isServer)
            InvokeRepeating(nameof(SpawnCoin), 1f, spawnInterval);
    }

    void SpawnCoin()
    {
        if (!isServer) return;

        if (GameObject.FindGameObjectsWithTag("Coin").Length >= maxCoins)
            return;

        Vector3 pos = new Vector3(
            Random.Range(-areaSize.x / 2, areaSize.x / 2),
            0.5f,
            Random.Range(-areaSize.z / 2, areaSize.z / 2)
        );
        GameObject coin = Instantiate(coinPrefab, pos, Quaternion.identity);
        coin.tag = "Coin";
        NetworkServer.Spawn(coin);
    }
}