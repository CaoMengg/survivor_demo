using System.Linq;
using UnityEngine;

namespace Magic
{
    public class Laser : MonoBehaviour
    {
        public LineRenderer line;
        public Transform end;
        public EdgeCollider2D collid;
        private MagicData data;

        void Start()
        {
            data = end.GetComponent<Magic>().data;
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

            if (line.GetPosition(0) == Vector3.zero && end.position != Vector3.zero)
            {
                line.SetPosition(0, end.position);
            }

            line.SetPosition(line.positionCount - 1, end.position);

            Vector3[] positions = new Vector3[line.positionCount];
            line.GetPositions(positions);
            collid.points = positions.Select(p => (Vector2)p).ToArray();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (end == null)
            {
                return;
            }
            end.SendMessage("OnTriggerEnter2D", other, SendMessageOptions.DontRequireReceiver);

            if (data.moveType == MoveType.Reflect && line.positionCount < 8)
            {
                line.positionCount++;
            }
        }

        void OnTriggerStay2D(Collider2D other)
        {
            if (end == null)
            {
                return;
            }
            end.SendMessage("OnTriggerStay2D", other, SendMessageOptions.DontRequireReceiver);
        }
    }
}