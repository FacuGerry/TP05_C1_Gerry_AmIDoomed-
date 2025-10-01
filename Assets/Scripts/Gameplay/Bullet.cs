using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 20;

    private Rigidbody2D bulletRigidbody;

    private void Awake ()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();
    }

    public void Set (int speed, int damage)
    {
        bulletRigidbody.bodyType = RigidbodyType2D.Dynamic;
        bulletRigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.TryGetComponent(out HealthSystem healthSystem))
        {
            healthSystem.DoDamage(damage);
        }

        Destroy(gameObject);
    }
}