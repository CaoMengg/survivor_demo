using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(fileName = "EnemyList", menuName = "ScriptableObject/EnemyList")]
    public class EnemyList : ScriptableObject
    {
        public List<EnemyData> enemyList;
    }
}