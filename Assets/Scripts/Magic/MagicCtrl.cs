using System.Collections.Generic;
using System.Linq;
using Card;
using UnityEngine;

namespace Magic
{
    public class MagicCtrl : MonoBehaviour
    {
        public static MagicCtrl Instance { get; private set; }
        public MagicList magicList;
        private Dictionary<int, MagicData> magicMap = new() { };
        public float drawnCD = 10;
        private float curDrawnCD = 0;
        public int drawnNum = 3;
        private List<MagicData> magicPool = new() { };
        private List<MagicData> curMagicList;
        public List<MagicData> nextMagicList;
        public GameObject bulletPool;

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

        void Start()
        {
            foreach (var magic in magicList.magicList)
            {
                magicMap[magic.magicId] = magic;
                magicPool.Add(magic);
            }
            DrawnMagic();
        }

        void DrawnMagic()
        {
            curMagicList = nextMagicList;
            nextMagicList = magicPool.OrderBy(x => Random.value).ToList().GetRange(0, drawnNum);

            curMagicList.ForEach(item => { item.curCoolDown = 0; });
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