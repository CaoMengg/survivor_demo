using UnityEngine;
using UnityEngine.UI;
using Magic;

namespace Card
{
    public class MagicCard : MonoBehaviour
    {
        private Image icon;
        private Text text;

        public void Init(Vector3 position, MagicData magic)
        {
            transform.position = position;
            icon = GetComponentsInChildren<Image>()[2];
            text = GetComponentInChildren<Text>();
            icon.sprite = magic.icon;
            text.text = magic.magicName;
        }
    }
}
