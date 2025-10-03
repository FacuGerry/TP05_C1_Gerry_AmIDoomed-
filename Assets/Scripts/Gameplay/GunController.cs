using UnityEngine;

public class GunController : MonoBehaviour
{
    private PlayerController playerController;

    private Animator animator;

    private Vector3 initialPosition;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        //playerController.onGunAnimation += PlayerController_onGunAnimation;
        //No se pq me esta tirando error de que no esta instanciado xd

        animator = GetComponent<Animator>();

        initialPosition = transform.position;
    }

    private void Update()
    {
        Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = targetPos;
    }

    public void PlayerController_onGunAnimation(bool isFiring)
    {
        if (isFiring)
        {
            animator.Play("Fire");
        }
    }
}
