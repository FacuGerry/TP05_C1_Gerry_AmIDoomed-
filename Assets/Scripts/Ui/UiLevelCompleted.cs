using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiLevelCompleted : MonoBehaviour
{
    [SerializeField] private CoinsDataSo coinsData;
    [SerializeField] private GameObject levelCompleted;
    [SerializeField] private Button btnReplay;
    [SerializeField] private Button btnMainMenu;
    [SerializeField] private GameObject coinsCounter;
    [SerializeField] private TextMeshProUGUI coinsNum;
    [SerializeField] private TextMeshProUGUI totalCoinsNum;

    private void Start()
    {
        btnReplay.onClick.AddListener(ReplayClicked);
        btnMainMenu.onClick.AddListener(MainMenuClicked);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Time.timeScale = 0f;
        coinsNum.text = coinsData.coins.ToString("0");
        totalCoinsNum.text = coinsData.totalCoins.ToString("0");
        coinsCounter.SetActive(false);
        levelCompleted.SetActive(true);
    }

    private void OnDestroy()
    {
        btnReplay.onClick.RemoveAllListeners();
        btnMainMenu.onClick.RemoveAllListeners();
    }

    public void ReplayClicked()
    {
        SceneManager.LoadScene("GameLevel1");
        Time.timeScale = 1f;
    }

    public void MainMenuClicked()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}
