using Evol;
using Magic;

namespace PowerCard
{
    public class MagicEvolCard : PowerCard
    {
        EvolData evolData;
        MagicData magicData;

        public void Init(EvolData evol, MagicData magic)
        {
            evolData = evol;
            magicData = magic;
            title.text = magicData.magicName;
            desc.text = magicData.magicDesc.Replace("\\n", "\n");
            icon.sprite = magicData.magicIcon;
        }

        public override void PowerUp()
        {
            if (evolData.shootType != ShootType.None)
            {
                magicData.shootType = evolData.shootType;
            }
            if (evolData.moveType != MoveType.None)
            {
                magicData.moveType = evolData.moveType;
            }
            if (evolData.castNum != 0)
            {
                magicData.castNum += evolData.castNum;
            }
            PowerCardCtrl.Instance.FinishPowerUp();
        }
    }
}
