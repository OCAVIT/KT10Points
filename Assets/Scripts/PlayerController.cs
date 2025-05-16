using Mirror;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    [SyncVar]
    public int coins = 0;

    void Update()
    {
        if (!isLocalPlayer) return;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(h, 0, v) * 5f * Time.deltaTime;
        transform.Translate(move);
    }

    public void AddCoin()
    {
        if (isServer)
            coins++;
    }
}