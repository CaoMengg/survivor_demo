using UnityEngine;

namespace Popup
{
    public class DamageCtrl : MonoBehaviour
    {
        public static DamageCtrl Instance { get; private set; }
        public float duration = 1;
        public AnimationCurve scaleCurve;
        public Damage damagePrefab;
        public Transform damagePool;

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
            Instantiate(damagePrefab, damagePool).Init(damage, position);
        }
    }
}