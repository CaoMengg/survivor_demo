using UnityEngine;
using Evol;
using Magic;
using System.Collections.Generic;

namespace PowerCard
{
    public class EvolCard : PowerCard
    {
        EvolData evolData;
        public GameObject magicEvolCardPrefab;
        private List<GameObject> magicEvolCardList = new();

        public void Init(EvolData evol)
        {
            evolData = evol;
            title.text = evolData.evolName;
            desc.text = evolData.evolDesc.Replace("\\n", "\n");
            icon.sprite = evolData.evolIcon;
        }

        public override void PowerUp()
        {
            foreach (var magicData in MagicCtrl.Instance.magicPool)
            {
                var card = Instantiate(magicEvolCardPrefab, PowerCardCtrl.Instance.magicEvolPanel.transform);
                card.GetComponent<MagicEvolCard>().Init(evolData, magicData);
                magicEvolCardList.Add(card);
            }
            PowerCardCtrl.Instance.powerUpPanel.SetActive(false);
            PowerCardCtrl.Instance.magicEvolPanel.SetActive(true);
        }

        public void OnDestroy()
        {
            foreach (var card in magicEvolCardList)
            {
                Destroy(card);
            }
            magicEvolCardList.Clear();
        }
    }
}
