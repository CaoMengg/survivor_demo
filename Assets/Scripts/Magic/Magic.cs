using DG.Tweening;
using UnityEngine;

namespace Magic
{
    public class Magic : MonoBehaviour
    {
        public MagicData data;
        float duration;

        void Start()
        {
            duration = data.duration;
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
    }
}