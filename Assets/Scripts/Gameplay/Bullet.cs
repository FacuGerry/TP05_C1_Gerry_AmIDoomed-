using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 20;
    public int speed = 20;

    private Rigidbody2D bulletRigidbody;

    private void Awake ()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.TryGetComponent(out HealthSystem healthSystem))
        {
            healthSystem.DoDamage(damage);
        }

        Destroy(gameObject);
    }

    public void Set (Vector3 direction)
    {
        bulletRigidbody.bodyType = RigidbodyType2D.Dynamic;
        bulletRigidbody.velocity = direction * speed;
    }
}