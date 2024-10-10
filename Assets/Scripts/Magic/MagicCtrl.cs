using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using HandCard;

namespace Magic
{
    public class MagicCtrl : MonoBehaviour
    {
        public static MagicCtrl Instance { get; private set; }
        [SerializeField] private MagicList magicList;
        public float drawnCD = 10;
        public int drawnNum = 3;
        public List<MagicData> magicPool;
        private List<MagicData> curMagicList = new();
        public List<MagicData> nextMagicList = new();
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
            magicPool = new() { };
            foreach (var magicData in magicList.magicList)
            {
                magicPool.Add(Instantiate(magicData));
            }
            DrawnMagic();
            InvokeRepeating(nameof(DrawnMagic), 1, drawnCD);
        }

        void DrawnMagic()
        {
            curMagicList.Clear();
            curMagicList = nextMagicList;
            nextMagicList = magicPool.OrderBy(_ => Random.value).Take(drawnNum).ToList();

            curMagicList.ForEach(item => item.curCoolDown = 0);
            HandCardCtrl.Instance.DrawnCard();
        }

        void Update()
        {
            // HandCardCtrl.Instance.UpdateCardSlider(drawnCD, curDrawnCD);

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

        void Cast(MagicData data)
        {
            for (int i = 0; i < data.castNum; i++)
            {
                GameObject magic = Instantiate(data.magicPrefab, bulletPool.transform);
                magic.AddComponent<Magic>().data = data;
                magic.AddComponent<MagicAttack>().data = data;
                var magicShoot = magic.AddComponent<MagicShoot>();
                var magicMove = magic.AddComponent<MagicMove>();
                magicShoot.data = data;
                magicShoot.castSeq = i;
                magicShoot.magicMove = magicMove;
                magicMove.data = data;
            }
        }
    }
}