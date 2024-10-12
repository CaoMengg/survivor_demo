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

        void Update()
        {
            curCoolDown -= Time.deltaTime;
            if (curCoolDown > 0)
            {
                return;
            }
            curCoolDown = coolDown;

            for (int i = 0; i < spawnNum; i++)
            {
                var direct = Random.insideUnitCircle * 8;
                direct += direct.normalized * 5;
                var index = Random.Range(0, enemyList.enemyList.Count);
                var obj = Instantiate(enemyList.enemyList[index].enemy, enemyPool);
                obj.transform.position = (Vector2)Player.Instance.transform.position + direct;
            }
        }
    }
}