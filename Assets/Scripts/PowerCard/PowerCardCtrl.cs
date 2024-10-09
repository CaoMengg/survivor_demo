using UnityEngine;
using Magic;

namespace PowerCard
{
    public class PowerCardCtrl : MonoBehaviour
    {
        public static PowerCardCtrl Instance { get; private set; }
        public GameObject powerCardPrefab;
        private GameObject[] powerCardList = new GameObject[3];
        public GameObject panel;

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
            InvokeRepeating(nameof(ShowPowerUp), 10f, 30f);
        }

        public void ShowPowerUp()
        {
            var m0 = Instantiate(powerCardPrefab, panel.transform);
            var m1 = Instantiate(powerCardPrefab, panel.transform);
            var m2 = Instantiate(powerCardPrefab, panel.transform);
            m0.GetComponent<MagicCard>().Init(MagicCtrl.Instance.magicList.magicList[2]);
            m1.GetComponent<MagicCard>().Init(MagicCtrl.Instance.magicList.magicList[3]);
            m2.GetComponent<MagicCard>().Init(MagicCtrl.Instance.magicList.magicList[4]);
            powerCardList[0] = m0;
            powerCardList[1] = m1;
            powerCardList[2] = m2;
            UI.Instance.PauseGame();
            panel.SetActive(true);
        }

        public void PowerUp()
        {
            foreach (var card in powerCardList)
            {
                Destroy(card);
            }
            panel.SetActive(false);
            UI.Instance.ResumeGame();
        }
    }
}