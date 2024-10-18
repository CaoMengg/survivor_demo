using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    private readonly float speed = 5;
    private bool isMove = false;
    private Vector2 inputDirect = Vector2.zero;
    public Vector2 faceDirect = Vector2.up;
    public Animator animator;

    private List<GameObject> targetList = new List<GameObject>();
    private GameObject target;
    public Transform playerBody;
    public Transform indicator;

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
        InvokeRepeating(nameof(UpdateTarget), 1, 1f);
    }

    void Update()
    {
        if (isMove)
        {
            Vector2 targetPosition = (Vector2)transform.position + inputDirect;
            transform.position = Vector2.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        }

        if (target != null)
        {
            faceDirect = (target.transform.position - transform.position).normalized;
        }
        indicator.up = faceDirect;
    }

    void OnMove(InputValue input)
    {
        inputDirect = input.Get<Vector2>();
        if (inputDirect != Vector2.zero)
        {
            isMove = true;
            faceDirect = inputDirect;
            if (inputDirect.x > 0)
            {
                playerBody.localScale = new Vector3(-1, 1, 1);
            }
            else if (inputDirect.x < 0)
            {
                playerBody.localScale = new Vector3(1, 1, 1);
            }
        }
        else
        {
            isMove = false;
        }
        animator.SetBool("isMove", isMove);
    }

    public GameObject GetNearestTarget()
    {
        targetList.RemoveAll(x => x == null);
        return targetList.FirstOrDefault();
    }

    public GameObject GetRandomTarget()
    {
        targetList.RemoveAll(x => x == null);
        if (targetList.Count == 0)
        {
            return null;
        }
        return targetList[Random.Range(0, targetList.Count)];
    }

    public List<GameObject> GetAllTarget()
    {
        targetList.RemoveAll(x => x == null);
        return targetList;
    }

    void UpdateTarget()
    {
        Collider2D[] results = new Collider2D[20];
        int numFound = Physics2D.OverlapCircleNonAlloc(transform.position, 10, results, LayerMask.GetMask("Enemy"));
        if (numFound == 0)
        {
            targetList.Clear();
            target = null;
            return;
        }

        float distance;
        Dictionary<float, GameObject> dic = new();
        for (int i = 0; i < numFound; i++)
        {
            if (results[i].gameObject == null)
            {
                continue;
            }
            distance = (results[i].transform.position - transform.position).sqrMagnitude;
            dic.Add(distance, results[i].gameObject);
        }
        targetList = dic.OrderBy(x => x.Key).Select(x => x.Value).ToList();
        target = targetList.FirstOrDefault();
    }
}
