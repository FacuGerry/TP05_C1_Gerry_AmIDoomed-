using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public static event Action<PlayerController> onGunAnimation;
    public static event Action<PlayerController> onPlayerDie;

    [SerializeField] private PlayerDataSo data;
    [SerializeField] private Transform firePoint;

    [SerializeField] private HealthSystem healthSystem;

    private Rigidbody2D playerRigidbody;
    private SpriteRenderer spriteRenderer;

    bool isJumping = false;
    bool isPause = false;
    bool isAlive = true;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        isPause = false;
    }

    private void OnEnable()
    {
        healthSystem.onDie += HealthSystem_onDie;
    }

    private void Update()
    {
        if (isAlive)
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
        }

        Move();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
    }

    private void OnDisable()
    {
        healthSystem.onDie -= HealthSystem_onDie;
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
        //bullet.transform.position = firePoint.position;
        bullet.gameObject.layer = LayerMask.NameToLayer("Player");

        onGunAnimation?.Invoke(this);

        Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //bullet.transform.LookAt(targetPos);
        Vector3 bulletDirection = targetPos - transform.position;
        bullet.Set(firePoint.position, bulletDirection);
    }

    public void HealthSystem_onDie()
    {
        onPlayerDie?.Invoke(this);
        Destroy(gameObject);
        isAlive = false;
    }
}