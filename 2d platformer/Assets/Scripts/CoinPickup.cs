using UnityEngine;
using TMPro;

public class CoinPickup : MonoBehaviour
{
    private float coins = 0;

    public TextMeshProUGUI textCoins;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Coin")
        {
            coins++;
            textCoins.text = coins.ToString();

            Destroy(other.gameObject);
        }
    }
}
