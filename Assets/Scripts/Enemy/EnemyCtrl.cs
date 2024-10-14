using UnityEngine;

namespace Enemy
{
    public class EnemyCtrl : MonoBehaviour
    {
        public static EnemyCtrl Instance { get; private set; }
        public EnemyList enemyList;
        public float coolDown = 0.5f;
        private float curCoolDown;
        public int spawnNum = 4;
        public Transform enemyPool;

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
            InvokeRepeating(nameof(UpdateCD), 300f, 300f);
        }

        void UpdateCD()
        {
            coolDown -= 0.1f;
            if (coolDown < 0.2f)
            {
                coolDown = 0.2f;
            }
        }

        void Update()
        {
            curCoolDown -= Time.deltaTime;
            if (curCoolDown > 0)
            {
                return;
            }
            curCoolDown = coolDown;

            float spawnRate;
            float curRate;
            for (int i = 0; i < spawnNum; i++)
            {
                spawnRate = Random.Range(0, 1000);
                curRate = 0;
                foreach (var enemyData in enemyList.enemyList)
                {
                    curRate += enemyData.spawnRate;
                    if (spawnRate >= curRate)
                    {
                        continue;
                    }


                    var direct = Random.insideUnitCircle * 12;
                    direct += direct.normalized * 10;
                    GameObject enemy = Instantiate(enemyData.enemyPrefab, enemyPool);
                    enemy.AddComponent<Enemy>().Init((Vector2)Player.Instance.transform.position + direct, enemyData);
                    break;
                }
            }
        }
    }
}