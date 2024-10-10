using UnityEngine;

namespace Evol
{
    [CreateAssetMenu(fileName = "EvolData", menuName = "ScriptableObject/EvolData")]
    public class EvolData : ScriptableObject
    {
        [field: SerializeField] public int evolId { get; private set; }
        [field: SerializeField] public string evolName { get; private set; }
        [field: SerializeField] public string evolDesc { get; private set; }
        [field: SerializeField] public Sprite evolIcon { get; private set; }

        [Header("属性")]
        public Magic.ShootType shootType;
        public Magic.MoveType moveType;
        public int castNum;
    }
}