using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "Clase80/PlayerSettings")]
public class PlayerDataSo : ScriptableObject
{
    [Header("Stats")]
    public float speed;
    public float jumpForce;

    [Header("Key Bindings")]
    public KeyCode goLeft;
    public KeyCode goRight;
    public KeyCode goUp;

    [Header("Bullet")]
    public Bullet bulletPrefab;
}