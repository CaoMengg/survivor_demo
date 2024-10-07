using UnityEngine;
using UnityEngine.Events;

namespace Magic
{
    public class MagicShoot : MonoBehaviour
    {
        public MagicData data;
        public MagicFly magicFly;

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
            magicFly.Fly();
        }


        void Dartle()
        {
            transform.up = Player.Instance.faceDirect;
            transform.position = Player.Instance.transform.position + transform.up * Random.Range(0, 1);
        }

        void Spread()
        {
            transform.up = Player.Instance.faceDirect;
            transform.position = Player.Instance.transform.position + transform.up * Random.Range(0, 1);
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