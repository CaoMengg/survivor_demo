using UnityEngine;

namespace Magic
{
    public enum ShootType
    {
        Dartle,      // 连射
        Spread,      // 散射
        Casual,      // 乱射
        Fall,        // 坠落
    }

    public enum FlyType
    {
        Line,        // 直线
        Around,      // 环绕
        Trace,       // 追踪
        Stay,        // 停留
        /*Follow,
        Arc,
        Parabola,
        Bezier,
        Sine,
        Lock,*/
    }

    [CreateAssetMenu(fileName = "MagicData", menuName = "ScriptableObject/MagicData")]
    public class MagicData : ScriptableObject
    {
        [field: SerializeField] public int magicId { get; private set; }
        [field: SerializeField] public string magicName { get; private set; }
        [field: SerializeField] public Sprite magicIcon { get; private set; }
        [field: SerializeField] public GameObject magicPrefab { get; private set; }

        [Header("战斗属性")]
        [Range(0.1f, 10f)] public float coolDown;
        [Range(1f, 30f)] public float duration;
        [Range(1, 10)] public int castNum;
        [Range(0f, 20f)] public float speed;
        [Range(1f, 100f)] public float damage;
        [Range(0, 1000)] public int penetrate;
        public ShootType shootType;
        public FlyType flyType;

        [Header("动态数据")]
        public float curCoolDown;
    }
}