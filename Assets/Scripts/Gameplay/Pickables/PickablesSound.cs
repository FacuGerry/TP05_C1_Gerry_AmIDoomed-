using UnityEngine;

public class SFXController : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField] private AudioClip lifeClip;
    [SerializeField] private AudioClip coinClip;
    [SerializeField] private AudioClip deathSound;

    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        PickablesController.onPickablesMakeSound += OnCoinsPicked_EmmitSound;
        PlayerController.onPlayerDie += OnPlayerDie_GameOverSound;
    }

    private void OnDisable()
    {
        PickablesController.onPickablesMakeSound -= OnCoinsPicked_EmmitSound;
        PlayerController.onPlayerDie -= OnPlayerDie_GameOverSound;
    }

    public void OnCoinsPicked_EmmitSound(PickablesController pickablesController, bool isLife, bool isCoin)
    { 
        if (isLife)
        {
            source.PlayOneShot(lifeClip);
        }
        if (isCoin)
        {
            source.PlayOneShot(coinClip);
        }
    }

    public void OnPlayerDie_GameOverSound(PlayerController playerController)
    {
        source.PlayOneShot(deathSound);
    }
}
