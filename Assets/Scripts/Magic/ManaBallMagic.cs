using System.Linq;
using DG.Tweening;
using UnityEngine;

namespace Magic
{
    public class ManaBallMagic : Magic
    {
        protected override void OnStart()
        {
            transform.up = Random.insideUnitCircle.normalized;
        }

        protected override void OnUpdate()
        {
            if (target == null)
            {
                GetTarget();
            }
            if (target != null)
            {
                transform.up = Vector2.Lerp(transform.up, target.transform.position - transform.position, 0.02f).normalized;
            }
            transform.DOMove(transform.position + transform.up, data.speed).SetSpeedBased();
        }

        private void GetTarget()
        {
            var results = GameObject.FindGameObjectsWithTag("Enemy");
            if (results.Count() == 0)
            {
                return;
            }

            var minDistance = float.MaxValue;
            foreach (var result in results)
            {
                var distance = (result.transform.position - transform.position).sqrMagnitude;
                if (distance > minDistance || distance > 25)
                {
                    continue;
                }
                minDistance = distance;
                target = result;
            }
        }
    }
}
