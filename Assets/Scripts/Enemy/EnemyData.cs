using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObject/EnemyData")]
    public class EnemyData : ScriptableObject
    {
        [field: SerializeField] public int enemyId { get; private set; }
        [field: SerializeField] public string enemyName { get; private set; }
        [field: SerializeField] public GameObject enemyPrefab { get; private set; }
        [field: SerializeField] public float spawnRate { get; private set; }
        [field: SerializeField] public float health { get; private set; }
        [field: SerializeField] public float speed { get; private set; }
        [field: SerializeField] public float damage { get; private set; }
    }
}