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
                default:
                    Dartle();
                    break;
            }
            magicMove.Move();
        }

        void Dartle()
        {
            transform.up = Player.Instance.faceDirect;
            transform.position = Player.Instance.transform.position + transform.up * Random.Range(0, 5);
        }

        void Spread()
        {
            float angle = Mathf.Lerp(0f, 360f, (float)castSeq / (float)data.castNum);
            transform.up = Quaternion.Euler(0, 0, angle) * Player.Instance.faceDirect;
            transform.position = Player.Instance.transform.position + transform.up * 3;
        }

        void Casual()
        {
            transform.up = Random.insideUnitCircle.normalized;
            transform.position = Player.Instance.transform.position + transform.up * Random.Range(0, 1);
        }

        void Fall()
        {
            transform.up = Player.Instance.faceDirect;
            transform.position = Player.Instance.transform.position + (Vector3)Random.insideUnitCircle * 10;
        }
    }
}