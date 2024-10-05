using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObject/EnemyData")]
    public class EnemyData : ScriptableObject
    {
        public int enemyId;
        public string enemyName;
        public GameObject enemy;
    }
}