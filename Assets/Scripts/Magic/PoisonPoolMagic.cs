using UnityEngine;

namespace Magic
{
    public class PoisonPoolMagic : Magic
    {
        private readonly float damageCoolDown = 0.3f;
        private float curDamageCoolDown = 0;

        protected override void OnStart()
        {
            transform.position += (Vector3)Random.insideUnitCircle * 10;
        }

        protected override void OnUpdate()
        {
            if (curDamageCoolDown > 0)
            {
                curDamageCoolDown -= Time.deltaTime;
            }
            else
            {
                curDamageCoolDown = damageCoolDown;
            }
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (curDamageCoolDown > 0)
            {
                return;
            }

            if (other.gameObject.TryGetComponent(out Enemy.Enemy enemy))
            {
                enemy.TakeDamage(data.damage, Vector2.zero);
            }
        }
    }
}
