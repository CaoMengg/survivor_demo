using UnityEngine;

namespace Magic
{
    public class PoisonPoolMagic : Magic
    {
        private float damageCoolDown = 0;

        protected override void OnStart()
        {
            transform.position += (Vector3)Random.insideUnitCircle * 10;
        }

        protected override void OnUpdate()
        {
            if (damageCoolDown > 0)
            {
                damageCoolDown -= Time.deltaTime;
            }
            else
            {
                damageCoolDown = 0.3f;
            }
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (damageCoolDown > 0)
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
