using System.Linq;
using UnityEngine;
using DG.Tweening;

namespace Magic
{
    public class MagicMove : MonoBehaviour
    {
        public MagicData data;
        private bool isMove = false;

        private readonly float traceCoolDown = 0.5f;
        private float curTraceCoolDown = 0;
        private GameObject target;
        private GameObject pivot;

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
                case MoveType.Arc:
                    Arc();
                    break;
                case MoveType.Trace:
                case MoveType.Stay:
                case MoveType.Reflect:
                    break;
                default:
                    Line();
                    break;
            }
        }

        void Line()
        {
            transform.DOMove(transform.position + data.speed * data.duration * transform.up, data.duration).SetEase(Ease.Linear);
        }

        void Around()
        {
            pivot = new GameObject("Pivot");
            pivot.transform.position = Player.Instance.transform.position;
            pivot.transform.SetParent(Player.Instance.transform);
            transform.SetParent(pivot.transform);

            transform.up = (transform.position - pivot.transform.position).normalized;
            var distance = (pivot.transform.position - transform.position).magnitude;
            pivot.transform.DORotate(new Vector3(0, 0, data.speed * data.duration * 57 / distance), data.duration, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear).SetLoops(-1).SetLink(pivot);
        }

        void Trace()
        {
            curTraceCoolDown -= Time.deltaTime;
            if (target == null && curTraceCoolDown <= 0)
            {
                GetTraceTarget();
                curTraceCoolDown = traceCoolDown;
            }

            if (target != null)
            {
                transform.up = Vector2.Lerp(transform.up, target.transform.position - transform.position, 0.02f).normalized;
            }
            transform.Translate(data.speed * Time.deltaTime * transform.up, Space.World);
        }

        void Arc()
        {
            pivot = new GameObject("Pivot");
            pivot.transform.position = transform.position - transform.up * 8;
            pivot.transform.SetParent(MagicCtrl.Instance.bulletPool.transform);
            transform.SetParent(pivot.transform);

            pivot.transform.DORotate(new Vector3(0, 0, data.speed * data.duration * 7.2f), data.duration, RotateMode.FastBeyond360)
            .SetEase(Ease.InOutSine).SetLoops(-1).SetLink(pivot);
        }

        void Reflect()
        {
            transform.Translate(data.speed * Time.deltaTime * transform.up, Space.World);
        }

        void Update()
        {
            if (!isMove)
            {
                return;
            }

            switch (data.moveType)
            {
                case MoveType.Trace:
                    Trace();
                    break;
                case MoveType.Reflect:
                    Reflect();
                    break;
            }
        }

        void OnDestroy()
        {
            if (pivot != null)
            {
                Destroy(pivot);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (data.moveType != MoveType.Reflect)
            {
                return;
            }

            if (!other.gameObject.TryGetComponent(out Enemy.Enemy enemy))
            {
                return;
            }
            transform.up = Vector2.Reflect(transform.up, transform.position - enemy.transform.position);
        }

        void GetTraceTarget()
        {
            var targetList = Player.Instance.GetAllTarget();
            if (targetList.Count == 0)
            {
                return;
            }
            target = targetList.OrderBy(target => (target.transform.position - transform.position).sqrMagnitude).FirstOrDefault();
        }
    }
}