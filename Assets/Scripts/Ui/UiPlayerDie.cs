using UnityEngine;

public class UiPlayerDie : MonoBehaviour
{
    [SerializeField] private GameObject loseScreen;
    private void OnEnable()
    {
        PlayerController.onPlayerDie += OnPlayerDie_LoseUi;
    }

    private void OnDisable()
    {
        PlayerController.onPlayerDie -= OnPlayerDie_LoseUi;
    }

    public void OnPlayerDie_LoseUi(PlayerController playerController)
    {
        Time.timeScale = 0;
        loseScreen.SetActive(true);
    }
}
