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

    public enum MoveType
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

    public enum AttackType
    {
        Single,      // 单体
        Penetrate,   // 穿透
        Area,        // 范围持续
        // Bomb,        // 范围单次
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
        public ShootType shootType;
        public MoveType moveType;
        public AttackType attackType;

        [Header("动态数据")]
        public float curCoolDown;
    }
}