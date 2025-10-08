using UnityEngine;

public class CoinsSound : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField] private AudioClip clip;

    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        PickablesController.onCoinsPicked += OnCoinsPicked_EmmitSound;
    }

    private void OnDisable()
    {
        PickablesController.onCoinsPicked -= OnCoinsPicked_EmmitSound;
    }

    void OnCoinsPicked_EmmitSound(PickablesController pickablesController)
    {
        source.PlayOneShot(clip);
    }
}
