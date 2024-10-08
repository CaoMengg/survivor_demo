using DG.Tweening;
using UnityEngine;

namespace Magic
{
    public class MagicAttack : MonoBehaviour
    {
        public MagicData data;
        private readonly float coolDown = 0.3f;
        private float curCoolDown = 0;

        void Update()
        {
            if (curCoolDown > 0)
            {
                curCoolDown -= Time.deltaTime;
            }
            else
            {
                curCoolDown = coolDown;
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (data.attackType != AttackType.Single && data.attackType != AttackType.Penetrate)
            {
                return;
            }

            if (!other.gameObject.TryGetComponent(out Enemy.Enemy enemy))
            {
                return;
            }
            enemy.TakeDamage(data.damage, transform.up);

            if (data.attackType != AttackType.Penetrate)
            {
                Destroy(gameObject);
            }
        }

        void OnTriggerStay2D(Collider2D other)
        {
            if (curCoolDown > 0)
            {
                return;
            }
            if (data.attackType != AttackType.Area)
            {
                return;
            }

            if (!other.gameObject.TryGetComponent(out Enemy.Enemy enemy))
            {
                return;
            }
            enemy.TakeDamage(data.damage, Vector2.zero);
        }
    }
}