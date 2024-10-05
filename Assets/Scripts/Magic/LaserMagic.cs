using DG.Tweening;
using UnityEngine;

namespace Magic
{
    public class LaserMagic : Magic
    {
        protected override void OnStart()
        {
            transform.position += transform.up * Random.Range(0, 1);
        }

        protected override void OnUpdate()
        {
            transform.DOMove(transform.position + transform.up, data.speed).SetSpeedBased();
        }
    }
}