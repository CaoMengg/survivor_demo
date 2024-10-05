using DG.Tweening;
using UnityEngine;

namespace Magic
{
    public class FireballMagic : Magic
    {
        protected override void OnStart()
        {
            transform.up = Random.insideUnitCircle.normalized;
        }

        protected override void OnUpdate()
        {
            transform.DOMove(transform.position + transform.up, data.speed).SetSpeedBased();
        }
    }
}
