using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private AudioClip fireClip;

    private Animator animator;
    private AudioSource source;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        PlayerController.onGunFiring += PlayerController_OnGunAnimation;
        PlayerController.onGunFiring += PlayerController_OnGunSound;
    }

    private void OnDisable()
    {
        PlayerController.onGunFiring -= PlayerController_OnGunAnimation;
        PlayerController.onGunFiring -= PlayerController_OnGunSound;
    }

    public void PlayerController_OnGunAnimation(PlayerController playerController)
    {
        animator.Play("Fire");
    }

    public void PlayerController_OnGunSound(PlayerController playerController)
    {
        source.PlayOneShot(fireClip);
    }
}
