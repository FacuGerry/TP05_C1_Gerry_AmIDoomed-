using TMPro;
using UnityEngine;

public class UiCoinCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsText;

    private int coins;

    private void Awake()
    {
        PickablesController.onCoinsChanged += OnCoinsChanged_WriteCoins;
    }

    private void Start()
    {
        coins = 0;
    }

    public void OnCoinsChanged_WriteCoins(PickablesController pickablesController, int coinPickedValue)
    {
        coins += coinPickedValue;
        coinsText.text = coins.ToString("0");
    }
}
