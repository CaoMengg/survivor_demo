using UnityEngine;

namespace Popup
{
    public class DamageCtrl : MonoBehaviour
    {
        public static DamageCtrl Instance { get; private set; }
        public float duration = 1;
        public Damage damage;
        public AnimationCurve scaleCurve;
        public GameObject damagePool;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

        public void Show(float text, Vector2 position)
        {
            Instantiate(damage, damagePool.transform).Init(text, position);
        }
    }
}