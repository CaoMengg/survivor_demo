using UnityEngine;

namespace Evol
{
    [CreateAssetMenu(fileName = "EvolData", menuName = "ScriptableObject/EvolData")]
    public class EvolData : ScriptableObject
    {
        [field: SerializeField] public int evolId { get; private set; }
        [field: SerializeField] public string evolName { get; private set; }
        [field: SerializeField] public Sprite evolIcon { get; private set; }

        [Header("战斗属性")]
        [Range(1f, 30f)] public float duration;
        [Range(1, 10)] public int castNum;
        [Range(0f, 20f)] public float speed;
        [Range(1f, 100f)] public float damage;
    }
}