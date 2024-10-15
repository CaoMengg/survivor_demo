using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    private readonly float speed = 5;
    private readonly float range = 10;
    private bool isMove = false;
    private Vector2 inputDirect = Vector2.zero;
    public Vector2 faceDirect = Vector2.up;
    public Animator animator;

    private readonly Collider2D[] enemyResults = new Collider2D[10];
    private GameObject target;

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
        if (isMove)
        {
            Vector2 targetPosition = (Vector2)transform.position + inputDirect;
            transform.position = Vector2.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        }

        if (target == null)
        {
            GetTarget();
        }
        if (target != null)
        {
            faceDirect = (target.transform.position - transform.position).normalized;
            //transform.up = faceDirect;
        }
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
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (inputDirect.x < 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else
        {
            isMove = false;
        }
        animator.SetBool("isMove", isMove);
    }

    void GetTarget()
    {
        float minDistance = float.MaxValue;
        int numFound = Physics2D.OverlapCircleNonAlloc(transform.position, range, enemyResults, LayerMask.GetMask("Enemy"));
        for (int i = 0; i < numFound; i++)
        {
            float distance = (enemyResults[i].transform.position - transform.position).sqrMagnitude;
            if (distance < minDistance)
            {
                minDistance = distance;
                target = enemyResults[i].gameObject;
            }
        }
    }
}
