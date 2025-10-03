using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public event Action<bool> onGunAnimation;

    private HealthSystem healthSystem;

    [SerializeField] private PlayerDataSo data;
    [SerializeField] private Transform firePoint;

    private Rigidbody2D playerRigidbody;
    private SpriteRenderer spriteRenderer;

    bool isJumping = false;
    bool isPause = false;

    private void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.onDie += HealthSystem_onDie;

        playerRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        isPause = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isPause)
        {
            Fire();
        }

        if (Input.GetKeyDown(data.pauseGame))
        {
            switch (isPause)
            {
                case true:
                    Time.timeScale = 1f;
                    isPause = false;
                    break;
                case false:
                    Time.timeScale = 0f;
                    isPause = true;
                    break;
            }
        }

        Move();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
    }

    public void Move()
    {
        if (Input.GetKey(data.goLeft))
        {
            playerRigidbody.AddForce(Vector2.left * data.speed, ForceMode2D.Force);
            spriteRenderer.flipX = true;
        }

        if (Input.GetKey(data.goRight))
        {
            playerRigidbody.AddForce(Vector2.right * data.speed, ForceMode2D.Force);
            spriteRenderer.flipX = false;
        }

        if (Input.GetKey(data.goUp) && !isJumping)
        {
            playerRigidbody.AddForce(Vector2.up * data.jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    public void Fire()
    {
        if (EventSystem.current.IsPointerOverGameObject()) // Para saber si le pego a un objeto de UI
            return;

        Bullet bullet = Instantiate(data.bulletPrefab);
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = Quaternion.identity;
        bullet.gameObject.layer = LayerMask.NameToLayer("Player");

        onGunAnimation?.Invoke(true);

        Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        bullet.transform.LookAt(targetPos);
        Vector3 bulletDirection = targetPos - transform.position;
        bullet.Set(bulletDirection);
    }

    public void HealthSystem_onDie()
    {
        Destroy(gameObject);
    }
}