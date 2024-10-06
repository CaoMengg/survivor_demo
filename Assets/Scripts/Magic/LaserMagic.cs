using DG.Tweening;
using UnityEngine;

namespace Magic
{
    public class LaserMagic : Magic
    {
        protected override void OnStart()
        {
            transform.position += transform.up * Random.Range(0, 1);
            transform.DOMove(transform.position + data.speed * duration * transform.up, duration);
        }
    }
}