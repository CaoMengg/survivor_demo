using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Magic;

namespace Card
{
    public class CardCtrl : MonoBehaviour
    {
        public static CardCtrl Instance { get; private set; }
        public GameObject magicCard;
        public GameObject[] curStanceList;
        public GameObject[] nextStanceList;
        private readonly int maxDrawnNum = 4;
        private readonly GameObject[] curCardList = new GameObject[4];
        private readonly GameObject[] nextCardList = new GameObject[4];
        private float nextDelay;
        public Slider cardSlider;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

        void Update()
        {
            nextDelay -= Time.deltaTime;
            for (int i = 0; i < maxDrawnNum; i++)
            {
                if (curCardList[i] != null)
                {
                    curCardList[i].transform.DOMove(curStanceList[i].transform.position, 3);
                }

                if (nextDelay > 0)
                {
                    continue;
                }
                if (nextCardList[i] != null)
                {
                    nextCardList[i].transform.DOMove(nextStanceList[i].transform.position, 1);
                }
            }
        }

        public void DrawnCard()
        {
            for (int i = 0; i < maxDrawnNum; i++)
            {
                curStanceList[i].SetActive(false);

                if (curCardList[i] != null)
                {
                    Destroy(curCardList[i]);
                }

                curCardList[i] = nextCardList[i];
                if (curCardList[i] != null)
                {
                    curStanceList[i].SetActive(true);
                }

                if (i < MagicCtrl.Instance.nextMagicList.Count)
                {
                    var magic = MagicCtrl.Instance.nextMagicList[i];
                    var card = Instantiate(magicCard, transform);
                    card.GetComponent<MagicCard>().Init(nextStanceList[0].transform.position, magic);
                    nextCardList[i] = card;
                }
            }

            nextDelay = 1;
        }

        public void UpdateCardSlider(float maxValue, float curValue)
        {
            cardSlider.maxValue = maxValue;
            cardSlider.value = curValue;
        }
    }
}