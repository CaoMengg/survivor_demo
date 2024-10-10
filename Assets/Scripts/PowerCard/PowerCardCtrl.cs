using System.Linq;
using UnityEngine;
using Evol;
using System.Collections.Generic;

namespace PowerCard
{
    public class PowerCardCtrl : MonoBehaviour
    {
        public static PowerCardCtrl Instance { get; private set; }
        public EvolList evolList;
        public GameObject evolCardPrefab;
        private List<GameObject> powerCardList = new();
        public GameObject powerUpPanel;
        public GameObject magicEvolPanel;

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

        void Start()
        {
            InvokeRepeating(nameof(ShowPowerUp), 10f, 10f);
        }

        public void ShowPowerUp()
        {
            foreach (var evolData in evolList.evolList.OrderBy(_ => Random.value).Take(3))
            {
                var card = Instantiate(evolCardPrefab, powerUpPanel.transform);
                card.GetComponent<EvolCard>().Init(evolData);
                powerCardList.Add(card);
            }
            UI.Instance.PauseGame();
            powerUpPanel.SetActive(true);
            magicEvolPanel.SetActive(false);
        }

        public void FinishPowerUp()
        {
            foreach (var card in powerCardList)
            {
                Destroy(card);
            }
            UI.Instance.ResumeGame();
            powerUpPanel.SetActive(false);
            magicEvolPanel.SetActive(false);
        }
    }
}