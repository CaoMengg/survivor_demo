using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        public Rigidbody2D rb;
        public float speed;
        public float health;

        void Update()
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.Instance.transform.position, speed * Time.deltaTime);
            transform.up = (Player.Instance.transform.position - transform.position).normalized;
        }

        public void TakeDamage(float damage, Vector2 direct)
        {
            if (damage <= 0)
            {
                return;
            }
            health -= damage;
            Popup.DamageCtrl.Instance.Show(damage, transform.position);
            if (health <= 0)
            {
                Destroy(gameObject);
                return;
            }

            if (direct != Vector2.zero)
            {
                rb.AddForce(5 * damage * direct, ForceMode2D.Impulse);
            }
        }
    }
}
