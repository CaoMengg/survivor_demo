using UnityEngine;
using TMPro;

namespace Popup
{
    public class DamageText : MonoBehaviour
    {
        private float duration = 0;
        public TextMeshPro textMeshPro;

        public void Init(float damage, Vector2 position)
        {
            position.x += Random.Range(-0.5f, 0.5f);
            position.y += Random.Range(-0.5f, 0.5f);
            transform.position = position;
            textMeshPro.SetText(damage.ToString());
        }

        void Update()
        {
            duration += Time.deltaTime;
            if (duration > DamageTextCtrl.Instance.duration)
            {
                Destroy(gameObject);
                return;
            }
            float percent = duration / DamageTextCtrl.Instance.duration;
            float scale = DamageTextCtrl.Instance.scaleCurve.Evaluate(percent);
            transform.localScale = Vector2.one * scale;
        }
    }
}