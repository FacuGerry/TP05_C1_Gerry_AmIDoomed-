using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D enemyRigidbody;
    private HealthSystem healthSystem;

    [SerializeField] private EnemyDataSo enemyData;
    [SerializeField] private float limitMovementRight = 1f;
    [SerializeField] private float limitMovementLeft = 1f;
    private float limitRight;
    private float limitLeft;
    private float enemySpeed;
    private float damage;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyRigidbody = GetComponent<Rigidbody2D>();

        healthSystem = GetComponent<HealthSystem>();
        healthSystem.onDie += HealthSystem_onDie;
    }

    private void Start()
    {
        enemySpeed = enemyData.speed;
        damage = enemyData.damage;
        limitLeft = transform.position.x - limitMovementLeft;
        limitRight = transform.position.x + limitMovementRight;
        enemyRigidbody.velocity = Vector2.right * enemySpeed;
    }

    private void Update()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out HealthSystem healthSystem))
        {
            healthSystem.DoDamage((int)damage);
        }
    }

    public void Move()
    {
        if (transform.position.x <= limitLeft)
        {
            enemyRigidbody.velocityX = enemySpeed;
            spriteRenderer.flipX = false;

            if (enemyRigidbody.velocityX < enemySpeed && enemyRigidbody.velocityX >= 0)
            {
                enemyRigidbody.velocityX = enemySpeed;
            }
        }
        if (transform.position.x >= limitRight)
        {
            enemyRigidbody.velocityX = -enemySpeed;
            spriteRenderer.flipX = true;

            if (enemyRigidbody.velocityX < -enemySpeed && enemyRigidbody.velocityX < 0)
            {
                enemyRigidbody.velocityX = enemySpeed;
            }
        }
    }

    private void HealthSystem_onDie()
    {
        Destroy(gameObject);
        Debug.Log("Murió el enemigo");
    }
}