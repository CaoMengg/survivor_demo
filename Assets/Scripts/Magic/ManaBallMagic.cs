using System.Linq;
using UnityEngine;

namespace Magic
{
    public class ManaBallMagic : Magic
    {
        private readonly float maxTargetRange = 25;
        private readonly float traceCoolDown = 0.5f;
        private float curTraceCoolDown = 0;

        protected override void OnStart()
        {
            transform.up = Random.insideUnitCircle.normalized;
        }

        protected override void OnUpdate()
        {
            curTraceCoolDown -= Time.deltaTime;
            if (target == null && curTraceCoolDown <= 0)
            {
                GetTarget();
                curTraceCoolDown = traceCoolDown;
            }

            if (target != null)
            {
                transform.up = Vector2.Lerp(transform.up, target.transform.position - transform.position, 0.02f).normalized;
            }
            transform.Translate(transform.up * data.speed * Time.deltaTime, Space.World);
        }

        private void GetTarget()
        {
            var results = Physics2D.OverlapCircleAll(transform.position, maxTargetRange, LayerMask.GetMask("Enemy"));
            if (results.Length == 0)
            {
                return;
            }

            target = results
                .OrderBy(hit => (hit.transform.position - transform.position).sqrMagnitude)
                .First().gameObject;
        }
    }
}
