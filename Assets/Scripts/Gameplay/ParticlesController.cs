using UnityEngine;

public class ParticlesController : MonoBehaviour
{
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject particles;
    private void OnEnable()
    {
        enemyController.onEnemyDeath += CheckForParticleEmission;
    }

    private void OnDisable()
    {
        enemyController.onEnemyDeath -= CheckForParticleEmission;
    }

    public void CheckForParticleEmission()
    {
        particles.transform.position = enemy.transform.position;
        particles.SetActive(true);
    }
}
