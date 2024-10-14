using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        public Rigidbody2D rb;
        public float speed;
        public float health;
        private bool isDead = false;
        private Vector2 faceDirect = Vector2.up;
        public Animator animator;

        void Update()
        {
            if (isDead)
            {
                return;
            }
            faceDirect = (Player.Instance.transform.position - transform.position).normalized;
            if (faceDirect.x > 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (faceDirect.x < 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            transform.Translate(speed * Time.deltaTime * faceDirect, Space.World);
        }

        public void TakeDamage(float damage, Vector2 direct)
        {
            if (isDead || damage <= 0)
            {
                return;
            }
            health -= damage;
            Popup.DamageCtrl.Instance.Show(damage, transform.position);
            if (health <= 0)
            {
                isDead = true;
                animator.SetBool("isDead", isDead);
                Destroy(gameObject, 1);
                return;
            }

            if (direct != Vector2.zero)
            {
                rb.AddForce(0.5f * damage * direct, ForceMode2D.Impulse);
            }
        }
    }
}
