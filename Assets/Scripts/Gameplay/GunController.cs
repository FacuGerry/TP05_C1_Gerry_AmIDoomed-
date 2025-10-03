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

    private void Update()
    {
        Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = targetPos;
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
