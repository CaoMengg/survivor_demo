using UnityEngine;

namespace Popup
{
    public class DamageTextCtrl : MonoBehaviour
    {
        public static DamageTextCtrl Instance { get; private set; }
        public float duration = 1;
        public AnimationCurve scaleCurve;
        public DamageText damageTextPrefab;
        public Transform damageTextPool;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void Show(float damage, Vector2 position)
        {
            Instantiate(damageTextPrefab, damageTextPool).Init(damage, position);
        }
    }
}