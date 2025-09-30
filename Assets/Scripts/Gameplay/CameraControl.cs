using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private GameObject player;

    void FixedUpdate()
    {
        gameObject.transform.position = new Vector2(player.transform.position.x, 0);
    }
}
