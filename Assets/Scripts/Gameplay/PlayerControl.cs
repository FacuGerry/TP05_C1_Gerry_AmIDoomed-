using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private PlayerSettingsSO playerSo;

    private Rigidbody2D playerRigidbody;

    private bool isJumping = false;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        Move();
        Shoot();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
    }

    public void Move()
    {
        if (Input.GetKey(playerSo.goLeft))
        {
            playerRigidbody.AddForce(playerSo.speed * Vector2.left, ForceMode2D.Force);
        }

        if (Input.GetKey(playerSo.goRight))
        {
            playerRigidbody.AddForce(playerSo.speed * Vector2.right, ForceMode2D.Force);
        }

        if (Input.GetKey(playerSo.goUp) && !isJumping)
        {
            playerRigidbody.AddForce(Vector2.up * playerSo.jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    public void Shoot()
    {
        if (Input.GetKey(playerSo.shoot))
        {

        }
    }
}
