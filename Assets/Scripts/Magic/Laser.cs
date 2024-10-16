using UnityEngine;

namespace Magic
{
    public class Laser : MonoBehaviour
    {
        public LineRenderer line;
        public Transform end;
        public PolygonCollider2D collid;

        void Start()
        {
            transform.SetParent(MagicCtrl.Instance.bulletPool.transform);
            transform.position = Vector3.zero;
            line.SetPosition(0, Vector2.zero);
            line.SetPosition(1, Vector2.zero);
        }

        void Update()
        {
            if (end == null)
            {
                Destroy(gameObject);
                return;
            }

            if (transform.position == Vector3.zero && end.position != Vector3.zero)
            {
                transform.position = end.position;
            }

            transform.up = (end.position - transform.position).normalized;
            var distance = (end.position - transform.position).magnitude;
            line.SetPosition(1, new Vector2(0, distance));

            var path = collid.GetPath(0);
            path[2].y = distance;
            path[3].y = distance;
            collid.SetPath(0, path);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (end == null)
            {
                return;
            }

            end.TryGetComponent(out MagicAttack magicAttack);
            if (magicAttack == null)
            {
                return;
            }
            magicAttack.OnTriggerEnter2D(other);
        }
    }
}