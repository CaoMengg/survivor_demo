using System.Linq;
using UnityEngine;
using DG.Tweening;

namespace Magic
{
    public class BlackHoleMagic : Magic
    {
        private readonly float pullDuration = 1;

        protected override void OnUpdate()
        {
            if (duration > pullDuration)
            {
                return;
            }

            var results = GameObject.FindGameObjectsWithTag("Enemy");
            if (results.Count() == 0)
            {
                return;
            }

            foreach (var result in results)
            {
                result.transform.DOMove(transform.position, pullDuration);
            }
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
        }
    }
}
