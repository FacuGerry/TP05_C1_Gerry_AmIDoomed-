using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerSettingsSO", order = 1)]

public class PlayerSettingsSO : ScriptableObject
{
    [Header("Stats")]
    public float life;
    public float speed;
    public float jumpForce;

    [Header("Key Bindings")]
    public KeyCode goLeft;
    public KeyCode goRight;
    public KeyCode goUp;
    public KeyCode shoot;
    
}
