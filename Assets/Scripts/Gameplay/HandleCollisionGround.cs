using UnityEngine;

public class HandleCollisionGround : MonoBehaviour
{
    [SerializeField] private PlayerController controller;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        controller.isJumping = false;
    }
}
