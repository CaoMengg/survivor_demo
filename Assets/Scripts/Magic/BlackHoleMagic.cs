using UnityEngine;
using DG.Tweening;

namespace Magic
{
    public class BlackHoleMagic : Magic
    {
        private readonly float pullDuration = 1;

        protected override void OnStart()
        {
            var enemys = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemys.Length == 0)
            {
                return;
            }

            foreach (var enemy in enemys)
            {
                enemy.transform.DOMove(transform.position, pullDuration).SetDelay(pullDuration).SetLink(enemy);
            }
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
        }
    }
}
