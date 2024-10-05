using UnityEngine;

namespace Magic
{
    [CreateAssetMenu(fileName = "MagicData", menuName = "ScriptableObject/MagicData")]
    public class MagicData : ScriptableObject
    {
        public int magicId;
        public string magicName;
        public float coolDown;
        public float curCoolDown;
        public float duration;
        public int castNum;
        public float speed;
        public float damage;
        public int penetrate = 0;
        public Sprite icon;
        public GameObject magic;
    }
}