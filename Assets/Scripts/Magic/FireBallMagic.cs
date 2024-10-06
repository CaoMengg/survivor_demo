using DG.Tweening;
using UnityEngine;

namespace Magic
{
    public class FireballMagic : Magic
    {
        protected override void OnStart()
        {
            transform.up = Random.insideUnitCircle.normalized;
            transform.DOMove(transform.position + data.speed * duration * transform.up, duration);
        }
    }
}
