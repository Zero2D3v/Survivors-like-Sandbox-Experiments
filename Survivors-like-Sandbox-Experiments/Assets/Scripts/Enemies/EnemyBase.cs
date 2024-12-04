using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// Base class for enemies.
/// Basic components and behaviour to be built upon
/// </summary>
public class EnemyBase : MonoBehaviour
{

    public Rigidbody2D rb;
    public float moveSpeed;
    public float health;
    public float damage;

    private Transform player;
    private Transform target;
    private Vector2 direction;

    [Header("Unity Events")]
    public UnityEvent EnemyHit;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if(!target)
        {
            target = player;
        }

        UIManager uiManager = GameObject.FindGameObjectWithTag("uiManager").GetComponent<UIManager>();
        EXPManager expManager = GameObject.FindGameObjectWithTag("Player").GetComponent<EXPManager>();
        
        EnemyHit.AddListener(uiManager.IncreaseEnemiesKilled);
        EnemyHit.AddListener(() => expManager.IncreaseEXP(1f));
    }
    /// <summary>
    /// Calculates direction to target
    /// </summary>
    /// <returns>Vector2</returns>
    private Vector2 Direction()
    {
        //don't tforget to normalize!! --> otherwise enemy will slow down as gets closer.
        direction = (target.position - transform.position).normalized;
        return direction;
    }
    /// <summary>
    /// Assuming target is 'Player', moves enemy towards target.
    /// Exits if no target assigned.
    /// </summary>
    /// <param name="moveSpeed"></param>
    private void MoveTowardsPlayer(float moveSpeed)
    {
        if (!target) return;

        rb.linearVelocity = (direction * moveSpeed) * Time.deltaTime;
        //transform.position += direction * moveSpeed * Time.deltaTime;
    }

    private void Update()
    {
        Direction();
    }

    private void FixedUpdate()
    {
        MoveTowardsPlayer(moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EnemyHit.Invoke();
            Destroy(gameObject);
        }
    }
    public void TestMethod()
    {
        Debug.Log("TestMethod() called in EnemyHit UnityEvent!");
    }
}
