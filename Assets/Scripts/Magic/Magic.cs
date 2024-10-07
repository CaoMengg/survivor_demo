using DG.Tweening;
using UnityEngine;

namespace Magic
{
    public class Magic : MonoBehaviour
    {
        public MagicData data;
        protected float duration;
        protected int penetrate;

        void Start()
        {
            duration = data.duration;
            penetrate = data.penetrate;
        }

        void Update()
        {
            duration -= Time.deltaTime;
            if (duration <= 0)
            {
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            DOTween.Kill(transform);
        }

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.TryGetComponent(out Enemy.Enemy enemy))
            {
                return;
            }
            enemy.TakeDamage(data.damage, transform.up);

            penetrate--;
            if (penetrate <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}