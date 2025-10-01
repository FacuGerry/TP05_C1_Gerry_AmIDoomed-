using UnityEngine;

public class CameraControl : MonoBehaviour
{

    [SerializeField] private GameObject cam;
    private Vector2 position;

    private void Awake()
    {
        position = cam.transform.position;
    }

    private void Update()
    {
        cam.transform.position = new Vector2(transform.position.x, position.y);
    }



}
