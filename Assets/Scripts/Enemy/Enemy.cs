using DG.Tweening;
using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        private Rigidbody2D rb;
        public float speed;
        public float health;
        public Vector2 faceDirect;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            transform.DOMove(Player.Instance.transform.position, speed).SetSpeedBased();

            faceDirect = (Player.Instance.transform.position - transform.position).normalized;
            transform.up = faceDirect;
        }

        private void OnDestroy()
        {
            DOTween.KillAll();
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
