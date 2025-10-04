using UnityEngine;

public class GunController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        PlayerController.onGunAnimation += PlayerController_onGunAnimation;
    }

    private void OnDisable()
    {
        PlayerController.onGunAnimation -= PlayerController_onGunAnimation;
    }

    public void PlayerController_onGunAnimation(PlayerController playerController)
    {
        animator.Play("Fire");
    }
}
