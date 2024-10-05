using DG.Tweening;
using UnityEngine;

namespace Magic
{
    public class WaterBallMagic : Magic
    {
        protected override void OnStart()
        {
            transform.up = Random.insideUnitCircle.normalized;
            transform.position += transform.up * 3;
        }

        protected override void OnUpdate()
        {
            transform.up = Quaternion.AngleAxis(2, Vector3.forward) * transform.up;
            transform.up.Normalize();
            transform.DOMove(Player.Instance.transform.position + transform.up * 3, data.speed).SetSpeedBased();
        }
    }
}
