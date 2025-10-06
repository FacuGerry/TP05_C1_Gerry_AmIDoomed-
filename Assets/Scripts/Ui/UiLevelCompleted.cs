using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiLevelCompleted : MonoBehaviour
{
    [SerializeField] private GameObject levelCompleted;
    [SerializeField] private Button btnReplay;
    [SerializeField] private Button btnMainMenu;

    private void Start()
    {
        btnReplay.onClick.AddListener(ReplayClicked);
        btnMainMenu.onClick.AddListener(MainMenuClicked);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Time.timeScale = 0f;
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
