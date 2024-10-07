using System.Linq;
using UnityEngine;
using DG.Tweening;

namespace Magic
{
    public class MagicFly : MonoBehaviour
    {
        public MagicData data;
        private bool isFly = false;

        private readonly float maxTargetRange = 25;
        private readonly float traceCoolDown = 0.5f;
        private float curTraceCoolDown = 0;
        private GameObject target;

        public void Fly()
        {
            isFly = true;
            switch (data.flyType)
            {
                case FlyType.Line:
                    Line();
                    break;
                case FlyType.Around:
                    Around();
                    break;
                case FlyType.Trace:
                case FlyType.Stay:
                    break;
                default:
                    Line();
                    break;
            }
        }

        void Line()
        {
            transform.DOMove(transform.position + data.speed * data.duration * transform.up, data.duration);
        }

        void Around()
        {
            transform.SetParent(Player.Instance.body);
            transform.position = (Vector2)Player.Instance.body.position + Random.insideUnitCircle.normalized * 3;
        }

        void Update()
        {
            if (!isFly)
            {
                return;
            }

            if (data.flyType != FlyType.Trace)
            {
                return;
            }

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

        void GetTarget()
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