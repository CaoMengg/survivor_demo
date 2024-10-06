using UnityEngine;
using TMPro;

namespace Popup
{
    public class Damage : MonoBehaviour
    {
        private float duration = 0;
        public TextMeshPro textMeshPro;

        public void Init(float damage, Vector2 position)
        {
            transform.position = position;
            textMeshPro.SetText(damage.ToString());
        }

        void Update()
        {
            duration += Time.deltaTime;
            if (duration > DamageCtrl.Instance.duration)
            {
                Destroy(gameObject);
                return;
            }
            float percent = duration / DamageCtrl.Instance.duration;
            float scale = DamageCtrl.Instance.scaleCurve.Evaluate(percent);
            transform.localScale = Vector2.one * scale;
        }
    }
}