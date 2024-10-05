using TMPro;
using UnityEngine;

namespace Popup
{
    public class Damage : MonoBehaviour
    {
        private float duration = 0;
        private float percent;
        private float scale;
        private TextMeshPro textMeshPro;

        public void Init(float damage, Vector2 position)
        {
            transform.position = position;
            textMeshPro = GetComponent<TextMeshPro>();
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
            percent = duration / DamageCtrl.Instance.duration;
            scale = DamageCtrl.Instance.scaleCurve.Evaluate(percent);
            transform.localScale = Vector2.one * scale;
        }
    }
}