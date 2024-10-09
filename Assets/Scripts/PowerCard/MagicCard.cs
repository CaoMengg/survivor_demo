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
            desc.text = data.magicDesc.Replace("\\n", "\n");
            icon.sprite = data.magicIcon;
        }

        public override void PowerUp()
        {
            PowerCardCtrl.Instance.FinishPowerUp();
        }
    }
}
