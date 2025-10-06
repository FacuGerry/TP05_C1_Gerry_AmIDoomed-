using TMPro;
using UnityEngine;

public class UiCoinCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private CoinsDataSo coinsData;

    private void Awake()
    {
        PickablesController.onCoinsChanged += OnCoinsChanged_WriteCoins;
    }

    private void Start()
    {
        coinsData.coins = 0;
    }

    private void OnDestroy()
    {
        PickablesController.onCoinsChanged -= OnCoinsChanged_WriteCoins;
    }

    public void OnCoinsChanged_WriteCoins(PickablesController pickablesController)
    {
        int coinPickedValue = coinsData.coinsValue;
        coinsData.coins += coinPickedValue;
        coinsData.totalCoins += coinPickedValue;
        coinsText.text = coinsData.coins.ToString("0");
    }
}
