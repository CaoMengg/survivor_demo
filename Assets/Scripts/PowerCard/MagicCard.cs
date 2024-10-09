using UnityEngine;
using Magic;

namespace PowerCard
{
    public class MagicCard : PowerCard
    {
        MagicData data;

        public void Init(MagicData magic)
        {
            data = magic;
            title.text = data.magicName;
            icon.sprite = data.magicIcon;
        }

        public override void PowerUp()
        {
            Debug.Log("PowerUp");
            PowerCardCtrl.Instance.PowerUp();
        }
    }
}
