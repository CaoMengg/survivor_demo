using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    private float speed = 3;
    private float range = 100;
    private bool isMove = false;
    private Vector2 inputDirect = Vector2.zero;
    public Vector2 faceDirect = Vector2.up;
    private GameObject target;

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
        if (isMove)
        {
            transform.DOMove((Vector2)transform.position + inputDirect, speed).SetSpeedBased();
        }

        GetTarget();
        if (target != null)
        {
            faceDirect = (target.transform.position - transform.position).normalized;
        }
        transform.up = faceDirect;
    }

    void OnMove(InputValue input)
    {
        inputDirect = input.Get<Vector2>();
        if (inputDirect != Vector2.zero)
        {
            isMove = true;
            faceDirect = inputDirect;
        }
        else
        {
            isMove = false;
        }
    }

    void GetTarget()
    {
        target = null;
        var results = GameObject.FindGameObjectsWithTag("Enemy");
        if (results.Count() == 0)
        {
            return;
        }

        var minDistance = float.MaxValue;
        foreach (var result in results)
        {
            var distance = (result.transform.position - transform.position).sqrMagnitude;
            if (distance > minDistance || distance > range)
            {
                continue;
            }
            minDistance = distance;
            target = result;
        }
    }
}
