using Mirror;
using UnityEngine;

public class Coin : NetworkBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!isServer) return;

        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            player.AddCoin();
            NetworkServer.Destroy(gameObject);
        }
    }
}