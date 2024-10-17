using UnityEngine;

namespace Magic
{
    public class MagicShoot : MonoBehaviour
    {
        public MagicData data;
        public int castSeq;
        public MagicMove magicMove;

        void Start()
        {
            switch (data.shootType)
            {
                case ShootType.Dartle:
                    Dartle();
                    break;
                case ShootType.Spread:
                    Spread();
                    break;
                case ShootType.Casual:
                    Casual();
                    break;
                case ShootType.Fall:
                    Fall();
                    break;
                case ShootType.Fan:
                    Fan();
                    break;
                case ShootType.Lock:
                    Lock();
                    break;
                default:
                    Dartle();
                    break;
            }
            magicMove.Move();
        }

        void Dartle()
        {
            transform.up = Player.Instance.faceDirect;
            transform.position = Player.Instance.transform.position + transform.up * (castSeq + 2);
        }

        void Spread()
        {
            float angle = Mathf.Lerp(0f, 360f, (float)castSeq / (float)data.castNum);
            transform.up = Quaternion.Euler(0, 0, angle) * Player.Instance.faceDirect;
            transform.position = Player.Instance.transform.position + transform.up * 5;
        }

        void Casual()
        {
            transform.up = Random.insideUnitCircle.normalized;
            transform.position = Player.Instance.transform.position + transform.up * Random.Range(3, 6);
        }

        void Fall()
        {
            transform.up = Player.Instance.faceDirect;
            transform.position = Player.Instance.transform.position + (Vector3)Random.insideUnitCircle * 10;
        }

        void Fan()
        {
            float maxAngle = data.castNum * 20 < 120 ? data.castNum * 20 : 120;
            float angle = Mathf.Lerp(0f, maxAngle, (float)castSeq / (float)data.castNum);
            transform.up = Quaternion.Euler(0, 0, angle) * Player.Instance.faceDirect;
            transform.position = Player.Instance.transform.position + transform.up * 5;
        }

        void Lock()
        {
            GameObject target = Player.Instance.GetRandomTarget();
            if (target == null)
            {
                Casual();
                return;
            }
            transform.position = target.transform.position;
            transform.up = (transform.position - Player.Instance.transform.position).normalized;
        }
    }
}