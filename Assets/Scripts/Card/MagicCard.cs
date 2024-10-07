using UnityEngine;
using UnityEngine.UI;
using Magic;

namespace Card
{
    public class MagicCard : MonoBehaviour
    {
        public Image icon;
        public Text text;

        public void Init(Vector3 position, MagicData magic)
        {
            transform.position = position;
            icon.sprite = magic.magicIcon;
            text.text = magic.magicName;
        }
    }
}
