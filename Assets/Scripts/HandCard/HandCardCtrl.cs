using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Magic;

namespace HandCard
{
    public class HandCardCtrl : MonoBehaviour
    {
        public static HandCardCtrl Instance { get; private set; }
        public GameObject handCardPrefab;
        public GameObject[] curStanceList;
        public GameObject[] nextStanceList;
        private readonly int maxDrawnNum = 4;
        private readonly GameObject[] curCardList = new GameObject[4];
        private readonly GameObject[] nextCardList = new GameObject[4];
        public Slider cardSlider;

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

        void Update()
        {
            cardSlider.value -= Time.deltaTime;
        }

        public void DrawnCard()
        {
            for (int i = 0; i < maxDrawnNum; i++)
            {
                // curStanceList[i].SetActive(false);
                Destroy(curCardList[i]);

                curCardList[i] = nextCardList[i];
                if (curCardList[i] != null)
                {
                    curStanceList[i].SetActive(true);
                    curCardList[i].transform.DOMove(curStanceList[i].transform.position, 3);
                }

                if (i < MagicCtrl.Instance.nextMagicList.Count)
                {
                    var magic = MagicCtrl.Instance.nextMagicList[i];
                    var card = Instantiate(handCardPrefab, transform);
                    card.GetComponent<HandCard>().Init(nextStanceList[0].transform.position, magic);
                    card.transform.DOMove(nextStanceList[i].transform.position, 1).SetDelay(1);
                    nextCardList[i] = card;
                }
                else
                {
                    nextCardList[i] = null;
                }
            }
        }

        public void UpdateCardSlider(float maxValue, float curValue)
        {
            cardSlider.maxValue = maxValue;
            cardSlider.value = curValue;
        }
    }
}