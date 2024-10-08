using System.Linq;
using UnityEngine;
using DG.Tweening;

namespace Magic
{
    public class MagicMove : MonoBehaviour
    {
        public MagicData data;
        private bool isMove = false;

        private readonly float maxTargetRange = 5;
        private readonly float traceCoolDown = 0.5f;
        private float curTraceCoolDown = 0;
        private GameObject target;

        public void Move()
        {
            isMove = true;
            switch (data.moveType)
            {
                case MoveType.Line:
                    Line();
                    break;
                case MoveType.Around:
                    Around();
                    break;
                case MoveType.Trace:
                case MoveType.Stay:
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
        }

        void Update()
        {
            if (!isMove)
            {
                return;
            }

            if (data.moveType != MoveType.Trace)
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
            transform.Translate(data.speed * Time.deltaTime * transform.up, Space.World);
        }

        void GetTarget()
        {
            var results = Physics2D.OverlapCircleAll(transform.position, maxTargetRange, LayerMask.GetMask("Enemy"));
            if (results.Length == 0)
            {
                return;
            }

            target = results.OrderBy(hit => (hit.transform.position - transform.position).sqrMagnitude).First().gameObject;
        }
    }
}