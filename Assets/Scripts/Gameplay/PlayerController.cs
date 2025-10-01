using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

namespace Clase08
{
    public class PlayerController : MonoBehaviour
    {
        private HealthSystem healthSystem;

        [SerializeField] private PlayerDataSo data;
        [SerializeField] private Transform firePoint;

        private Rigidbody2D playerRigidbody;

        bool isJumping = false;

        private void Awake ()
        {
            healthSystem = GetComponent<HealthSystem>();
            healthSystem.onDie += HealthSystem_onDie;

            playerRigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update ()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Fire();
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
                playerRigidbody.AddForce(data.speed * Vector2.left, ForceMode2D.Force);
            }

            if (Input.GetKey(data.goRight))
            {
                playerRigidbody.AddForce(data.speed * Vector2.right, ForceMode2D.Force);
            }

            if (Input.GetKey(data.goUp) && !isJumping)
            {
                playerRigidbody.AddForce(Vector2.up * data.jumpForce, ForceMode2D.Impulse);
                isJumping = true;
            }
        }

        private void Fire ()
        {
            if (EventSystem.current.IsPointerOverGameObject()) // Para saber si le pego a un objeto de UI
                return;

            Bullet bullet = Instantiate(data.bulletPrefab);
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = Quaternion.identity;
            bullet.gameObject.layer = LayerMask.NameToLayer("Player");

            Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            bullet.transform.LookAt(targetPos);
            bullet.Set(20, 30);
        }

        private void HealthSystem_onDie()
        {
            Debug.Log("Murió el Player");
        }
    }
}