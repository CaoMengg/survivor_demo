using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Card;

namespace Magic
{
    public class MagicCtrl : MonoBehaviour
    {
        public static MagicCtrl Instance { get; private set; }
        public MagicList magicList;
        private Dictionary<int, MagicData> magicMap;
        public float drawnCD = 10;
        private float curDrawnCD = 0;
        public int drawnNum = 3;
        private List<MagicData> magicPool;
        private List<MagicData> curMagicList;
        public List<MagicData> nextMagicList;
        public GameObject bulletPool;

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
            magicMap = magicList.magicList.ToDictionary(m => m.magicId, m => m);
            magicPool = new List<MagicData>(magicList.magicList);
            DrawnMagic();
        }

        void DrawnMagic()
        {
            curMagicList = nextMagicList;
            nextMagicList = magicPool.OrderBy(_ => Random.value).Take(drawnNum).ToList();

            curMagicList.ForEach(item => item.curCoolDown = 0);
            CardCtrl.Instance.DrawnCard();
        }

        void Update()
        {
            curDrawnCD -= Time.deltaTime;
            if (curDrawnCD <= 0)
            {
                curDrawnCD = drawnCD;
                DrawnMagic();
            }
            CardCtrl.Instance.UpdateCardSlider(drawnCD, curDrawnCD);

            foreach (var magic in curMagicList)
            {
                magic.curCoolDown -= Time.deltaTime;
                if (magic.curCoolDown > 0)
                {
                    continue;
                }
                magic.curCoolDown = magic.coolDown;
                Cast(magic);
            }
        }

        void Cast(MagicData magic)
        {
            for (int i = 0; i < magic.castNum; i++)
            {
                GameObject newMagic = Instantiate(magic.magic, bulletPool.transform);
                newMagic.GetComponent<Magic>().position = Player.Instance.transform.position;
                newMagic.GetComponent<Magic>().direct = Player.Instance.faceDirect;
            }
        }
    }
}