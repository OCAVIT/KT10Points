using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class CoinUI : MonoBehaviour
{
    public Text coinText;
    PlayerController player;

    void Update()
    {
        if (player == null)
        {
            foreach (var p in FindObjectsOfType<PlayerController>())
            {
                if (p.isLocalPlayer)
                {
                    player = p;
                    break;
                }
            }
        }
        if (player != null)
            coinText.text = "Coins: " + player.coins;
    }
}