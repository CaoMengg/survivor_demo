using DG.Tweening;
using UnityEngine;

namespace Magic
{
    public abstract class Magic : MonoBehaviour
    {
        public MagicData data;
        protected float duration;
        protected int penetrate;
        public Vector2 position;
        public Vector2 direct;
        public GameObject target;

        void Start()
        {
            transform.position = position;
            transform.up = direct;
            duration = data.duration;
            penetrate = data.penetrate;
            OnStart();
        }

        protected virtual void OnStart() { }

        void Update()
        {
            OnUpdate();
            duration -= Time.deltaTime;
            if (duration <= 0)
            {
                Destroy(gameObject);
            }
        }

        protected virtual void OnUpdate() { }

        private void OnDestroy()
        {
            DOTween.KillAll();
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