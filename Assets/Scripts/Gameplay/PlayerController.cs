using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public static event Action<PlayerController> onGunAnimation;
    public static event Action<PlayerController> onPlayerDie;
    public static event Action<PlayerController> onPause;
    public static event Action<PlayerController> onResume;
    public static event Action<PlayerController, int> onAnimating;

    [SerializeField] private PlayerDataSo data;
    [SerializeField] private Transform firePoint;

    [SerializeField] private HealthSystem healthSystem;

    private Rigidbody2D playerRigidbody;

    [NonSerialized] public bool isJumping = false;
    [NonSerialized] public bool isWalking = false;
    private bool isPause = false;
    private bool isAlive = true;

    private enum AnimationStates
    {
        Idle = 0,
        Walk = 1,
        Jump = 2
    };

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();

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
                        onResume?.Invoke(this);
                        break;
                    case false:
                        Time.timeScale = 0f;
                        isPause = true;
                        onPause?.Invoke(this);
                        break;
                }
            }
        }

        Move();
        Animate();
    }

    private void OnDisable()
    {
        healthSystem.onDie -= HealthSystem_onDie;
    }

    public void Move()
    {
        if (Input.GetKey(data.goLeft))
        {
            playerRigidbody.AddForce(Vector2.left * data.speed * Time.deltaTime, ForceMode2D.Force);
            transform.rotation = new Quaternion(0, 180, 0, 0);
            isWalking = true;
        }

        if (Input.GetKey(data.goRight))
        {
            playerRigidbody.AddForce(Vector2.right * data.speed * Time.deltaTime, ForceMode2D.Force);
            transform.rotation = new Quaternion(0, 0, 0, 0);
            isWalking = true;
        }

        if (Input.GetKey(data.goUp) && !isJumping)
        {
            playerRigidbody.velocityY = 0f;
            playerRigidbody.AddForce(Vector2.up * data.jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    public void Animate()
    {
        if (isWalking && !isJumping)
        {
            onAnimating?.Invoke(this, (int)AnimationStates.Walk);
            isWalking = false;
        }
        else if (isJumping)
        {
            onAnimating?.Invoke(this, (int)AnimationStates.Jump);
        }
        else
        {
            onAnimating?.Invoke(this, (int)AnimationStates.Idle);
        }
    }

    public void Fire()
    {
        if (EventSystem.current.IsPointerOverGameObject()) // Para saber si le pego a un objeto de UI
            return;

        Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Bullet bullet = Instantiate(data.bulletPrefab);
        bullet.transform.position = firePoint.position;
        Vector3 bulletDirection = (targetPos - firePoint.position).normalized;
        bullet.Set(bulletDirection);

        onGunAnimation?.Invoke(this);
    }

    public void HealthSystem_onDie()
    {
        onPlayerDie?.Invoke(this);
        Destroy(gameObject);
        isAlive = false;
    }
}