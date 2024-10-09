using UnityEngine;
using UnityEngine.UI;

namespace PowerCard
{
    public abstract class PowerCard : MonoBehaviour
    {
        public Text title;
        public Text desc;
        public Image icon;

        public abstract void PowerUp();
    }
}
